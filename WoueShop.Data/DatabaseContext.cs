using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WoueShop.Data.AuthEntities;
using WoueShop.Data.UserEntities;
using WouShop.Database.Entities;

namespace WouShop.Database
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            
        }

        public DbSet<ProductModel> Products { get; set; }

        public DbSet<MediaModel> Media { get; set; }

        // USER
        public DbSet<SupplierModel> Supplier { get; set; }

        public DbSet<SupplierTypeModel> SupplierType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ProductModel>()
                .HasQueryFilter(e => e.DeletedAt == null);

            base.OnModelCreating(modelBuilder);
        }
    }
}
