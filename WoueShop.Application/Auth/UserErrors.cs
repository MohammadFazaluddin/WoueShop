using WoueShop.Shared.Abstraction;

namespace WoueShop.Application.Auth
{
    public static class UserErrors
    {
        public static readonly Error EmailAlreadyExists = Error.Conflict("Users.EmailAlreadyExists", "Email address is already in use");

        public static readonly Error AccountFailure = Error.Failure("Users.AccountFailure", "User account set up failed");

        public static readonly Error RoleFailure = Error.Conflict("Users.RoleFailure", "Assigning role to the user failed");


        public static readonly Error ServerError = Error.Failure("Users.ServerError", "There was a server error");
    }
}
