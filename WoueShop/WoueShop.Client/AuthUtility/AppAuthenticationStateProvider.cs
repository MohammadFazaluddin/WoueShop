using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using WoueShop.Shared.ReturnModels;

namespace WoueShop.Client.AuthUtility
{
    internal class AppAuthenticationStateProvider : AuthenticationStateProvider
    {
        private static readonly Task<AuthenticationState> defaultUnAuthenticatedTask =
            Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

        private readonly Task<AuthenticationState> authenticationStateTask = defaultUnAuthenticatedTask;

        public AppAuthenticationStateProvider(PersistentComponentState state)
        {
            if (!state.TryTakeFromJson<UserInfoModel>(nameof(UserInfoModel), out var userInfo) || userInfo is null)
            {
                return;
            }

            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userInfo.UserId.ToString()),
                new Claim(ClaimTypes.Name, userInfo.Name),
                new Claim(ClaimTypes.Email, userInfo.Email)
            };

            authenticationStateTask = Task.FromResult(
                new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, 
                nameof(AppAuthenticationStateProvider)))));
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync() => authenticationStateTask;

    }
}
