using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using WoueShop.Shared.ReturnModels;

namespace WoueShop.Client.AuthUtility
{
    public class AppAuthenticationStateProvider : AuthenticationStateProvider
    {
        private static readonly Task<AuthenticationState> defaultUnAuthenticatedTask =
            Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

        private static Task<AuthenticationState> authenticationStateTask = defaultUnAuthenticatedTask;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppAuthenticationStateProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            if (_httpContextAccessor.HttpContext.User.Identity is null)
            {
                return await authenticationStateTask;
            }

            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                authenticationStateTask = defaultUnAuthenticatedTask;
                return await authenticationStateTask;
            }

            var claims = _httpContextAccessor.HttpContext.User.Claims;

            authenticationStateTask = Task.FromResult(
                new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims,
                authenticationType: "Identity.Application"))));

            return await authenticationStateTask;
        }

        public void NotifyAuthenticationStateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task UpdateAuthenticationStateAsync(UserInfoModel userInfo)
        {
            Claim[] claims =
                [
                    new Claim(ClaimTypes.NameIdentifier, userInfo.UserId.ToString()),
                    new Claim(ClaimTypes.Name, userInfo.Email),
                    new Claim(ClaimTypes.Email, userInfo.Email)
                ];

            authenticationStateTask = Task.FromResult(
                new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims,
                authenticationType: "Identity.Application"))));

            NotifyAuthenticationStateChanged(authenticationStateTask);

        }

    }
}
