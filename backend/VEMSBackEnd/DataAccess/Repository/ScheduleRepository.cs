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
        Task<IEnumerable<Schedule>> GetAllSchedulesAsync();
        Task<IEnumerable<Schedule?>> GetLatestListSchedulesAsync();
        Task<Schedule?> GetLatestSchedulesByClassroomAsync(Guid classroomId);
        Task<IEnumerable<Schedule>> GetSchedulesByClassroomAsync(Guid classroomId);
        Task CreateScheduleAsync(Schedule schedule);
        Task UpdateScheduleAsync(Schedule schedule);
        Task DeleteScheduleAsync(Guid id);
    }

    public class ScheduleRepository : IScheduleRepository
    {
        public async Task<Schedule?> GetScheduleByIdAsync(Guid id)
        {
            return await ScheduleDAO.Instance.GetSchedulesByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
        {
            return await ScheduleDAO.Instance.GetAllScheduleAsync().ConfigureAwait(false);
        }

        public async Task<Schedule?> GetLatestSchedulesByClassroomAsync(Guid classroomId)
        {
            return await ScheduleDAO.Instance.GetLatestSchedulesByClassroomAsync(classroomId).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesByClassroomAsync(Guid classroomId)
        {
            return await ScheduleDAO.Instance.GetListSchedulesByClassAsync(classroomId).ConfigureAwait(false);
        }

        public async Task CreateScheduleAsync(Schedule schedule)
        {
            await ScheduleDAO.Instance.CreateScheduleAsync(schedule).ConfigureAwait(false);
        }

        public async Task UpdateScheduleAsync(Schedule schedule)
        {
            await ScheduleDAO.Instance.UpdateScheduleAsync(schedule).ConfigureAwait(false);
        }

        public async Task DeleteScheduleAsync(Guid id)
        {
            await ScheduleDAO.Instance.DeleteScheduleAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Schedule?>> GetLatestListSchedulesAsync()
        {
            return await ScheduleDAO.Instance.GetLatestListSchedulesAsync().ConfigureAwait(false);

        }
    }
}
