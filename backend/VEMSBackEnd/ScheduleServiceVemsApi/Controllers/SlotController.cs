using DataAccess.SlotDto;
using Microsoft.AspNetCore.Mvc;
using ScheduleServiceVemsApi.Services;
using SchoolMate.Dto.ApiReponse;

namespace VemsApi.Controllers
{
    [Route("api/slot")]
    [ApiController]
    public class Slotcontroller : ControllerBase
    {

        private readonly IScheduleService scheduleService;

        public Slotcontroller(IScheduleService _scheduleService)
        {
            scheduleService = _scheduleService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllSlot()
        {
            try
            {
                var respone = await scheduleService.GetAllSlot();
                return APIResponse.Success(respone);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Createslot(CreateSlotDto request)
        {
            try
            {
                var respone = await scheduleService.CreateSlot(request);
                return APIResponse.Success(respone);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSlot(UpdateSlotDto request)
        {
            try
            {
                var respone = await scheduleService.UpdateSlot(request);
                return APIResponse.Success(respone);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteSlot(DeleteSlotDto request)
        {
            try
            {
                var respone = await scheduleService.DeleteSlot(request);
                return APIResponse.Success(respone);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

    }
}
