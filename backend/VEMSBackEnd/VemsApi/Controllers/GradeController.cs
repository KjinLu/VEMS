using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Dto.ApiReponse;
using VemsApi.Dto.PaginationDto;
using VemsApi.Services;

namespace VemsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService _service)
        {
            _gradeService = _service;
        }

        [HttpGet]
        public async Task<IActionResult> GetClassrooms([FromQuery] PaginationRequest request)
        {
            try
            {
                return APIResponse.Success(await _gradeService.GetAllGrades(request));
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

          [HttpGet("{id}")]
        public async Task<IActionResult> GetGradeById(Guid id)
        {
            try
            {
                return APIResponse.Success(await _gradeService.GetGradeById(id));
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }
    }
}
