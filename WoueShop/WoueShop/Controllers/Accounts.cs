using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WoueShop.Data.AuthEntities;

namespace WoueShop.Controllers
{
    public static class Accounts
    {
        public static IEndpointConventionBuilder MapAuthEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var group = endpoints.MapGroup("/api/auth");

            group.MapPost("/logout", async (
                ClaimsPrincipal user,
                SignInManager<ApplicationUser> signInManager,
                [FromForm]string returnURl) =>
            {
                await signInManager.SignOutAsync();
                return TypedResults.LocalRedirect($"~/{returnURl}");
            });

            return group;
        }
    }
}
