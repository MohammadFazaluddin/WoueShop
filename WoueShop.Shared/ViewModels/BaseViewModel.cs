namespace WoueShop.Shared.ViewModels
{
    public class BaseViewModel
    {
        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public string? ModifiedBy { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public DateTime? DeletedAt { get; set; } = null;
    }
}
