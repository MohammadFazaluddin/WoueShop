using Microsoft.AspNetCore.Identity;
using System.Data;
using WoueShop.Data.AuthEntities;
using WoueShop.Shared.Globals;
using WouShop.Database;

namespace WoueShop.Middlewares
{
    public static class SeedSuperAdmin
    {
        /// <summary>
        /// Checks and ensures that the user with username SuperAdmin and the admin role is added to the database
        /// if not added into the database then adds the respective record to database
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection RegisterAdmin(this IServiceCollection services)
        {
            var scope = services.BuildServiceProvider().CreateScope();

            var database = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            database.Database.EnsureCreated();

            var adminRole = new ApplicationRole("Admin");

            //CREATE ROLE IF NO ROLES WERE AVAILABLE
            if (!database.Roles.Any())
            {
                roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
            }

            //IF SUPER ADMIN DOES NOT EXISTS CREATE USER BY NAME SUPERADMIN
            var superadminUser = database.Users.Any(e => e.UserName.ToLower() == "superadmin");

            if (!superadminUser)
            {
                var adminUser = new ApplicationUser()
                {
                    Id = Guid.NewGuid(),
                    UserName = UserConstants.AdminRole,
                    FullName = UserConstants.AdminRole,
                    Email = UserConstants.AdminEmail,
                };

                userManager.CreateAsync(adminUser, UserConstants.AdminPassword).GetAwaiter().GetResult();

                userManager.AddToRoleAsync(adminUser, adminRole.Name);

            }

            return services;
        }
    }
}
