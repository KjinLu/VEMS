using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IScheduleRepository
    {
        Task<Schedule?> GetScheduleByIdAsync(Guid id);
        Task<List<ScheduleResponse>> GetAllSchedulesAsync();
        Task<List<ScheduleResponse>> GetSchedulesByClassroomAsync(Guid classroomId);
        Task<Schedule> CreateScheduleAsync(Schedule schedule);
        Task<List<Schedule>> CreateListScheduleAsync(List<Schedule> schedule);
        Task<bool> UpdateScheduleAsync(Schedule schedule);
        Task<bool> DeleteScheduleAsync(Guid id);
        Task<bool> CreateScheduleDetail(CreateScheduleDetailRequest request);
        Task<ScheduleDetailResponseDto> GetScheduleDetail(Guid scheduleID);
        Task<List<TeacherScheduleResponse>> GetAllTeacherScheduleDetail();
        Task<TeacherScheduleResponse> GetTeacherScheduleDetail(Guid TeacherID);
    }

    public class ScheduleRepository : IScheduleRepository
    {
        public async Task<Schedule> CreateScheduleAsync(Schedule schedule) => await ScheduleDAO.Instance.CreateScheduleAsync(schedule);
        public async Task<List<Schedule>> CreateListScheduleAsync(List<Schedule> schedules) => await ScheduleDAO.Instance.CreateListScheduleAsync(schedules);

        public async Task<bool> CreateScheduleDetail(CreateScheduleDetailRequest request) => await ScheduleDAO.Instance.CreateScheduleDetailAsync(request);

        public async Task<bool> DeleteScheduleAsync(Guid id) => await ScheduleDAO.Instance.DeleteScheduleAsync(id);

        public async Task<List<ScheduleResponse>> GetAllSchedulesAsync() => await ScheduleDAO.Instance.GetAllScheduleAsync();

        public async Task<Schedule?> GetScheduleByIdAsync(Guid id) => await ScheduleDAO.Instance.GetSchedulesByIdAsync(id);

        public async Task<ScheduleDetailResponseDto> GetScheduleDetail(Guid scheduleID) => await ScheduleDAO.Instance.GetScheduleDetails(scheduleID);

        public async Task<List<ScheduleResponse>> GetSchedulesByClassroomAsync(Guid classroomId) => await ScheduleDAO.Instance.GetListSchedulesByClassAsync(classroomId);

        public async Task<bool> UpdateScheduleAsync(Schedule schedule) => await ScheduleDAO.Instance.UpdateScheduleAsync(schedule);

        public async Task<List<TeacherScheduleResponse>> GetAllTeacherScheduleDetail()
            => await ScheduleDAO.Instance.GetAllTeachersSchedules();

        public async Task<TeacherScheduleResponse> GetTeacherScheduleDetail(Guid TeacherID)
         => await ScheduleDAO.Instance.GetTeacherScheduleDetail(TeacherID);
    }
}
