using BusinessObject;
using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class AttendanceDAO
    {
        private static readonly object InstanceLock = new object();
        private static AttendanceDAO instance = null;

        public static AttendanceDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AttendanceDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<List<SelectOptions>> GetAttendanceStatusOptions()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Statuses.Select(item => new SelectOptions
                    {
                        OptionID = item.Id,
                        OptionName = item.StatusName
                    }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }
        }

        public async Task<List<SelectOptions>> GetAttendanceReasonOptions()
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.Reasons.Select(item => new SelectOptions
                    {
                        OptionID = item.Id,
                        OptionName = item.ReasonName
                    }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }
        }

        public async Task<List<InfomationForAttendance>> GetClassAttendanceSchedule(Guid classID, DateTime attendanceDate)
        {
            try
            {
                var currentDate = attendanceDate != null ? attendanceDate : DateTime.Now;
                var currentDayOfWeek = (int)(currentDate.DayOfWeek);
                var startOfWeek = currentDate.AddDays(-(int)currentDate.DayOfWeek);
                var endOfWeek = startOfWeek.AddDays(7);
                using (var context = new VemsContext())
                {
                    var query = await (from sd in context.ScheduleDetails
                                       join s in context.Schedules on sd.ScheduleId equals s.Id
                                       join cl in context.Classrooms on s.ClassroomId equals cl.Id
                                       join se in context.Sessions on sd.SessionId equals se.Id
                                       join p in context.Periods on se.PeriodID equals p.Id
                                       join at in context.Attendances on sd.Id equals at.ScheduleDetailId into atGroup
                                       from at in atGroup.DefaultIfEmpty() // Left join to include all ScheduleDetails even if no attendance
                                       where s.ClassroomId == classID
                                       group new
                                       {
                                           ClassName = cl.ClassName,
                                           ClassroomID = cl.Id,
                                           DayOfWeek = se.DayOfWeek,
                                           PeriodName = p.PeriodName,
                                           ScheduleDetailID = sd.Id,
                                           Attendance = at,
                                           PeriodID = p.Id
                                       }
                                       by new { se.Id } into g
                                       select new InfomationForAttendance
                                       {
                                           ClassName = g.First().ClassName,
                                           ClassroomID = g.First().ClassroomID,
                                           DayOfWeek = g.First().DayOfWeek,
                                           PeriodName = g.First().PeriodName,
                                           PeriodID = g.First().PeriodID,
                                           AttendanceTime = currentDate.AddDays(g.First().DayOfWeek - currentDayOfWeek),
                                           ScheduleDetailID = g.First().ScheduleDetailID,
                                           IsAttendance = g.Any(x => x.Attendance != null && x.Attendance.TimeReport >= startOfWeek && x.Attendance.TimeReport < endOfWeek)
                                       })
                                       .OrderBy(a => a.DayOfWeek)
                                       .ToListAsync();
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }
        }

        public async Task<bool> TakeAttendanceForClass(TakeAttendanceRequest request)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var checkAttendanceExist = await (from at in context.Attendances
                                                      join sd in context.ScheduleDetails on at.ScheduleDetailId equals sd.Id
                                                      join se in context.Sessions on sd.SessionId equals se.Id
                                                      join p in context.Periods on se.PeriodID equals p.Id
                                                      select new
                                                      {
                                                          ScheduleDetailId = at.ScheduleDetailId,
                                                          TimeReport = at.TimeReport,
                                                          PeriodId = p.Id
                                                      }
                                                      )
                                                .AnyAsync(item => item.ScheduleDetailId == request.ScheduleDetailID
                                                && item.TimeReport.Date == request.Time.Date
                                                && item.PeriodId == request.PeriodID);

                    if (!checkAttendanceExist)
                    {
                        var createdAttendance = context.Attendances.Add(new Attendance
                        {
                            Note = request.Note,
                            ScheduleDetailId = request.ScheduleDetailID,
                            TimeReport = request.Time.Date,
                        }).Entity;


                        await context.AttendanceCharges.AddAsync(
                            new AttendanceCharge
                            {
                                AttendanceId = createdAttendance.Id,
                                StudentId = request.StudentInChargeID
                            });

                        List<AttendanceStatus> newAttendance = new List<AttendanceStatus>();
                        foreach (var item in request.AttendanceData)
                        {
                            var data = new AttendanceStatus();
                            data.StatusId = item.StatusID;
                            data.StudentId = item.StudentID;
                            data.AttendanceId = createdAttendance.Id;
                            data.CreateBy = request.StudentInchargeName;
                            data.CreateAt = DateTime.Now;

                            newAttendance.Add(data);
                        }
                        await context.AttendanceStatuses.AddRangeAsync(newAttendance);
                        await context.SaveChangesAsync();
                        return true;

                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }
        }

        public async Task<ClassAttendanceResponse> GetAttendanceForClass(GetClassAttendanceRequest request)
        {
            try
            {
                ClassAttendanceResponse response = new ClassAttendanceResponse();
                response.ClassID = request.ClassID;
                response.Time = request.Time;
                using (var context = new VemsContext())
                {

                    var attenData = await (from a in context.Attendances
                                           join sd in context.ScheduleDetails on a.ScheduleDetailId equals sd.Id
                                           join s in context.Schedules on sd.ScheduleId equals s.Id
                                           join c in context.Classrooms on s.ClassroomId equals c.Id
                                           where c.Id == request.ClassID && a.TimeReport.Date == request.Time.Date
                                           select new
                                           {
                                               attendanceId = a.Id,
                                               attendanceNote = a.Note
                                           }
                                           ).FirstOrDefaultAsync();

                    var studentData = await (from ats in context.AttendanceStatuses
                                             join a in context.Attendances on ats.AttendanceId equals a.Id
                                             join s in context.Statuses on ats.StatusId equals s.Id
                                             join stu in context.Students on ats.StudentId equals stu.Id
                                             where a.TimeReport.Date == request.Time.Date
                                             select new AttendanceStudentResponse
                                             {
                                                 StatusID = ats.StatusId,
                                                 AttendanceStatusID = ats.Id,
                                                 StudentID = ats.StudentId,
                                                 StatusName = s.StatusName,
                                                 StudentName = stu.FullName,
                                                 StudentCode = stu.PublicStudentID,
                                                 CreateAt = ats.CreateAt,
                                                 CreateBy = ats.CreateBy
                                             }
                                                      ).ToListAsync();
                    response.AttendanceID = attenData.attendanceId;
                    response.Note = attenData.attendanceNote;
                    response.AttendanceData = studentData;
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }
        }

        public async Task<bool> UpdateAttendanceForClass(UpdateAttendanceRequest request)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var checkAttendanceExist = await context.Attendances.SingleOrDefaultAsync(i => i.Id == request.AttendanceID);

                    if (checkAttendanceExist != null)
                    {

                        checkAttendanceExist.Note = request.Note != null ? request.Note.ToString() : checkAttendanceExist.Note;

                        //var existingAttendanceStatuses = context.AttendanceStatuses
                        // .Where(ats => ats.AttendanceId == request.AttendanceID);
                        //context.AttendanceStatuses.RemoveRange(existingAttendanceStatuses);

                        List<AttendanceStatus> newAttendance = new List<AttendanceStatus>();
                        foreach (var item in request.AttendanceData)
                        {
                            var currentData = context.AttendanceStatuses.SingleOrDefault(i => i.Id  == item.AttendanceStatusID);

                            currentData.StatusId = item.StatusID;
                            currentData.UpdateBy = request.UpdateBy;
                            currentData.UpdateAt = request.UpdateAt;
                            currentData.ReasonId = item.ReasonID;
                            currentData.TeacherId = item.TeacherID;
                            
                        context.AttendanceStatuses.Update(currentData);
                        }
                        await context.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        throw new Exception("Không tìm thấy điểm danh với ID " + request.AttendanceID);

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }
        }

    }
}
