using DataAccess.DAO;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IAttendanceRepository
    {
        Task<List<InfomationForAttendance>> GetClassAttendanceSchedule(Guid classID, DateTime currentTime);
        Task<bool> TakeAttendance(TakeAttendanceRequest request);
        Task<bool> UpdateAttenndance(UpdateAttendanceRequest request);
        Task<ClassAttendanceResponse> GetAttendanceForClass(GetClassAttendanceRequest request);
        Task<List<SelectOptions>> GetAttendanceStatusOptions();
        Task<List<SelectOptions>> GetAttendanceReasonOptions();

    }

    public class AttendanceRepository : IAttendanceRepository
    {
        public async Task<ClassAttendanceResponse> GetAttendanceForClass(GetClassAttendanceRequest request)
            => await AttendanceDAO.Instance.GetAttendanceForClass(request);

        public async Task<List<InfomationForAttendance>> GetClassAttendanceSchedule(Guid classID, DateTime attendanceDate)
            => await AttendanceDAO.Instance.GetClassAttendanceSchedule(classID, attendanceDate);

        public async Task<List<SelectOptions>> GetAttendanceReasonOptions()
                   => await AttendanceDAO.Instance.GetAttendanceReasonOptions();

        public async Task<List<SelectOptions>> GetAttendanceStatusOptions()
                   => await AttendanceDAO.Instance.GetAttendanceStatusOptions();

        public async Task<bool> TakeAttendance(TakeAttendanceRequest request)
            => await AttendanceDAO.Instance.TakeAttendanceForClass(request);

        public async Task<bool> UpdateAttenndance(UpdateAttendanceRequest request)
                   => await AttendanceDAO.Instance.UpdateAttendanceForClass(request);

    }
}
