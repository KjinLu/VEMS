using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Authorizotion;
using SchoolMate.Dto.ApiReponse;
using SchoolMate.Dto.AuthenticationDto;
using VemsApi.Services;

namespace VemsApi.Controllers
{
    [Route("api/account-management")]
    [ApiController]
    public class AccountManagementController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountManagementController(IAccountService _accountService)
        {
            accountService = _accountService;
        }


        [HttpGet("admins")]
        [Authorize("ADMIN")]
        public async Task<IActionResult> GetAllAdminsAsync()
        {
            try
            {
                var admins = await accountService.GetAllAdminAccountAsync();
                return APIResponse.Success(admins);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpGet("teachers")]
        [Authorize("ADMIN")]
        public async Task<IActionResult> GetAllTeachers()
        {
            try
            {
                var admins = await accountService.GetAllTeacherAccountAsync();
                return APIResponse.Success(admins);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }


        [HttpGet("students")]
        [Authorize("ADMIN")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var admins = await accountService.GetAllStudentAccountAsync();
                return APIResponse.Success(admins);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("changeAccountPassword")]
        [Authorize("ADMIN")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
        {
            try
            {
                var response = await accountService.ChangePassword(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("registerStudents")]
        public async Task<IActionResult> RegisterStudent(List<RegisterStudentRequest> request)
        {
            try
            {
                var response = await accountService.RegisterStudent(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("registerTeachers")]
        public async Task<IActionResult> RegisterTeacher(List<RegisterTeacherRequest> request)
        {
            try
            {
                var response = await accountService.RegisterTeacher(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }
    }
}
