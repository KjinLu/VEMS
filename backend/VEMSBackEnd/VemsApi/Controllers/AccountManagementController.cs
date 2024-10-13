using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Authorizotion;
using SchoolMate.Dto.ApiReponse;
using VemsApi.Dto.AccountDto;
using VemsApi.Dto.PaginationDto;
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
        public async Task<IActionResult> GetAllAdminsAsync([FromQuery] PaginationRequest request)
        {
            try
            {
                var admins = await accountService.GetAllAdminAccountAsync(request);
                return APIResponse.Success(admins);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpGet("teachers")]
        [Authorize("ADMIN")]
        public async Task<IActionResult> GetAllTeachers([FromQuery] PaginationRequest request)
        {
            try
            {
                var admins = await accountService.GetAllTeacherAccountAsync(request);
                return APIResponse.Success(admins);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }


        [HttpGet("students")]
        [Authorize("ADMIN")]
        public async Task<IActionResult> GetAllStudents([FromQuery] PaginationRequest request)
        {
            try
            {
                var admins = await accountService.GetAllStudentAccountAsync(request);
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
        [Authorize("ADMIN")]
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
        [Authorize("ADMIN")]
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


        [HttpPost("createStudentAccount")]
        [Authorize("ADMIN")]
        public async Task<IActionResult> CreateStudent(CreateStudentRequest request)
        {
            try
            {
                var response = await accountService.CreateStudentAccount(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("createTeacherAccount")]
        [Authorize("ADMIN")]
        public async Task<IActionResult> CreateTeacher(CreateTeacherRequest request)
        {
            try
            {
                var response = await accountService.CreateTeacherAccount(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPut("updateTeacherAccount")]
        [Authorize("ADMIN")]
        public async Task<IActionResult> UpdateTeacher(AdminUpdateTeacher request)
        {
            try
            {
                var response = await accountService.AdminUpdateTeacherAccount(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPut("updateStudentAccount")]
        [Authorize("ADMIN")]
        public async Task<IActionResult> UpdateStudent(AdminUpdateStudent request)
        {
            try
            {
                var response = await accountService.AdminUpdateStudentAccount(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }
    }
}
