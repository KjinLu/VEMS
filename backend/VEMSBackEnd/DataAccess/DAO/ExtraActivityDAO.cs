using Azure.Core;
using BusinessObject;
using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccess.DAO
{


    public class ExtraActivityDAO
    {
        private static readonly object InstanceLock = new object();
        private static ExtraActivityDAO instance = null;

        public static ExtraActivityDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ExtraActivityDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<bool> CreateActivityEnrollerList(CreateActivityEnrollerListRequest request)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var checkAttendance = await context.Attendances.SingleOrDefaultAsync(item =>
                    item.ScheduleDetailId == null &&
                     item.TimeReport.Date == request.ActivityTime.Date &&
                     item.Note == request.ActivityNote);
                    if (checkAttendance == null)
                    {
                        var attendanceCreated = context.Attendances.Add(new Attendance
                        {
                            Note = request.ActivityNote,
                            TimeReport = request.ActivityTime,
                        }).Entity;
                        var status = context.Statuses.SingleOrDefault(item => item.Code == "NOT_MARKED");


                        var newListEnrollers = new List<ExtraActivitiesAttendance>();

                        foreach (var student in request.StudentIDs)
                        {
                            var newItem = new ExtraActivitiesAttendance
                            {
                                AttendanceId = attendanceCreated.Id,
                                StudentId = student,
                                StatusId = status.Id,
                                CreateAt = DateTime.Now

                            };
                            newListEnrollers.Add(newItem);
                        }

                        await context.ExtraActivitiesAttendances.AddRangeAsync(newListEnrollers);

                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Đã tồn tại lịch tương tự!");
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra khi tạo lịch điểm danh mới: " + e.Message);
            }
        }
        public async Task<bool> TakeActivityAttendance(TakeActivityAttendanceRequest request)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var attendanceExists = await context.ExtraActivitiesAttendances
                        .AnyAsync(item => item.AttendanceId == request.AttendanceId);

                    if (!attendanceExists)
                    {
                        throw new Exception("Không tìm thấy lịch điểm danh!");
                    }

                    foreach (var at in request.attendanceData)
                    {
                        var item = await context.ExtraActivitiesAttendances
                            .SingleOrDefaultAsync(e => e.Id == at.AttendanceActivityId);

                        if (item != null)
                        {
                            item.StatusId = at.StatusId;
                        }
                    }

                    await context.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Có lỗi xảy ra khi tạo điểm danh mới: " + e.Message);
            }
        }

        public async Task<EnrollerActivityResponse> GetEnrollerActivity(GetEnrollerActivityRequest request)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var response = new EnrollerActivityResponse();
                    var attendanceExists = await (from ex in context.ExtraActivitiesAttendances 
                                                  join a in context.Attendances on ex.AttendanceId equals a.Id
                                                  join s in context.Students on ex.StudentId equals s.Id
                                                  join st in context.Statuses on ex.StatusId equals st.Id
                                                  where a.TimeReport.Date == request.ActivityDate.Date && a.ScheduleDetailId == null
                                                  select new {ex.Id, ex.StatusId,ex.AttendanceId, a.Note, s.FullName,st.StatusName}
                                                  ).ToListAsync();

                    

                    var students = new List<StudentAttendance>();

                    foreach (var attendance in attendanceExists)
                    {
                        students.Add(new StudentAttendance() 
                        { AttendanceActivityId = attendance.Id, StatusId = attendance.StatusId,
                            StatusName=attendance.StatusName, StudentName=attendance.FullName });
                    }

                    response.ActivityDate = request.ActivityDate;
                    response.AttendanceId = attendanceExists.First().AttendanceId;
                    response.Note = attendanceExists.First().Note;
                    response.students = students;

                    return response;
                }
            }
            catch (Exception e) { 
                throw new Exception("Có lỗi xảy ra khi tải lịch điểm danh: " + e.Message);
            }
        }
    }
}