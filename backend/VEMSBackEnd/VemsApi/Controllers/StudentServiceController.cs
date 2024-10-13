using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Authorizotion;
using SchoolMate.Dto.ApiReponse;
using VemsApi.Dto.ImageDto;
using VemsApi.Dto.PaginationDto;
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


        [HttpGet]
        public async Task<IActionResult> GetStudents([FromQuery] PaginationRequest request)
        {
            try
            {
                return APIResponse.Success(await studentService.GetAllStudents(request));
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }


        [HttpGet("class")]
        public async Task<IActionResult> GetStudentByClassroom([FromQuery] Guid classId)
        {
            try
            {
                return APIResponse.Success(await studentService.GetAllStudentByClassroom(classId));
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPut("update-profile")]
        [Authorize("STUDENT")]
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
        [Authorize("STUDENT")]
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

        [HttpPost("upload-avatar")]
        // [Authorize("STUDENT")]
        public async Task<IActionResult> UploadAvatarr(UploadAvatartRequest request)
        {
            try
            {
                var response = await studentService.UploadAvatar(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpDelete("delete-avatar")]
        [Authorize("STUDENT")]
        public async Task<IActionResult> DeleteAvatar(DeleteAvatarRequest request)
        {
            try
            {
                var response = await studentService.DeleteAvatar(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }
    }
}
