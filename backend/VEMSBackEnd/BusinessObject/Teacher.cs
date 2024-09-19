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
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

 
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string? PublicTeacherID { get; set; }

        [MaxLength(15)]
        [Column(TypeName = "varchar")]
        public string? CitizenID { get; set; } = string.Empty;

        [MaxLength(50)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string Username { get; set; }

        [MaxLength(150)]
        [Column(TypeName = "varchar")]
        [JsonIgnore]
        public string? Password { get; set; } = string.Empty;

        [MaxLength(50)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string FullName { get; set; }

    
        [EmailAddress]
        [MaxLength(256)]
        [Column(TypeName = "nvarchar")]
        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "date")]
        public DateOnly? Dob { get; set; }

        [MaxLength(200)]
        [Column(TypeName = "nvarchar")]
        public string? Address { get; set; }  = string.Empty;

        [MaxLength(150)]
        [Column(TypeName = "nvarchar")]
        public string? Image { get; set; } = string.Empty;

        [MaxLength(10)]
        [Required]
        [Column(TypeName = "varchar")]
        public string Phone { get; set; }

 
        [MaxLength(250)]
        [Column(TypeName = "varchar")]
        [JsonIgnore]
        public string? RefreshToken { get; set; }

        public Guid? TeacherTypeId { get; set; }

        [ForeignKey("TeacherTypeId")]
        public TeacherType? TeacherType { get; set; }
        public Guid RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public ICollection<AttendanceStatus> AttendanceStatuses { get; set; }

        public ICollection<SlotDetail> SlotDetails { get; set; }
    }
}
