using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace BusinessObject
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string PublicStudentID { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "nvarchar")]
        public string FullName { get; set; }

        [MaxLength(15)]
        [Column(TypeName = "varchar")]
        public string? CitizenID { get; set; } = string.Empty;

        [MaxLength(50)]
        [Column(TypeName = "nvarchar")]
        public string Username { get; set; } 

        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        [JsonIgnore]
        public string? Password { get; set; } = "1";

        [EmailAddress]
        [MaxLength(256)]
        [Column(TypeName = "nvarchar")]
        public string? Email { get; set; } = string.Empty;

        [Column(TypeName = "date")]
        public DateOnly? Dob { get; set; }

        [MaxLength(200)]
        [Column(TypeName = "nvarchar")]
        public string? Address { get; set; } = string.Empty;

        [MaxLength(150)]
        [Column(TypeName = "nvarchar")]
        public string? Image { get; set; } = string.Empty;

        [MaxLength(10)]
        [Column(TypeName = "varchar")]
        public string? Phone { get; set; } = string.Empty;

        [MaxLength(10)]
        [Column(TypeName = "varchar")]
        public string? ParentPhone { get; set; } = string.Empty;

        [MaxLength(200)]
        [Column(TypeName = "nvarchar")]
        public string? HomeTown { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "varchar")]
        [JsonIgnore]
        public string? RefreshToken { get; set; } = string.Empty;

        [Column(TypeName = "date")]
        public DateOnly? UnionJoinDate { get; set; }

        public Guid? StudentTypeId { get; set; }

        [ForeignKey("StudentTypeId")]
        public StudentType? StudentType { get; set; } 

        public Guid ClassroomId { get; set; }

        [ForeignKey("ClassroomId")]
        public Classroom Classroom { get; set; }

        public Guid RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public ICollection<AttendanceCharge> AttendanceCharges { get; set; }
        public ICollection<AttendanceStatus> AttendanceStatuses { get; set; }
        public ICollection<ExtraActivitiesAttendance> ExtraActivitiesAttendances { get; set; }


    }
}
