﻿using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Dto.ApiReponse;
using VemsApi.Dto.PaginationDto;
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

        [HttpGet("get-all-schedule")]
        public async Task<IActionResult> GetAllSchedule([FromQuery] PaginationRequest request)
        {
            try
            {
                var response = await scheduleService.GetAllSchedule(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpGet("get-class-schedule")]
        public async Task<IActionResult> GetScheduleOfClass(Guid classID)
        {
            try
            {
                var response = await scheduleService.GetAllScheduleOfClass(classID);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("create-new-schedule")]
        public async Task<IActionResult> CreateSchedule(CreateScheduleDto request)
        {
            try
            {
                var response = await scheduleService.CreateSchedule(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPut("update-schedule")]
        public async Task<IActionResult> UpdateSchedule(UpdateScheduleDto request)
        {
            try
            {
                var response = await scheduleService.UpdateSchedule(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpDelete("delete-schedule")]
        public async Task<IActionResult> DeleteSchedule(DeleteSchedule request)
        {
            try
            {
                var response = await scheduleService.DeleteSchedule(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        //public Task<IActionResult> C


    }
}
