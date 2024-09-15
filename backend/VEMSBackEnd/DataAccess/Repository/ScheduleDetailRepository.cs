using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IScheduleDetailRepository
    {
        Task<IEnumerable<ScheduleDetail>> GetAllScheduleDetailsAsync();
        Task<IEnumerable<ScheduleDetail>> GetAllScheduleDetailByScheduleIdAsync(Guid scheduleId);
        Task<ScheduleDetail?> GetScheduleDetailsByIdAsync(Guid id);
        Task CreateScheduleDetailsAsync(ScheduleDetail scheduleDetail);
        Task UpdateScheduleDetailsAsync(ScheduleDetail scheduleDetail);
        Task DeleteScheduleDetailsAsync(Guid id);
    }

    public class ScheduleDetailRepository : IScheduleDetailRepository
    {
        public async Task CreateScheduleDetailsAsync(ScheduleDetail scheduleDetail)
        {
            await ScheduleDetailDAO.Instance.CreateScheduleDetailsAsync(scheduleDetail).ConfigureAwait(false);
        }

        public async Task DeleteScheduleDetailsAsync(Guid id)
        {
            await ScheduleDetailDAO.Instance.DeleteScheduleDetailsAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ScheduleDetail>> GetAllScheduleDetailByScheduleIdAsync(Guid scheduleId)
        {
            return await ScheduleDetailDAO.Instance.GetAllScheduleDetailByScheduleIdAsync(scheduleId).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ScheduleDetail>> GetAllScheduleDetailsAsync()
        {
            return await ScheduleDetailDAO.Instance.GetAllScheduleDetailsAsync().ConfigureAwait(false);
        }

        public async Task<ScheduleDetail?> GetScheduleDetailsByIdAsync(Guid id)
        {
            return await ScheduleDetailDAO.Instance.GetScheduleDetailsByIdAsync(id).ConfigureAwait(false);
        }

        public async Task UpdateScheduleDetailsAsync(ScheduleDetail scheduleDetail)
        {
            await ScheduleDetailDAO.Instance.UpdateScheduleDetailsAsync(scheduleDetail).ConfigureAwait(false);
        }
    }
}
