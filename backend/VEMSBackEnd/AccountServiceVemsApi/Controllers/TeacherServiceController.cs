using DataAccess.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Authorizotion;
using SchoolMate.Dto.ApiReponse;

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
        [Authorize("TEACHER")]
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

        [HttpGet("profile")]
        public async Task<IActionResult> GetTeacherByID([FromQuery] Guid id)
        {
            try
            {
                return APIResponse.Success(await teacherService.GetTeacherProfileByIdAsync(id));
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPut("update-password")]
        [Authorize("TEACHER")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordRequest request)
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

        [HttpPost("upload-avatar")]
        [Authorize("TEACHER")]
        public async Task<IActionResult> UploadAvatar(UploadAvatartRequest request)
        {
            try
            {
                var response = await teacherService.UploadAvatar(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpDelete("delete-avatar")]
        [Authorize("TEACHER")]
        public async Task<IActionResult> DeleteAvatar(DeleteAvatarRequest request)
        {
            try
            {
                var response = await teacherService.DeleteAvatar(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }
    }
}
