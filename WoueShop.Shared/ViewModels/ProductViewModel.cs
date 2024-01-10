using System.ComponentModel.DataAnnotations;

namespace WoueShop.Shared.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public Guid Id { get; set; }

        [MaxLength(450)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public decimal? DiscountedPrice { get; set; }

        public bool? IsOurChoice { get; set; }

        public ICollection<Media>? Media { get; set; } = null;
    }
}
