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

        public DbSet<Product> Products { get; set; }

        public DbSet<Media> Media { get; set; }
    }
}
