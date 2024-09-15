using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class SessionDAO
    {
        private static readonly object InstanceLock = new object();
        private static SessionDAO? instance = null;

        public static SessionDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SessionDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<IEnumerable<Session>> GetAllSessionAsync()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Sessions.AsNoTracking().ToListAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching all sessions: {ex.Message}", ex);
            }
        }

        public async Task<Session?> GetSessionsByIdAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Sessions.FindAsync(id).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching sessions by Id: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Session>> GetSessionsByDoWAsync(int dow)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Sessions.AsNoTracking().Where(s => s.DayOfWeek == dow).ToListAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching sessions by day of weeks: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Session>> GetSessionsByPeriodIdAsync(Guid periodId)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Sessions.AsNoTracking().Where(s => s.PeriodID == periodId).ToListAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching sessions by Id: {ex.Message}", ex);
            }
        }

        public async Task CreateSessionAsync(Session session)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    bool exists = await context.Sessions.AnyAsync(s => s.DayOfWeek == session.DayOfWeek && s.PeriodID == session.PeriodID).ConfigureAwait(false);
                    if (exists)
                    {
                        throw new Exception("A slot with the same all values already exists.");
                    }
                    context.Sessions.Add(session);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while creating the slot. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating Slot: {ex.Message}", ex);
            }
        }

        public async Task UpdateSessionAsync(Session session)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var existingSession = await context.Sessions.FindAsync(session.Id).ConfigureAwait(false);

                    if (existingSession != null)
                    {
                        if (existingSession.DayOfWeek != session.DayOfWeek ||
                        existingSession.PeriodID != session.PeriodID)
                        {
                            existingSession.DayOfWeek = session.DayOfWeek;
                            existingSession.PeriodID = session.PeriodID;

                            await context.SaveChangesAsync().ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        throw new Exception("Session not found.");
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while updating the session. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating session time: {ex.Message}", ex);
            }
        }

        public async Task DeleteSessionAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var existingSession = await context.Sessions.FindAsync(id).ConfigureAwait(false);

                    if (existingSession != null)
                    {
                        context.Sessions.Remove(existingSession);

                        await context.SaveChangesAsync().ConfigureAwait(false);
                    }
                    else
                    {
                        throw new Exception("Session not found.");
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while deleting the session. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting Session: {ex.Message}", ex);
            }
        }
    }
}
