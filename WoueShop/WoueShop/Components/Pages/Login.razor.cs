using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using WoueShop.Application.Auth;
using WoueShop.Client.AuthUtility;
using WoueShop.Data.AuthEntities;
using WoueShop.Shared.ReturnModels;
using WoueShop.Shared.ViewModels;

namespace WoueShop.Components.Pages
{
    public partial class Login : ComponentBase
    {
        [Inject]
        NavigationManager? NavManager { get; set; }

        [Inject]
        UserManager<ApplicationUser> UserManager { get; set; }

        [Inject]
        SignInManager<ApplicationUser> SingInManager { get; set; }

        [Inject]
        AuthenticationStateProvider AuthStateProvider { get; set; }

        [SupplyParameterFromQuery]
        private string? ReturnUrl { get; set; } = "/";

        [CascadingParameter]
        HttpContext HttpContext { get; set; }

        [SupplyParameterFromForm]
        UserLoginModel userModel { get; set; } = new();

        string errorMessage = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (HttpMethods.IsGet(HttpContext.Request.Method))
            {
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            }
        }

        public async Task LoginInUser()
        {
            var user = await UserManager.FindByEmailAsync(userModel.Email);

            if (user is null)
            {
                errorMessage = UserErrors.InvalidEmail.Description;
                return;
            }

            var signIn = await SingInManager.PasswordSignInAsync(user, userModel.Password, userModel.RememberMe, false);

            if (!signIn.Succeeded)
            {
                errorMessage = UserErrors.InvalidPassword.Description;
                return;
            }

            errorMessage = string.Empty;

            if (!Uri.IsWellFormedUriString(ReturnUrl, UriKind.Relative))
            {
                ReturnUrl = NavManager.ToBaseRelativePath(ReturnUrl);
            }

            var auth = (AppAuthenticationStateProvider)AuthStateProvider;

            UserInfoModel userInfo = new()
            {
                Email = user.Email,
                Name = user.FullName,
                UserId = user.Id,
            };

            await auth.UpdateAuthenticationStateAsync(userInfo);

            NavManager!.NavigateTo(ReturnUrl);


        }
    }
}
