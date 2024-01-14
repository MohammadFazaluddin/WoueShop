using WoueShop.Data.Repositories.Auth;
using WoueShop.Shared.ReturnModels;

namespace WoueShop.Application.Auth
{
    public class UsersHandlerService
    {
        private readonly IUserRepository _userRepository;

        public UsersHandlerService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(UserInfoModel userInfo)
        {

        }

    }
}
