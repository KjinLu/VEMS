using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ISessionRepository
    {
        Task<Session?> GetSessionByIdAsync(Guid id);
        Task<IEnumerable<Session>> GetAllSessionsAsync();
        Task<IEnumerable<Session>> GetSessionsByDayOfWeekAsync(int dayOfWeek);
        Task<IEnumerable<Session>> GetSessionsByPeriodIdAsync(Guid periodId);
        Task CreateSessionAsync(Session session);
        Task UpdateSessionAsync(Session session);
        Task DeleteSessionAsync(Guid id);
    }

    public class SessionRepository : ISessionRepository
    {
        public async Task<Session?> GetSessionByIdAsync(Guid id)
        {
            return await SessionDAO.Instance.GetSessionsByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Session>> GetAllSessionsAsync()
        {
            return await SessionDAO.Instance.GetAllSessionAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Session>> GetSessionsByDayOfWeekAsync(int dayOfWeek)
        {
            return await SessionDAO.Instance.GetSessionsByDoWAsync(dayOfWeek).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Session>> GetSessionsByPeriodIdAsync(Guid periodId)
        {
            return await SessionDAO.Instance.GetSessionsByPeriodIdAsync(periodId).ConfigureAwait(false);
        }

        public async Task CreateSessionAsync(Session session)
        {
            await SessionDAO.Instance.CreateSessionAsync(session).ConfigureAwait(false);
        }

        public async Task UpdateSessionAsync(Session session)
        {
            await SessionDAO.Instance.UpdateSessionAsync(session).ConfigureAwait(false);
        }

        public async Task DeleteSessionAsync(Guid id)
        {
            await SessionDAO.Instance.DeleteSessionAsync(id).ConfigureAwait(false);
        }
    }
}
