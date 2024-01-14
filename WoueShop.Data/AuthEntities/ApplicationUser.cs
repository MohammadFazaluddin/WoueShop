using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WoueShop.Data.UserEntities;

namespace WoueShop.Data.AuthEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [MaxLength(250)]
        public string? FullName { get; set; }

        public Guid? SupplierId { get; set; }

        public SupplierModel? Supplier { get; set; }

    }
}
