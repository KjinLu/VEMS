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
<<<<<<< HEAD
            authService = _authService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Authetication(string accessToken)
        {
            try
            {
                var response = await authService.Authetication(accessToken);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthenticationRequest request)
=======
        }

        [HttpPost("/login")]
        public IActionResult Login(AuthenticationRequest request)
>>>>>>> 7b71eb53662e57dca054c91a3c37a5502da59b96
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

<<<<<<< HEAD
        [HttpGet]
        [Route("agent")]
        public IActionResult Test()
        {

            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            //// Kiểm tra các header forwarded nếu có
            //if (HttpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
            //{
            //    ipAddress = HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            //}

            //return Ok(new { IpAddress = ipAddress });
            var userAgent = Request.Headers["User-Agent"].ToString();
            return Ok(new { UserAgent = userAgent });

            //"userAgent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/128.0.0.0 Safari/537.36"
            //"userAgent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/128.0.0.0 Safari/537.36 Edg/128.0.0.0"
        }

        [HttpPost("refresToken")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest request)
=======
        [HttpPost("/rerister")]
        public IActionResult Register()
>>>>>>> 7b71eb53662e57dca054c91a3c37a5502da59b96
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

<<<<<<< HEAD

        [HttpPost("sendeRecoverPasswordEmail")]
        public async Task<IActionResult> RecoverPassword(SendEmailRequest request)
        {
            try
            {
                var response = await authService.SendRecoverEmail(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }


        [HttpPost("validateEmail")]
        public async Task<IActionResult> ValidateEmail(ValidateEmailRequest request)
        {
            try
            {
                var response = await authService.CheckVerifyEmail(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            try
            {
                var response = await authService.ChangePassword(request);
                return APIResponse.Success(response);
=======
        [HttpPost("/recoverPassword")]
        public IActionResult RecoverPassword()
        {
            try
            {
                return APIResponse.Success(null);
>>>>>>> 7b71eb53662e57dca054c91a3c37a5502da59b96
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }
    }
}
