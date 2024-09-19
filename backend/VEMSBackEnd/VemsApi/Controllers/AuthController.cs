using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyDreamAPI.Dto.AuthDto;
using SchoolMate.Dto.ApiReponse;
using SchoolMate.Dto.AuthenticationDto;
using VemsApi.Dto.AuthenticationDto;
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

        [HttpPost("/login")]
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

        [HttpPost("/refresToken")]
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

        [HttpPost("/registerStudent")]
        public async Task<IActionResult> RegisterStudent(List<RegisterStudentRequest> request)
        {
            try
            {
                var response = await authService.RegisterStudent(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("/registerTeacher")]
        public async Task<IActionResult> RegisterTeacher(List<RegisterTeacherRequest> request)
        {
            try
            {
                var response = await authService.RegisterTeacher(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("/sendeRecoverPasswordEmail")]
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
    }
}
