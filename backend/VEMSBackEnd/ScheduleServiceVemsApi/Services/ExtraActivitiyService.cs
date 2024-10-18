using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ScheduleServiceVemsApi.Services
{
    public interface IExtraActivityService
    {
        Task<bool> CreateActivityListEnroller(CreateActivityEnrollerListRequest request);
        Task<bool> TakeActivityAttendance(TakeActivityAttendanceRequest request);
        Task<EnrollerActivityResponse> GetEnrollerActivity(GetEnrollerActivityRequest request);
    }

    public class ExtraActivityService : IExtraActivityService
    {
        private readonly IExtraActivityRepository _extraActivityRepo;

        public ExtraActivityService()
        {
            _extraActivityRepo = new ExtraActivityRepository();
        }

        public async Task<bool> CreateActivityListEnroller(CreateActivityEnrollerListRequest request)
        => await _extraActivityRepo.CreateExtraActivityEnrollerList(request);

        public async Task<EnrollerActivityResponse> GetEnrollerActivity(GetEnrollerActivityRequest request)
        => await _extraActivityRepo.GetEnrollerActivity(request);

        public async Task<bool> TakeActivityAttendance(TakeActivityAttendanceRequest request)
        => await _extraActivityRepo.TakeActivityAttendance(request);
    }


}
