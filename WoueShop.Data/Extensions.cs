using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WoueShop.Data.Interfaces;
using WoueShop.Data.Repositories;
using WouShop.Database;

namespace WoueShop.Data
{
    public static class Extensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var config = serviceProvider.GetRequiredService<IConfiguration>();

            services.AddScoped<IProductsRepository, ProductsRepository>();

            return services;
        }
    }
}
