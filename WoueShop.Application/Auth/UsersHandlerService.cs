using WoueShop.Data.Repositories.Auth;
using WoueShop.Shared.Abstraction;
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

        public async Task<Result<Guid>> CreateUser(UserInfoModel userInfo, string role)
        {
            var uniqueEmail = _userRepository.IsUniqueEmail(userInfo.Email);

            if (!uniqueEmail)
            {
                return Result.Failure<Guid>(UserErrors.EmailAlreadyExists);
            }

            userInfo.Id = Guid.NewGuid();

            var addUser = await _userRepository.CreateUser(userInfo);

            if (addUser == null)
            {
                return Result.Failure<Guid>(UserErrors.ServerError);
            }

            if (!addUser.Succeeded)
            {
                return Result.Failure<Guid>(UserErrors.AccountFailure);
            }

            var assignRole = await _userRepository.AssignRoleToUser(userInfo.Id, role);

            if (assignRole == null)
            {
                return Result.Failure<Guid>(UserErrors.ServerError);
            }

            if (!assignRole.Succeeded)
            {
                return Result.Failure<Guid>(UserErrors.RoleFailure);
            }

            return userInfo.Id;
        }

    }
}
