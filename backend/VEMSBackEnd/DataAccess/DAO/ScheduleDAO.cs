using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class ScheduleDAO
    {
        private static readonly object InstanceLock = new object();
        private static ScheduleDAO? instance = null;

        public static ScheduleDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ScheduleDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<IEnumerable<Schedule>> GetAllScheduleAsync()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Schedules.AsNoTracking().ToListAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching all schedule: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Schedule?>> GetLatestListSchedulesAsync()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Schedules.AsNoTracking()
                        .GroupBy(s => s.ClassroomId)
                        .Select(g => g.OrderByDescending(s => s.Time).FirstOrDefault())
                        .ToListAsync()
                        .ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching latest schedules by classroom: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Schedule>> GetListSchedulesByClassAsync(Guid classroomId)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Schedules.AsNoTracking().Where(s => s.ClassroomId == classroomId).ToListAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching schedule by id: {ex.Message}", ex);
            }
        }

        public async Task<Schedule?> GetSchedulesByIdAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Schedules.FindAsync(id).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching schedule by id: {ex.Message}", ex);
            }
        }

        public async Task<Schedule?> GetLatestSchedulesByClassroomAsync(Guid classroomId)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Schedules.AsNoTracking().OrderByDescending(s => s.Time).FirstOrDefaultAsync(s => s.ClassroomId == classroomId).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching latest schedules by classroom: {ex.Message}", ex);
            }
        }

        public async Task CreateScheduleAsync(Schedule schedule)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    bool exists = await context.Schedules
                                    .AnyAsync(s => s.Time == schedule.Time && s.ClassroomId == schedule.ClassroomId)
                                    .ConfigureAwait(false);
                    if (exists)
                    {
                        throw new Exception("A schedule with the same all values already exists.");
                    }
                    context.Schedules.Add(schedule);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while creating the schedule. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error creating schedule: {ex.Message}", ex);
            }
        }

        public async Task UpdateScheduleAsync(Schedule schedule)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var existingSchedule = await context.Schedules.FindAsync(schedule.Id).ConfigureAwait(false);

                    if (existingSchedule != null)
                    {
                        if (existingSchedule.Time != schedule.Time ||
                        existingSchedule.ClassroomId != schedule.ClassroomId)
                        {
                            existingSchedule.Time = schedule.Time;
                            existingSchedule.ClassroomId = schedule.ClassroomId;

                            await context.SaveChangesAsync().ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        throw new Exception("Schedule not found.");
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while updating the schedule. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating schedule time: {ex.Message}", ex);
            }
        }

        public async Task DeleteScheduleAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var existingSchedule = await context.Schedules.FindAsync(id).ConfigureAwait(false);

                    if (existingSchedule != null)
                    {
                        context.Schedules.Remove(existingSchedule);

                        await context.SaveChangesAsync().ConfigureAwait(false);
                    }
                    else
                    {
                        throw new Exception("Schedule not found.");
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("A concurrency error occurred while deleting the schedule. Please try again.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting schedule: {ex.Message}", ex);
            }
        }
    }
}
