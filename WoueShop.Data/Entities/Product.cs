using System.ComponentModel.DataAnnotations;

namespace WouShop.Database.Entities
{
    public class Product : BaseEntityModel
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
