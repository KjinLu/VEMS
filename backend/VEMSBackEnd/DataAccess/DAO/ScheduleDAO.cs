using Azure.Core;
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

        public async Task<bool> CreateScheduleDetailAsync(CreateScheduleDetailRequest request)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var existingSchedule = await context.Schedules.FindAsync(request.ScheduleID).ConfigureAwait(false);

                    if (existingSchedule != null)
                    {
                        foreach (var item in request.Sessions)
                        {
                            Guid currentSessionID = item.SessionID;
                            List<SlotDetail> slotDetails = new List<SlotDetail>();
                            foreach (var session in item.SlotDetails)
                            {
                                SlotDetail newSlot = new SlotDetail
                                {
                                    SessionID = currentSessionID,
                                    SlotID = session.SlotID,
                                    SubjectID = session.SubjectID,
                                    TeacherID = session.TeacherID,
                                };
                                slotDetails.Add(newSlot);
                            }
                            ScheduleDetail newScheduleDetail = new ScheduleDetail();
                            newScheduleDetail.SessionId = currentSessionID;
                            newScheduleDetail.ScheduleId = request.ScheduleID;


                            var  newScheduleDetailCreated = context.ScheduleDetails.Add(newScheduleDetail).Entity;

                            var sessionTime = await (from s in context.Sessions
                                                     join p in context.Periods on s.PeriodID equals p.Id
                                                     where s.Id == currentSessionID
                                                     select new
                                                     {
                                                         PeriodName = p.PeriodName,
                                                         Time = p.StartTime
                                                     }).FirstOrDefaultAsync();
                            Attendance newAttendance = new Attendance();
                            newAttendance.ScheduleDetailId = newScheduleDetailCreated.Id;
                            newAttendance.Note = "";
                            newAttendance.StartTime = sessionTime.Time;

                            context.Attendances.Add(newAttendance);
                            context.SlotDetails.AddRange(slotDetails);
                        }
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Không tìm thấy thời khóa biểu!");
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo thời khóa biểu chi tiết: ", ex);
            }
        }

        public async Task<ScheduleDetailResponseDto> GetScheduleDetails(Guid scheduleId)
        {
            try
            {
                ScheduleDetailResponseDto response = new ScheduleDetailResponseDto();
                using (var context = new VemsContext())
                {
                    var existingSchedule = await context.Schedules.FindAsync(scheduleId).ConfigureAwait(false);

                    if (existingSchedule != null)
                    {
                       var scheduleInfo = await (from s in context.Schedules
                                           join c in context.Classrooms on s.ClassroomId equals c.Id
                                           where s.Id == scheduleId
                                           select new
                                           {
                                               scheduleID = s.Id,
                                               time = s.Time,
                                               classroomId = c.Id,
                                               className = c.ClassName
                                           }
                                           ).FirstOrDefaultAsync();


                        var sessionQuery = await context.ScheduleDetails
                                .Where(sd => sd.ScheduleId == scheduleId)
                                .ToListAsync();

                        List<SesionDetailResponse> sessionResponse = new List<SesionDetailResponse>();

                        foreach (var item in sessionQuery)
                        {
                            SesionDetailResponse newSession = new SesionDetailResponse();

                            var sessionDetailQuerry = await (from se in context.Sessions
                                                             join p in context.Periods on se.PeriodID equals p.Id
                                                             where se.Id == item.SessionId
                                                             select new
                                                             {
                                                                 sessionID = se.Id,
                                                                 DayOfWeek = se.DayOfWeek,
                                                                 PeriodName = p.PeriodName,
                                                             }).FirstOrDefaultAsync();

                            List<SlotDetailResponse> slotDetailQuery = await (from sd in context.SlotDetails
                                                                              join se in context.Sessions on sd.SessionID equals se.Id
                                                                              join su in context.Subjects on sd.SubjectID equals su.Id
                                                                              join te in context.Teacher on sd.TeacherID equals te.Id
                                                                              join so in context.Slots on sd.SlotID equals so.Id
                                                                              where sd.SessionID == item.SessionId
                                                                              select new SlotDetailResponse
                                                                              {
                                                                                  SlotID = so.Id,
                                                                                  SlotIndex = so.SlotIndex,
                                                                                  SubjectID = su.Id,
                                                                                  SubjectName = su.SubjectName,
                                                                                  TeacherID = te.Id,
                                                                                  TeacherName = te.FullName,
                                                                                  SlotStart = so.StartTime,
                                                                                  SlotEnd = so.EndTime,

                                                                              }).ToListAsync();
                            newSession.SessionID = sessionDetailQuerry.sessionID;
                            newSession.PeriodName = sessionDetailQuerry.PeriodName;
                            newSession.DayOfWeek = sessionDetailQuerry.DayOfWeek;
                            newSession.SlotDetails = slotDetailQuery;
                            sessionResponse.Add(newSession);
                        }


                        // Binding data to response
                        response.ScheduleId = scheduleInfo.scheduleID;
                        response.Time = scheduleInfo.time;
                        response.ClassName = scheduleInfo.className;
                        response.ClassroomID = scheduleInfo.classroomId;
                        response.Sessions = sessionResponse.OrderBy(i => i.DayOfWeek).ToList();
                    }
                    else
                    {
                        throw new Exception("Không tìm thấy thời khóa biểu!");
                    }
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tải thời khóa biểu: ", ex);
            }
        }
    }
}
