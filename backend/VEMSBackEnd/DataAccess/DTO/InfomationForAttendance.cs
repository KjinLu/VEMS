using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class InfomationForAttendance
    {
        public DateTime AttendanceTime { get; set; }
        public Guid ClassroomID { get; set; }
        public string ClassName { get; set; }
        public string PeriodName { get; set; }
        public int DayOfWeek { get; set; }

    }
}
