using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class AttendanceCharge
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Attendance AttendanceId { get; set; }

        [ForeignKey("AttendanceId")]
        public Attendance Attendance { get; set; }

        public Student StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
