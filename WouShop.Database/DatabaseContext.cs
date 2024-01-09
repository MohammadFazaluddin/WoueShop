using Microsoft.EntityFrameworkCore;

namespace WouShop.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            
        }


    }
}
