using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Dto.ApiReponse;
using SchoolMate.Dto.AuthenticationDto;
using VemsApi.Dto.StudentServiceDto;
using VemsApi.Services;

namespace VemsApi.Controllers
{
    [Route("api/student-service")]
    [ApiController]
    public class StudentServiceController : ControllerBase
    {

        private readonly IStudentService studentService;

        public StudentServiceController(IStudentService _studentService)
        {
            studentService = _studentService;
        }

        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile(UpdateStudentProfileRequest request)
        {
            try
            {
                var response = await studentService.UpdateProfile(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword(ChangePasswordRequest request)
        {
            try
            {
                var response = await studentService.ChangePassword(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }
    }
}
