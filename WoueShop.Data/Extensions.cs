using Microsoft.Extensions.DependencyInjection;
using WoueShop.Data.Interfaces;
using WoueShop.Data.Repositories;

namespace WoueShop.Data
{
    public static class Extensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {

            services.AddScoped<IProductsRepository, ProductsRepository>();

            return services;
        }
    }
}
