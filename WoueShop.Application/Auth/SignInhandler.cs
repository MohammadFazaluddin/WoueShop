using Microsoft.AspNetCore.Identity;
using WoueShop.Data.AuthEntities;
using WoueShop.Shared.Abstraction;
using WoueShop.Shared.ReturnModels;
using WoueShop.Shared.ViewModels;

namespace WoueShop.Application.Auth
{
    public class SignInhandler
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public SignInhandler(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Result> LoginInUser(UserLoginModel userLogins)
        {
            var user = await _signInManager.UserManager.FindByEmailAsync(userLogins.Email);

            if (user is null)
            {
                return Result.Failure(UserErrors.InvalidEmail);
            }

            var signIn = await _signInManager.PasswordSignInAsync(user, userLogins.Password, userLogins.RememberMe, false);

            if (!signIn.Succeeded)
            {
                return Result.Failure(UserErrors.InvalidPassword);
            }

            return Result.Success();

        }
    }
}
