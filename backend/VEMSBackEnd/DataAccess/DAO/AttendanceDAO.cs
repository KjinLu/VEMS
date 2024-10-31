using Azure.Core;
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
                                AccountId = request.AccountInChargeID
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
                            data.UpdateAt = item.TeacherID != null ? DateTime.Now : null;
                            data.UpdateBy = item.TeacherID != null ? request.StudentInchargeName : null;
                            data.TeacherId = item.TeacherID != null ? item.TeacherID : null;
                            data.ReasonId = item.ReasonID != null ? item.ReasonID : null;
                            data.Description = item.Description != null ? item.Description : null;

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
                                                 CreateBy = ats.CreateBy,
                                                 Description = ats.Description,
                                                 ReasonID = ats.ReasonId,
                                                 UpdateAt = ats.UpdateAt,
                                                 UpdateBy = ats.UpdateBy,
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
                            var currentData = context.AttendanceStatuses.SingleOrDefault(i => i.Id == item.AttendanceStatusID);

                            currentData.StatusId = item.StatusID;
                            currentData.UpdateBy = request.UpdateBy;
                            currentData.UpdateAt = request.UpdateAt;
                            currentData.ReasonId = item.ReasonID;
                            currentData.TeacherId = item.TeacherID;
                            currentData.Description = item.Description;

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

        public async Task<List<AttendanceHistoryStudentResponse>> GetHistoryAttendanceFromStudentID(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("ID học sinh không hợp lệ.");
                }
                using (var context = new VemsContext())
                {
                    var attendanceHistoryResponse = await (from attendance in context.Attendances
                                                           join scheduleDetails in context.ScheduleDetails on attendance.ScheduleDetailId equals scheduleDetails.Id
                                                           join sessions in context.Sessions on scheduleDetails.SessionId equals sessions.Id
                                                           join periods in context.Periods on sessions.PeriodID equals periods.Id
                                                           join attendanceStatus in context.AttendanceStatuses on attendance.Id equals attendanceStatus.AttendanceId
                                                           join status in context.Statuses on attendanceStatus.StatusId equals status.Id
                                                           join teacher in context.Teacher on attendanceStatus.TeacherId equals teacher.Id into teacherLeftJoin
                                                           from teacher in teacherLeftJoin.DefaultIfEmpty()
                                                           join reason in context.Reasons on attendanceStatus.ReasonId equals reason.Id into reasonsLeftJoin
                                                           from reason in reasonsLeftJoin.DefaultIfEmpty()
                                                           join student in context.Students on attendanceStatus.StudentId equals student.Id
                                                           where attendanceStatus.StudentId == id
                                                           orderby attendance.TimeReport descending
                                                           select new AttendanceHistoryStudentResponse
                                                           {
                                                               AttendanceStatusID = attendanceStatus.Id,
                                                               DateAttendance = attendance.TimeReport,
                                                               DayOfWeek = sessions.DayOfWeek,
                                                               PeriodName = periods.PeriodName,
                                                               StatusName = status.StatusName,
                                                               ReasonName = reason.ReasonName,
                                                               Description = attendanceStatus.Description,
                                                               StudentCharge = attendanceStatus.CreateBy,
                                                               TeacherCharge = teacher.FullName
                                                           }).AsNoTracking().ToListAsync().ConfigureAwait(false);
                    if (attendanceHistoryResponse == null)
                    {
                        throw new Exception("Không tìm thấy lịch sử điểm danh cho học sinh này.");
                    }

                    return attendanceHistoryResponse;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy lịch sử điểm danh theo Id học sinh: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateAttendanceReport(List<UpdateAttendanceReportRequest> listRequest)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    List<AttendanceStatus> newAttendance = new List<AttendanceStatus>();
                    foreach (var item in listRequest)
                    {
                        var checkAttendanceExist = await context.AttendanceStatuses.FindAsync(item.AttendanceStatusID);

                        if (checkAttendanceExist != null)
                        {
                            checkAttendanceExist.ReasonId = item.ReasonId;
                            checkAttendanceExist.StatusId = item.StatusId;
                            checkAttendanceExist.Description = item.Description;
                            checkAttendanceExist.TeacherId = item.TeacherId;

                            context.Entry<AttendanceStatus>(checkAttendanceExist).State = EntityState.Modified;
                        }
                        else
                        {
                            throw new Exception("Không tìm thấy điểm danh với ID " + item.AttendanceStatusID);
                        }
                    }
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
