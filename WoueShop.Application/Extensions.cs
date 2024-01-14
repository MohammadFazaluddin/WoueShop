using Microsoft.Extensions.DependencyInjection;
using WoueShop.Application.Auth;

namespace WoueShop.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<UsersHandlerService>();

            return services;
        }
    }
}
