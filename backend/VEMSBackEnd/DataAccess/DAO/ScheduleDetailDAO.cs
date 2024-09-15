using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ScheduleDetailDAO
    {
        private static readonly object InstanceLock = new object();
        private static ScheduleDetailDAO? instance = null;

        public static ScheduleDetailDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ScheduleDetailDAO();
                    }
                    return instance;
                }
            }
        }
        public async Task<IEnumerable<ScheduleDetail>> GetAllScheduleDetailsAsync()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.ScheduleDetails.AsNoTracking().ToListAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching all Schedule Detail: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<ScheduleDetail>> GetAllScheduleDetailByScheduleIdAsync(Guid scheduleId)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.ScheduleDetails.AsNoTracking()
                        .Where(s => s.ScheduleId == scheduleId)
                        .ToListAsync()
                        .ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching latest schedule detail by schedule id: {ex.Message}", ex);
            }
        }

        public async Task<ScheduleDetail?> GetScheduleDetailsByIdAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.ScheduleDetails.FindAsync(id).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching schedule details by id: {ex.Message}", ex);
            }
        }

        public async Task CreateScheduleDetailsAsync(ScheduleDetail scheduleDetail)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    bool exists = await context.ScheduleDetails
                                    .AnyAsync(s => s.ScheduleId == scheduleDetail.ScheduleId && s.SessionId == scheduleDetail.SessionId)
                                    .ConfigureAwait(false);
                    if (exists)
                    {
                        throw new Exception("A schedule detail with the same all values already exists.");
                    }
                    context.ScheduleDetails.Add(scheduleDetail);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while creating the schedule details. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating schedule details: {ex.Message}", ex);
            }
        }

        public async Task UpdateScheduleDetailsAsync(ScheduleDetail scheduleDetail)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var existingScheduleDetails = await context.ScheduleDetails.FindAsync(scheduleDetail.Id).ConfigureAwait(false);

                    if (existingScheduleDetails != null)
                    {
                        if (existingScheduleDetails.ScheduleId != scheduleDetail.ScheduleId ||
                        existingScheduleDetails.SessionId != scheduleDetail.SessionId)
                        {
                            existingScheduleDetails.ScheduleId = scheduleDetail.ScheduleId;
                            existingScheduleDetails.SessionId = scheduleDetail.SessionId;

                            await context.SaveChangesAsync().ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        throw new Exception("Schedule details not found.");
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while updating the schedule details. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating schedule details time: {ex.Message}", ex);
            }
        }

        public async Task DeleteScheduleDetailsAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var existingScheduleDetails = await context.ScheduleDetails.FindAsync(id).ConfigureAwait(false);

                    if (existingScheduleDetails != null)
                    {
                        context.ScheduleDetails.Remove(existingScheduleDetails);

                        await context.SaveChangesAsync().ConfigureAwait(false);
                    }
                    else
                    {
                        throw new Exception("Schedule details not found.");
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while deleting the schedule details. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting schedule details: {ex.Message}", ex);
            }
        }
    }
}
