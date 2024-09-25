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

        public async Task<List<ScheduleResponse>> GetAllScheduleAsync()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var query = await (from s in context.Schedules
                                       join c in context.Classrooms on s.ClassroomId equals c.Id
                                       select new ScheduleResponse
                                       {
                                           Id = s.Id,
                                           ClassroomName = c.ClassName,
                                           ClassroomId = s.ClassroomId,
                                           Time = s.Time,
                                       }).AsNoTracking()
                                       .ToListAsync()
                                       .ConfigureAwait(false);
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Có lỗi khi tải danh sách thời khóa biểu", ex);
            }
        }

        // public async Task<List<Schedule?>> GetLatestListSchedulesAsync()
        // {
        //     try
        //     {
        //         using (var context = new VemsContext())
        //         {
        //             return await context.Schedules.AsNoTracking()
        //                 .GroupBy(s => s.ClassroomId)
        //                 .Select(g => g.OrderByDescending(s => s.Time).FirstOrDefault())
        //                 .ToListAsync()
        //                 .ConfigureAwait(false);
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new Exception($"Error fetching latest schedules by classroom: {ex.Message}", ex);
        //     }
        // }

        public async Task<List<ScheduleResponse>> GetListSchedulesByClassAsync(Guid classroomId)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var query = await (from s in context.Schedules
                                       join c in context.Classrooms on s.ClassroomId equals c.Id
                                       where c.Id == classroomId
                                       select new ScheduleResponse
                                       {
                                           Id = s.Id,
                                           ClassroomName = c.ClassName,
                                           ClassroomId = s.ClassroomId,
                                           Time = s.Time,
                                       }).AsNoTracking()
                                     .ToListAsync()
                                     .ConfigureAwait(false);
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Có lỗi khi tải dữ liệu của lớp {classroomId}", ex);
            }
        }

        public async Task<Schedule?> GetSchedulesByIdAsync(Guid id)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var query = await context.Schedules
                                   .FirstOrDefaultAsync(item => item.Id == id)
                                   .ConfigureAwait(false);
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tải thời khóa biểu với ID: {id}", ex);
            }
        }

        // public async Task<Schedule?> GetLatestSchedulesByClassroomAsync(Guid classroomId)
        // {
        //     try
        //     {
        //         using (var context = new VemsContext())
        //         {
        //             return await context.Schedules.AsNoTracking().OrderByDescending(s => s.Time).FirstOrDefaultAsync(s => s.ClassroomId == classroomId).ConfigureAwait(false);
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new Exception($"Error fetching latest schedules by classroom: {ex.Message}", ex);
        //     }
        // }

        public async Task<Schedule> CreateScheduleAsync(Schedule schedule)
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
                        throw new Exception("Thời khóa biểu đã tồn tại!");
                    }
                    var created = context.Schedules.Add(schedule).Entity;
                    await context.SaveChangesAsync().ConfigureAwait(false);
                    return created;
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Có lỗi xảy ra khi tạo thời khóa biểu mới. Thử lại sau", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo thời khóa biểu: ", ex);
            }
        }

        public async Task<bool> UpdateScheduleAsync(Schedule schedule)
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
                        throw new Exception("Không tìm thấy lịch học!");
                    }
                    return true;
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Có lỗi xảy ra khi cập nhật thời khóa biểu. Thử lại sau", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật thời khóa biểu: ", ex);
            }
        }

        public async Task<bool> DeleteScheduleAsync(Guid id)
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
                        return true;
                    }
                    else
                    {
                        throw new Exception("Không tìm thấy lịch học!");
                    }
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Có lỗi xảy ra khi xóa thời khóa biểu. Thử lại sau", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa thời khóa biểu: ", ex);
            }
        }
    }
}
