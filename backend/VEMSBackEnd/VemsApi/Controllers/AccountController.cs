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


        [HttpGet("")]
        //[Authorize("ADMIN")]
        public IActionResult GetAllAdmins(string id)
        {
            try
            {
                return APIResponse.Success(accountService.GetAllAdminAccount());
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpGet("/admins")]
        //[Authorize("ADMIN")]
        public IActionResult GetAllAdmins()
        {
            try
            {
                return APIResponse.Success(accountService.GetAllAdminAccount());
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }


        [HttpGet("/teachers")]
        //[Authorize("ADMIN")]
        public IActionResult GetAllTeachers()
        {
            try
            {
                return APIResponse.Success(accountService.GetAllTeacherAccount());
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }


        [HttpGet("/students")]
        //[Authorize("ADMIN")]
        public IActionResult GetAllStudents()
        {
            try
            {
                return APIResponse.Success(accountService.GetAllStudentAccount());
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }
    }
}
