﻿using System;
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

        public Guid AttendanceId { get; set; }

        [ForeignKey("AttendanceId")]
        public Attendance Attendance { get; set; }

        public Guid StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        public Guid StatusId { get; set; }

        [ForeignKey("StatusId")]
        public Status Status { get; set; }

        public Guid? ReasonId { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [ForeignKey("ReasonId")]
        public Reason? Reason { get; set; }

        public Guid? TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public Teacher? Teacher { get; set; }

        public string CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }


    }
}
