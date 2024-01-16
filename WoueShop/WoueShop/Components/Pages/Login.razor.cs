using Microsoft.AspNetCore.Components;
using System.Xml;
using WoueShop.Application.Auth;
using WoueShop.Shared.ViewModels;

namespace WoueShop.Components.Pages
{
    public partial class Login : ComponentBase
    {
        [Inject]
        SignInhandler? SignInhandler { get; set; }

        [Inject]
        NavigationManager? NavManager { get; set; }

        [SupplyParameterFromQuery]
        private string? ReturnUrl { get; set; }

        UserLoginModel userModel { get; set; } = new();

        string errorMessage = string.Empty;

        async void HandleLogin()
        {
            var signIn = await SignInhandler!.LoginInUser(userModel);

            if (!signIn.IsSuccess)
            {
                errorMessage = signIn.Error.Description;
            }
            else if (signIn.IsSuccess)
            {
                errorMessage = string.Empty;
                NavManager!.NavigateTo(ReturnUrl);
            }

        }
    }
}
