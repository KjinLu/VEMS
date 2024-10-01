using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class ExtraActivitiesAttendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid AttendanceId { get; set; }

        [ForeignKey("AttendanceId")]
        public Attendance Attendance { get; set; }

        public Guid StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        public Guid StatusId { get; set; }

        [ForeignKey("StatusId")]
        public Status Status { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreateAt { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? AttendanceAt { get; set; }


    }
}
