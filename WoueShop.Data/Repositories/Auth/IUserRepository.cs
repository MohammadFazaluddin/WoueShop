using Microsoft.AspNetCore.Identity;
using WoueShop.Data.AuthEntities;
using WoueShop.Shared.ReturnModels;

namespace WoueShop.Data.Repositories.Auth
{
    public interface IUserRepository
    {
        Task<IdentityResult?> CreateUser(UserInfoModel user);

        Task<IdentityResult?> Update(Guid userId, ApplicationUser user);

        Task<IdentityResult?> DeleteUserById(Guid userid);

        Task<IEnumerable<ApplicationUser>?> GetAllUsers();

        Task<ApplicationUser?> GetUserById(Guid userid);

        Task<ApplicationUser?> GetUserByEmail(string email);
    }
}
