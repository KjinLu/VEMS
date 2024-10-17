using Azure.Core;
using DataAccess.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMate.Dto.ApiReponse;
using System;
using VemsApi.Services;

namespace VemsApi.Controllers
{
    [Route("api/attendance")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet("attendanceStatusOptions")]
        public async Task<IActionResult> AttendanceStatusOptions()
        {
            try
            {

                var response = await _attendanceService.GetAttendanceStatusOptions();
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpGet("attendanceReasonOptions")]
        public async Task<IActionResult> AttendanceReasonOptions()
        {
            try
            {

                var response = await _attendanceService.GetAttendanceReasonOptions();
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpGet("getNeedAttendanceInfo")]
        public async Task<IActionResult> GetAttendanceOfClass([FromQuery] GetClassAttendanceScheduleRequest request)
        {
            try
            {

                var response = await _attendanceService.GetClassAttendanceSchedule(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("takeAttendanceForClass")]
        public async Task<IActionResult> TakeAttendanceForClass(TakeAttendanceRequest request)
        {
            try
            {

                var response = await _attendanceService.TakeAttendance(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpGet("getAttendanceForClass")]
        public async Task<IActionResult> GetAttendanceForClass([FromQuery] GetClassAttendanceRequest request)
        {
            try
            {

                var response = await _attendanceService.GetAttendanceForClass(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }

        [HttpPost("updateAttendanceForClass")]
        public async Task<IActionResult> UpdateAttendanceForClass(UpdateAttendanceRequest request)
        {
            try
            {

                var response = await _attendanceService.UpdateAttendance(request);
                return APIResponse.Success(response);
            }
            catch (Exception ex)
            {
                return APIResponse.Error(null, ex.Message);
            }
        }
    }
}
