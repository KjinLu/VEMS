using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Dto.ApiReponse;
using SchoolMate.Dto.AuthenticationDto;
using VemsApi.Services;

namespace VemsApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAccountService accountService;
        private readonly IAuthService authService;

        public AuthController(IAccountService _accountService, IAuthService _authService)
        {
            accountService = _accountService;
            authService = _authService;
        }

        [HttpPost("/")]
        public IActionResult Authetication(string accessToken)
        {
            try
            {
                var response = authService.Authetication(accessToken);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("/login")]
        public IActionResult Login(AuthenticationRequest request)
        {
            try
            {
                var response = authService.Login(request);
                if (response != null) 
                return APIResponse.Success(response);
                return APIResponse.Error(null, "Username or password is incorrect");
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
