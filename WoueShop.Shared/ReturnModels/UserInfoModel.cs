namespace WoueShop.Shared.ReturnModels
{
    public class UserInfoModel
    {
        public required Guid UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public required string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

    }
}
