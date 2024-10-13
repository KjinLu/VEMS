using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyDreamAPI.Dto.AuthDto;
using SchoolMate.Dto.ApiReponse;
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
        {
            try
            {
                var response = await authService.Login(request);
                if (response != null)
                    return APIResponse.Success(response);
                return APIResponse.Error(null, "Tên đăng nhập hoặc mật khẩu không chính xác!");
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

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
        {
            try
            {
                var response = await authService.RefreshToken(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }


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
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }
    }
}
