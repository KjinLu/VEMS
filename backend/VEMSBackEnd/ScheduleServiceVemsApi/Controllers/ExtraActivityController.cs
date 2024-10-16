using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Dto.ApiReponse;
using ScheduleServiceVemsApi.Services;

namespace ScheduleServiceVemsApi.Controllers
{
    [Route("api/extraActivities")]
    [ApiController]
    public class ExtraActivityController : ControllerBase
    {
        private readonly IExtraActivityService _extraActivityService;
        public ExtraActivityController(IExtraActivityService extraActivityService)
        {
            _extraActivityService = extraActivityService;
        }

        [HttpPost("createActivityAttendance")]
        public async Task<IActionResult> CreateActivityAttendance(CreateActivityEnrollerListRequest request)
        {
            try
            {
                var response = await _extraActivityService.CreateActivityListEnroller(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }


        [HttpGet("getActivityAttendance")]
        public async Task<IActionResult> GetEnrollerActivity([FromQuery] GetEnrollerActivityRequest request)
        {
            try
            {
                var response = await _extraActivityService.GetEnrollerActivity(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("takeActivityAttendance")]
        public async Task<IActionResult> TakeActivityAttendance(TakeActivityAttendanceRequest request)
        {
            try
            {
                var response = await _extraActivityService.TakeActivityAttendance(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("registerExtraActivity")]
        public IActionResult RegisterExtraActivity()
        {
            try
            {
                return APIResponse.Success(null);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPut("updateExtraActivityEnroller")]
        public IActionResult UpdateExtraActivityEnroller()
        {
            try
            {
                return APIResponse.Success(null);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }
    }
}
