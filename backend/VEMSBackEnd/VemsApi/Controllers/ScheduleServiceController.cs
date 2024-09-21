using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Dto.ApiReponse;
using VemsApi.Dto.ScheduleDto;
using VemsApi.Services;

namespace VemsApi.Controllers
{
    [Route("api/schedule-service")]
    [ApiController]
    public class ScheduleServiceController : ControllerBase
    {
   
        private readonly IScheduleService scheduleService;

        public ScheduleServiceController(IScheduleService _scheduleService)
        {
            scheduleService = _scheduleService;
        }

        [HttpPost("create-new-schedule")]
        public IActionResult CreateSchedule(CreateScheduleDto request)
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

        [HttpPut("update-schedule")]
        public IActionResult UpdateSchedule(UpdateScheduleDto request)
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

        [HttpPut("delete-schedule")]
        public IActionResult DeleteSchedule(DeleteSchedule request)
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
