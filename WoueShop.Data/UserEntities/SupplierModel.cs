using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WoueShop.Data.AuthEntities;
using WouShop.Database.Entities;

namespace WoueShop.Data.UserEntities
{
    [Table(name: "Suppliers")]
    public class SupplierModel : BaseEntityModel
    {
        public Guid Id { get; set; }

        [MaxLength(250)]
        public string Name { get; set; }

        public SupplierTypeModel Type { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public Guid UserId { get; set; }

    }
}
