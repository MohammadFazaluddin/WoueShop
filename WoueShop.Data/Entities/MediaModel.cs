using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WouShop.Database.Entities
{
    [Table("ProductMedia")]
    public class MediaModel : BaseEntityModel
    {
        public int Id { get; set; }

        public string Path { get; set; } = "https://store-images.s-microsoft.com/image/apps.62159.68326442227858632.03782b23-7f26-4a8e-ba87-177bdf2c3c90.1405eb3a-6314-4e44-a822-7660d70a6ec5?q=90&w=480&h=270";

        [MaxLength(150)]
        public string ContentType { get; set; } = string.Empty;

        [ForeignKey(nameof(ProductId))]
        public ProductModel Product { get; set; }

        public Guid ProductId { get; set; }
    }
}
