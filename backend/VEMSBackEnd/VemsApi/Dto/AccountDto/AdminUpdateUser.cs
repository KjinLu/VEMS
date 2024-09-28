using BusinessObject;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VemsApi.Dto.AccountDto
{
    public class AdminUpdateStudent
    {
        public Guid StudentID { get; set; }
        public string PublicStudentID { get; set; }

        public string FullName { get; set; }

        public string? CitizenID { get; set; }  

        public string Username { get; set; }

        public string? Password { get; set; }  

        public string? Email { get; set; } 

        public string? Dob { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }  

        public string? ParentPhone { get; set; } 

        public string? HomeTown { get; set; } 

        public string? UnionJoinDate { get; set; }

        public Guid? StudentTypeId { get; set; }

        public Guid ClassroomId { get; set; }

    }

    public class AdminUpdateTeacher
    {
        public Guid TeacherID { get; set; }
        public string? PublicTeacherID { get; set; }

        public string? CitizenID { get; set; } = string.Empty;

        public string Username { get; set; }

        public string? Password { get; set; } = string.Empty;

        public string FullName { get; set; }

        public string Email { get; set; } = string.Empty;

        public string? Dob { get; set; }

        public string? Address { get; set; } = string.Empty;

        public string Phone { get; set; }

        public Guid? TeacherTypeId { get; set; }

    }
}
