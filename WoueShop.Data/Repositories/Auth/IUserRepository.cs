using Microsoft.AspNetCore.Identity;
using WoueShop.Data.AuthEntities;
using WoueShop.Shared.ReturnModels;

namespace WoueShop.Data.Repositories.Auth
{
    public interface IUserRepository
    {
        Task<IdentityResult?> CreateUser(UserInfoModel user);

        Task<IdentityResult?> Update(Guid userId, ApplicationUser user);

        Task<IdentityResult?> DeleteUserById(Guid userId);

        Task<IEnumerable<ApplicationUser>?> GetAllUsers();

        Task<ApplicationUser?> GetUserById(Guid userId);

        Task<ApplicationUser?> GetUserByEmail(string email);

        bool IsUniqueEmail(string email);

        Task<IdentityResult> AssignRoleToUser(Guid userId, string role);
    }
}
