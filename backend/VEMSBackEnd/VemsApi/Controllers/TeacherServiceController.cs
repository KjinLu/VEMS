using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Dto.ApiReponse;
using SchoolMate.Dto.AuthenticationDto;
using VemsApi.Dto.StudentServiceDto;
using VemsApi.Services;

namespace VemsApi.Controllers
{
    [Route("api/teacher-service")]
    [ApiController]
    public class TeacherServiceController : ControllerBase
    {
        private readonly ITeacherService teacherService;

        public TeacherServiceController(ITeacherService _teacherService)
        {
            teacherService = _teacherService;
        }

        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile(UpdateTeacherProfileRequest request)
        {
            try
            {
                var response = await teacherService.UpdateProfile(request);
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
                var response = await teacherService.ChangePassword(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }
    }
}
