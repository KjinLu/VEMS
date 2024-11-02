using DataAccess.Dto.ClassroomDto;
using DataAccess.DTO;
using GradeClassroomService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Dto.ApiReponse;



namespace GradeClassroomService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {

        private readonly IClassroomService _classroomService;

        public ClassroomController(IClassroomService _service)
        {
            _classroomService = _service;
        }

        [HttpGet]
        public async Task<IActionResult> GetClassrooms([FromQuery] PaginationRequest request)
        {
            try
            {
                return APIResponse.Success(await _classroomService.GetAllClassrooms(request));
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpGet("class-students")]
        public async Task<IActionResult> GetClassStudents(Guid classID)
        {
            try
            {
                return APIResponse.Success(await _classroomService.GetClassStudents(classID));
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpGet("student-types")]
        public async Task<IActionResult> GetStudentType()
        {
            try
            {
                return APIResponse.Success(await _classroomService.GetAllStudentType());
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassroomById(Guid id)
        {
            try
            {
                return APIResponse.Success(await _classroomService.GetClassroomById(id));
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> AddClassroom(ClassroomResponse classroom)
        {
            try
            {
                await _classroomService.AddClassroom(classroom);
                return APIResponse.Success();
            }
            catch (InvalidOperationException e)
            {
                return APIResponse.RequestError(null, e.Message);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("import-classes")]
        public async Task<IActionResult> AddClassrooms(List<ImportClassRequest> classrooms)
        {
            try
            {
                await _classroomService.AddClassrooms(classrooms);
                return APIResponse.Success();
            }
            catch (InvalidOperationException e)
            {
                return APIResponse.RequestError(null, e.Message);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("assign-student")]
        public async Task<IActionResult> AssignStudentType(AssignStudentTypeRequest request)
        {
            try
            {
                var response = await _classroomService.AssignStudentType(request);
                return APIResponse.Success(response);
            }
            catch (InvalidOperationException e)
            {
                return APIResponse.RequestError(null, e.Message);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateClassroom(ClassroomResponse classroom)
        {
            try
            {
                await _classroomService.UpdateClassroom(classroom);
                return APIResponse.Success();
            }
            catch (InvalidOperationException e)
            {
                return APIResponse.RequestError(null, e.Message);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassroom(Guid id)
        {
            try
            {
                await _classroomService.DeleteClassroom(id);
                return APIResponse.Success();
            }
            catch (InvalidOperationException e)
            {
                return APIResponse.RequestError(null, e.Message);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }
    }
}
