using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Dto.ApiReponse;
using VemsApi.Dto.ClassroomDto;
using VemsApi.Dto.PaginationDto;
using VemsApi.Services;

namespace VemsApi.Controllers
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
