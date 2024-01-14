using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WouShop.Database.Entities;

namespace WoueShop.Data.UserEntities
{
    [Table(name: "SupplierTypes")]
    public class SupplierTypeModel : BaseEntityModel
    {
        public int Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(450)]
        public string? Description { get; set; }

        public SupplierModel Supplier { get; set; }

        public Guid SupplierId { get; set; }
    }
}
