using WoueShop.Shared.Abstraction;

namespace WoueShop.Application.Auth
{
    public record UserErrors
    {
        public static Error EmailAlreadyExists = Error.Conflict("Users.EmailAlreadyExists", "Email address is already in use");

        public static Error AccountFailure = Error.Failure("Users.AccountFailure", "User account set up failed");

        public static Error RoleFailure = Error.Conflict("Users.RoleFailure", "Assigning role to the user failed");

        public static Error ServerError = Error.Failure("Users.ServerError", "There was a server error");

        public static Error InvalidEmail = Error.Validation("LoginFailed.InvalidEmail", $"Invalid email address");

        public static Error InvalidPassword = Error.Failure("LoginFailed.LoginFailed", "Invalid password");
    }
}
