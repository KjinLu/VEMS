using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace BusinessObject
{
    public class AttendanceStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime TimeReport { get; set; }

        public Attendance AttendanceId { get; set; }

        [ForeignKey("AttendanceId")]
        public Attendance Attendance { get; set; }

        public Status StatusId { get; set; }

        [ForeignKey("StatusId")]
        public Status Status { get; set; }

        [AllowNull]
        public Reason ReasonId { get; set; }

        [ForeignKey("ReasonId")]
        public Reason Reason { get; set; }

        [AllowNull]
        public Teacher TeacherId { get; set; }

        [ForeignKey("Teacher")]
        public Teacher Teacher { get; set; }


    }
}
