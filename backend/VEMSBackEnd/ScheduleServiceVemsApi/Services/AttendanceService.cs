using BusinessObject;
using DataAccess.DTO;
using DataAccess.Repository;

namespace ScheduleServiceVemsApi.Services
{
    public interface IAttendanceService
    {
        Task<List<InfomationForAttendance>> GetClassAttendanceSchedule(GetClassAttendanceScheduleRequest request);
        Task<bool> TakeAttendance(TakeAttendanceRequest request);
        Task<bool> UpdateAttendance(UpdateAttendanceRequest request);
        Task<bool> UpdateAttendanceReport(List<UpdateAttendanceReportRequest> request);
        Task<List<AttendanceHistoryStudentResponse>> GetHistoryAttendanceFromStudentID(Guid id);

        Task<ClassAttendanceResponse> GetAttendanceForClass(GetClassAttendanceRequest request);
        Task<List<SelectOptions>> GetAttendanceReasonOptions();
        Task<List<SelectOptions>> GetAttendanceStatusOptions();
    }
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository attendanceRepository;
        public AttendanceService()
        {
            attendanceRepository = new AttendanceRepository();
        }

        public async Task<ClassAttendanceResponse> GetAttendanceForClass(GetClassAttendanceRequest request)
        {
            return await attendanceRepository.GetAttendanceForClass(request);
        }

        public async Task<List<InfomationForAttendance>> GetClassAttendanceSchedule(GetClassAttendanceScheduleRequest request)
        {
            return await attendanceRepository.GetClassAttendanceSchedule(request.ClassID, request.Time);
        }

        public async Task<List<SelectOptions>> GetAttendanceReasonOptions()
        {
            return await attendanceRepository.GetAttendanceReasonOptions();
        }

        public async Task<List<SelectOptions>> GetAttendanceStatusOptions()
        {
            return await attendanceRepository.GetAttendanceStatusOptions();
        }

        public async Task<bool> TakeAttendance(TakeAttendanceRequest request)
        {
            return await attendanceRepository.TakeAttendance(request);
        }

        public async Task<bool> UpdateAttendance(UpdateAttendanceRequest request)
        {
            return await attendanceRepository.UpdateAttenndance(request);

        }

        public async Task<bool> UpdateAttendanceReport(List<UpdateAttendanceReportRequest> request)
        {
            return await attendanceRepository.UpdateAttendanceReport(request);
        }

        public async Task<List<AttendanceHistoryStudentResponse>> GetHistoryAttendanceFromStudentID(Guid id)
        {
            return await attendanceRepository.GetHistoryAttendanceFromStudentID(id);
        }
    }
}
