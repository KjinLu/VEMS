using DataAccess.DAO;

namespace DataAccess.Repository
{
    public interface IExtraActivityRepository
    {
        public Task<bool> CreateExtraActivityEnrollerList(CreateActivityEnrollerListRequest request);
        public Task<bool> TakeActivityAttendance(TakeActivityAttendanceRequest request);
        public Task<EnrollerActivityResponse> GetEnrollerActivity(GetEnrollerActivityRequest request);
    }

    public class ExtraActivityRepository : IExtraActivityRepository
    {
        public async Task<bool> CreateExtraActivityEnrollerList(CreateActivityEnrollerListRequest request)
        => await ExtraActivityDAO.Instance.CreateActivityEnrollerList(request);

        public async Task<EnrollerActivityResponse> GetEnrollerActivity(GetEnrollerActivityRequest request)
        => await ExtraActivityDAO.Instance.GetEnrollerActivity(request);

        public async Task<bool> TakeActivityAttendance(TakeActivityAttendanceRequest request)
        => await ExtraActivityDAO.Instance.TakeActivityAttendance(request);
    }
}