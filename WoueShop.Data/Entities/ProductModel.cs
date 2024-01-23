using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WouShop.Database.Entities
{
    [Table(name: "Products")]
    public class ProductModel : BaseEntityModel
    {
        public Guid Id { get; set; }

        [MaxLength(450)]
        [Required(ErrorMessage = "Please fill in the Product name")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Please provide the price")]
        public decimal Price { get; set; }

        public decimal? DiscountedPrice { get; set; }

        public bool? IsOurChoice { get; set; }

        public ICollection<MediaModel>? Media { get; set; } = null;

    }
}
