using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WouShop.Database.Entities
{
    [Table("ProductMedia")]
    public class MediaModel : BaseEntityModel
    {
        public int Id { get; set; }

        public string Path { get; set; } = string.Empty;

        [MaxLength(150)]
        public string ContentType { get; set; } = string.Empty;

        [ForeignKey(nameof(ProductId))]
        public ProductModel Product { get; set; }

        public Guid ProductId { get; set; }
    }
}
