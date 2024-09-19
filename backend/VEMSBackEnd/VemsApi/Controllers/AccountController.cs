using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Authorizotion;
using SchoolMate.Dto.ApiReponse;

namespace VemsApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }


        [HttpGet("/admins")]
        [Authorize("ADMIN", "STUDENT")]
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

        [HttpGet("/teachers")]
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


        [HttpGet("/students")]
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
    }
}
