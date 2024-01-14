using Microsoft.AspNetCore.Mvc;
using WoueShop.Application.Auth;
using WoueShop.Extensions;
using WoueShop.Shared.Abstraction;
using WoueShop.Shared.Globals;
using WoueShop.Shared.ReturnModels;

namespace WoueShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersHandlerService _userHandler;
        public UsersController(UsersHandlerService userHandler)
        {
            _userHandler = userHandler;
        }

        [HttpPost]
        public async Task<IResult> RegisterUser(UserInfoModel user)
        {
            Result<Guid> result = await _userHandler.CreateUser(user, UserConstants.CustomerRole);

            return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
        }
    }
}
