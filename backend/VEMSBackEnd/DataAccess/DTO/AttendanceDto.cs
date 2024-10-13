using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class GetClassAttendanceScheduleRequest
    {
        public Guid ClassID { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
    }

    public class TakeAttendanceRequest
    {
        public Guid ClassID { get; set; }
        public DateTime Time { get; set; }
        public string? Note { get; set; } = "";
        public Guid ScheduleDetailID { get; set; }
        public Guid StudentInChargeID { get; set; }
        public Guid PeriodID { get; set; }
        public string StudentInchargeName { get; set; }
        public List<AttendanceStudent> AttendanceData { get; set; }

    }

    public class AttendanceStudent
    {
        public Guid StudentID { get; set; }
        public Guid StatusID { get; set; }
    }


    public class UpdateAttendanceRequest
    {
        public Guid AttendanceID { get; set; }
        public DateTime Time { get; set; }
        public string? Note { get; set; } = "";
        public string UpdateBy { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public List<UpdateAttendanceStudent> AttendanceData { get; set; }

    }

    public class UpdateAttendanceStudent
    {
        public Guid AttendanceStatusID { get; set; }
        public Guid StatusID { get; set; }
        public Guid? TeacherID { get; set; }
        public Guid? ReasonID { get; set; }

    }


    public class GetClassAttendanceRequest
    {
        public Guid ClassID { get; set; }
        public DateTime Time { get; set; }

    }

    public class ClassAttendanceResponse
    {
        public Guid ClassID { get; set; }
        public Guid AttendanceID { get; set; }
        public DateTime Time { get; set; }
        public List<AttendanceStudentResponse> AttendanceData { get; set; }
    }

    public class AttendanceStudentResponse
    {
        public Guid AttendanceStatusID { get; set; }
        public Guid StudentID { get; set; }
        public Guid StatusID { get; set; }
        public string StatusName { get; set; }
        public string StudentName { get; set; }
        public string StudentCode { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
    }

}
