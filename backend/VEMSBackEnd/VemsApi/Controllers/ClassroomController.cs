using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Dto.ApiReponse;
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
                return  APIResponse.Success(await _classroomService.GetAllClassrooms(request));
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
    }
}
