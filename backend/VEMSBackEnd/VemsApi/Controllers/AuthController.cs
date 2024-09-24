using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Dto.ApiReponse;
using SchoolMate.Dto.AuthenticationDto;
using SchoolMate.Services;

namespace VemsApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAccountService accountService;

        public AuthController(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        [HttpPost("/login")]
        public IActionResult Login(AuthenticationRequest request)
        {
            try
            {
                return APIResponse.Success(null);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("/rerister")]
        public IActionResult Register()
        {
            try
            {
                return APIResponse.Success(null);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("/recoverPassword")]
        public IActionResult RecoverPassword()
        {
            try
            {
                return APIResponse.Success(null);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }
    }
}
