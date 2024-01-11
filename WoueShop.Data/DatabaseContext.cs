using Microsoft.EntityFrameworkCore;
using WouShop.Database.Entities;

namespace WouShop.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            
        }

        public DbSet<ProductModel> Products { get; set; }

        public DbSet<MediaModel> Media { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ProductModel>()
                .HasQueryFilter(e => e.DeletedAt != null);

            base.OnModelCreating(modelBuilder);
        }
    }
}
