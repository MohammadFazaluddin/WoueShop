using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WoueShop.Data.Repositories.Auth;
using WoueShop.Data.Repositories.Product;

namespace WoueShop.Data
{
    public static class Extensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var config = serviceProvider.GetRequiredService<IConfiguration>();

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
