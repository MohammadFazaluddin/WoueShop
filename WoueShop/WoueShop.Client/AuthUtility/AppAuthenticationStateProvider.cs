using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using WoueShop.Client.Models;
using WoueShop.Shared.ReturnModels;

namespace WoueShop.Client.AuthUtility
{
    public class AppAuthenticationStateProvider : AuthenticationStateProvider
    {
        private static readonly Task<AuthenticationState> defaultUnAuthenticatedTask =
            Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

        private Task<AuthenticationState> authenticationStateTask = defaultUnAuthenticatedTask;

        public AppAuthenticationStateProvider(PersistentComponentState state)
        {
            if (!state.TryTakeFromJson<UserInfo>(nameof(UserInfo), out var userInfo) || userInfo is null)
            {
                return;
            }

            Claim[] claims =
            [
                new Claim(ClaimTypes.NameIdentifier, userInfo.UserId),
                new Claim(ClaimTypes.Name, userInfo.Email),
                new Claim(ClaimTypes.Email, userInfo.Email)
            ];

            authenticationStateTask = Task.FromResult(
                new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, 
                nameof(AppAuthenticationStateProvider)))));
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync() => authenticationStateTask;

        public Task UpdateAuthenticationStateAsync(UserInfoModel userInfo)
        {
            Claim[] claims =
            [
                new Claim(ClaimTypes.NameIdentifier, userInfo.UserId.ToString()),
                new Claim(ClaimTypes.Name, userInfo.Email),
                new Claim(ClaimTypes.Email, userInfo.Email)
            ];

            authenticationStateTask = Task.FromResult(
                new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims,
                authenticationType: nameof(AppAuthenticationStateProvider)))));

            NotifyAuthenticationStateChanged(authenticationStateTask);

            return Task.FromResult(authenticationStateTask);
        }

    }
}
