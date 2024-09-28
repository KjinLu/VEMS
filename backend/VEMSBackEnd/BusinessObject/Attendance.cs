using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "time")]
        public TimeOnly StartTime { get; set; }

        public string Note { get; set; }

        public Guid? ScheduleDetailId { get; set; }

        [ForeignKey("ScheduleDetailId")]
        public ScheduleDetail? ScheduleDetail  { get; set; }

        public ICollection<AttendanceCharge> AttendanceCharges { get; set; }
        public ICollection<AttendanceStatus> AttendanceStatuses { get; set; }

    }
}
