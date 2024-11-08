﻿using Azure.Core;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                                       group s by new { s.ClassroomId, c.ClassName } into g
                                       select new ScheduleResponse
                                       {
                                           Id = g.OrderByDescending(s => s.Time).FirstOrDefault().Id,
                                           ClassroomName = g.Key.ClassName,
                                           ClassroomId = g.Key.ClassroomId,
                                           Time = g.OrderByDescending(s => s.Time).FirstOrDefault().Time,
                                       }).AsNoTracking()
                                       .ToListAsync()
                                       .ConfigureAwait(false);
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Có lỗi khi tải danh sách thời khóa biểu" + ex.Message);
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
        //         throw new Exception($"Error fetching latest schedules by classroom: {ex.Message}"+ ex.Message);
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
                                       group s by new { s.ClassroomId, c.ClassName } into g
                                       select new ScheduleResponse
                                       {
                                           Id = g.OrderByDescending(s => s.Time).FirstOrDefault().Id,
                                           ClassroomName = g.Key.ClassName,
                                           ClassroomId = g.Key.ClassroomId,
                                           Time = g.OrderByDescending(s => s.Time).FirstOrDefault().Time,
                                       }).AsNoTracking()
                                       .ToListAsync()
                                       .ConfigureAwait(false);
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Có lỗi khi tải dữ liệu của lớp {classroomId}" + ex.Message);
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
                throw new Exception($"Lỗi khi tải thời khóa biểu với ID: {id}" + ex.Message);
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
        //         throw new Exception($"Error fetching latest schedules by classroom: {ex.Message}"+ ex.Message);
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
                throw new Exception("Có lỗi xảy ra khi tạo thời khóa biểu mới. Thử lại sau! " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo thời khóa biểu: " + ex.Message);
            }
        }

        public async Task<List<Schedule>> CreateListScheduleAsync(List<Schedule> schedules)
        {
            var createdSchedules = new List<Schedule>();

            try
            {
                using (var context = new VemsContext())
                {
                    foreach (var schedule in schedules)
                    {
                        bool exists = await context.Schedules
                                            .AnyAsync(s => s.Time == schedule.Time && s.ClassroomId == schedule.ClassroomId)
                                            .ConfigureAwait(false);
                        if (!exists)
                        {
                            var created = context.Schedules.Add(schedule).Entity;
                            createdSchedules.Add(created);
                        }
                    }

                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Có lỗi xảy ra khi tạo thời khóa biểu mới. Thử lại sau! " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo thời khóa biểu: " + ex.Message);
            }

            return createdSchedules;
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
                throw new Exception("Có lỗi xảy ra khi cập nhật thời khóa biểu. Thử lại sau" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật thời khóa biểu: " + ex.Message);
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
                throw new Exception("Có lỗi xảy ra khi xóa thời khóa biểu. Thử lại sau" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa thời khóa biểu: " + ex.Message);
            }
        }

        public async Task<bool> CreateScheduleDetailAsync(CreateScheduleDetailRequest request)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var existingSchedule = context.ScheduleDetails.Any(i => i.ScheduleId == request.ScheduleID);


                    if (!existingSchedule)
                    {
                        var scheduleInfo = await (from s in context.Schedules
                                                  join c in context.Classrooms on s.ClassroomId equals c.Id
                                                  where s.Id == request.ScheduleID
                                                  select new
                                                  {
                                                      scheduleID = s.Id,
                                                      time = s.Time,
                                                      classroomId = c.Id,
                                                      className = c.ClassName
                                                  }
                                           ).FirstOrDefaultAsync();
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
                                    TeacherID = session.TeacherID != null ? session.TeacherID : null,
                                    ClassroomID = scheduleInfo.classroomId
                                };
                                slotDetails.Add(newSlot);
                            }
                            ScheduleDetail newScheduleDetail = new ScheduleDetail();
                            newScheduleDetail.SessionId = currentSessionID;
                            newScheduleDetail.ScheduleId = request.ScheduleID;


                            var newScheduleDetailCreated = context.ScheduleDetails.Add(newScheduleDetail).Entity;

                            var sessionTime = await (from s in context.Sessions
                                                     join p in context.Periods on s.PeriodID equals p.Id
                                                     where s.Id == currentSessionID
                                                     select new
                                                     {
                                                         PeriodName = p.PeriodName,
                                                         Time = p.StartTime
                                                     }).FirstOrDefaultAsync();
                            context.SlotDetails.AddRange(slotDetails);
                        }
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Đã tồn tại thời khóa biểu chi tiết!");
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo thời khóa biểu chi tiết: " + ex.Message);
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
                                                                              join te in context.Teacher on sd.TeacherID equals te.Id into teacherLeftJoin
                                                                              from te in teacherLeftJoin.DefaultIfEmpty()
                                                                              join so in context.Slots on sd.SlotID equals so.Id
                                                                              join scd in context.ScheduleDetails on se.Id equals scd.SessionId
                                                                              join sc in context.Schedules on scd.ScheduleId equals sc.Id
                                                                              join c in context.Classrooms on sc.ClassroomId equals c.Id

                                                                              where sd.SessionID == item.SessionId && sd.ClassroomID == scheduleInfo.classroomId
                                                                              select new SlotDetailResponse
                                                                              {
                                                                                  SlotID = so.Id,
                                                                                  SlotIndex = so.SlotIndex,
                                                                                  SubjectID = su.Id,
                                                                                  SubjectName = su.SubjectName,
                                                                                  TeacherID = sd.TeacherID != null ? te.Id : null,
                                                                                  TeacherName = sd.TeacherID != null ? te.FullName : "",
                                                                                  SlotStart = so.StartTime,
                                                                                  SlotEnd = so.EndTime,

                                                                              }).Distinct().OrderBy(x => x.SlotIndex).ToListAsync();
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
                throw new Exception($"Lỗi khi tải thời khóa biểu: " + ex.Message);
            }
        }

        public async Task<List<TeacherScheduleResponse>> GetAllTeachersSchedules()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var teachers = await context.Teacher.ToListAsync();

                    List<TeacherScheduleResponse> allSchedules = new List<TeacherScheduleResponse>();

                    foreach (var teacher in teachers)
                    {
                        var schedule = await GetTeacherScheduleDetail(teacher.Id);
                        allSchedules.Add(schedule);
                    }

                    return allSchedules;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tải danh sách thời khóa biểu: " + ex.Message);
            }
        }

        public async Task<TeacherScheduleResponse> GetTeacherScheduleDetail(Guid TeacherID)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var query = from slotDetail in context.SlotDetails
                                join t in context.Teacher on slotDetail.TeacherID equals t.Id
                                join s in context.Subjects on slotDetail.SubjectID equals s.Id
                                join slot in context.Slots on slotDetail.SlotID equals slot.Id
                                join se in context.Sessions on slotDetail.SessionID equals se.Id
                                join p in context.Periods on se.PeriodID equals p.Id
                                join c in context.Classrooms on slotDetail.ClassroomID equals c.Id
                                where t.Id == TeacherID
                                select new
                                {
                                    t.FullName,
                                    c.ClassName,
                                    ClassroomID = c.Id,
                                    SubjectID = s.Id,
                                    s.SubjectName,
                                    SlotID = slot.Id,
                                    slot.SlotIndex,
                                    slot.StartTime,
                                    slot.EndTime,
                                    se.DayOfWeek,
                                    p.PeriodName
                                };

                    var result = await query.ToListAsync();

                    var sessionDetails = result.GroupBy(r => new { r.DayOfWeek, r.PeriodName })
                                               .Select(g => new TeacherSesionDetailResponse
                                               {
                                                   DayOfWeek = g.Key.DayOfWeek,
                                                   PeriodName = g.Key.PeriodName,
                                                   SlotDetails = g.Select(s => new TeacherSlotDetailResponse
                                                   {
                                                       SubjectID = s.SubjectID,
                                                       SubjectName = s.SubjectName,
                                                       SlotID = s.SlotID,
                                                       Classname = s.ClassName,
                                                       ClassroomID = s.ClassroomID,
                                                       SlotIndex = s.SlotIndex,
                                                       SlotStart = s.StartTime,
                                                       SlotEnd = s.EndTime,
                                                   }).ToList()
                                               }).ToList();

                    var response = new TeacherScheduleResponse
                    {
                        TeacherID = TeacherID,
                        TeacherName = result.FirstOrDefault()?.FullName,
                        Sessions = sessionDetails
                    };

                    return response;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tải thời khóa biểu: " + ex.Message);
            }
        }

        //public async Task<bool> CreateTeacherSchedule(List<CreateTeacherScheduleRequest> request)
        //{
        //    try
        //    {
        //        using (var context = new VemsContext())
        //        {
        //            foreach (var req in request)
        //            {
        //                var currentSlot = context.SlotDetails.
        //                    FirstOrDefault(item => item.SlotID == req.SlotID && item.SessionID == req.SessionID && item.ClassroomID==req.ClassID && item.SubjectID == req.SubjectID);
        //                if (currentSlot != null)
        //                {
        //                    currentSlot.TeacherID = req.TeacherID;  
        //                    context.Entry<SlotDetail>(currentSlot).State = EntityState.Modified;
        //                }

        //            }

        //            context.SaveChanges();
        //            return true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Có lỗi khi tạo thời khóa biểu cho giáo viên: " + ex.Message);
        //    }
        //}

        public async Task<bool> CreateTeacherSchedule(List<CreateTeacherScheduleRequest> requestList)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    // Retrieve all relevant SlotDetails in one query to minimize database calls.
                    var slotIds = requestList.Select(r => r.SlotID).Distinct().ToList();
                    var sessionIds = requestList.Select(r => r.SessionID).Distinct().ToList();
                    var classIds = requestList.Select(r => r.ClassID).Distinct().ToList();
                    var subjectIds = requestList.Select(r => r.SubjectID).Distinct().ToList();

                    var existingSlotDetails = context.SlotDetails
                        .Where(sd => slotIds.Contains(sd.SlotID)
                                     && sessionIds.Contains(sd.SessionID)
                                     && classIds.Contains(sd.ClassroomID)
                                     && subjectIds.Contains(sd.SubjectID))
                        .ToList();

                    foreach (var req in requestList)
                    {
                        // Find the SlotDetail based on matching IDs
                        var currentSlot = existingSlotDetails
                            .FirstOrDefault(sd => sd.SlotID == req.SlotID
                                                  && sd.SessionID == req.SessionID
                                                  && sd.ClassroomID == req.ClassID
                                                  && sd.SubjectID == req.SubjectID);

                        if (currentSlot != null)
                        {
                            // Update only if the teacher is not already assigned to avoid unnecessary modifications
                            if (currentSlot.TeacherID != req.TeacherID)
                            {
                                currentSlot.TeacherID = req.TeacherID;
                                context.Entry(currentSlot).State = EntityState.Modified;
                            }
                        }
                    }

                    // Save changes after all updates
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi khi tạo thời khóa biểu cho giáo viên: " + ex.Message);
            }
        }

    }
}