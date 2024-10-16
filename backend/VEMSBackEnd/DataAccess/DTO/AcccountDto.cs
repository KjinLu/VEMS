using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

    public class CreateStudentRequest
    {
        public string PublicStudentID { get; set; }

        public string FullName { get; set; }

        public string? CitizenID { get; set; } = string.Empty;

        public string Username { get; set; }

        public string? Password { get; set; } = "1";

        public string? Email { get; set; } = string.Empty;

        public string? Dob { get; set; }

        public string? Address { get; set; } = string.Empty;

        public string? Image { get; set; } = string.Empty;

        public string? Phone { get; set; } = string.Empty;

        public string? ParentPhone { get; set; } = string.Empty;

        public string? HomeTown { get; set; } = string.Empty;

        public string? UnionJoinDate { get; set; }

        public Guid StudentTypeId { get; set; }

        public Guid ClassroomId { get; set; }

        public Guid RoleId { get; set; }

    }

    public class CreateTeacherRequest
    {
        public string? PublicTeacherID { get; set; }

        public string? CitizenID { get; set; } = string.Empty;

        public string Username { get; set; }

        public string? Password { get; set; } = string.Empty;

        public string FullName { get; set; }

        public string Email { get; set; } = string.Empty;

        public string? Dob { get; set; }

        public string? Address { get; set; } = string.Empty;

        public string? Image { get; set; } = string.Empty;

        public string Phone { get; set; }

        public Guid? TeacherTypeId { get; set; }

        public Guid RoleId { get; set; }

    }

    public class RegisterStudentRequest
    {

        public string PublicStudentID { get; set; }

        public string FullName { get; set; }

        public Guid ClassroomId { get; set; }

        public Guid RoleId { get; set; }

    }

    public class RegisterTeacherRequest
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
    }

    public class UpdateStudentProfileRequest
    {
        public Guid StudentId { get; set; }

        public string FullName { get; set; }

        public string? CitizenID { get; set; }

        public string? Email { get; set; }

        public string? Dob { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? ParentPhone { get; set; }

        public string? HomeTown { get; set; }

        public string? UnionJoinDate { get; set; }

    }

    public class UpdateTeacherProfileRequest
    {
        public Guid TeacherId { get; set; }

        public string PublicTeacherID { get; set; } = string.Empty;
        public string FullName { get; set; }

        public string? CitizenID { get; set; }

        public string? Email { get; set; }

        public string? Dob { get; set; }

        public string? Address { get; set; }

    }

    public class StudentResponse
    {
        public Guid Id { get; set; }
        public string PublicStudentID { get; set; }
        public string FullName { get; set; }
        public string? CitizenID { get; set; } = string.Empty;
        public string Username { get; set; }
        public string? Password { get; set; } = "1";
        public string? Email { get; set; } = string.Empty;
        public DateOnly? Dob { get; set; }
        public string? Address { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? ParentPhone { get; set; } = string.Empty;
        public string? HomeTown { get; set; } = string.Empty;
        public DateOnly? UnionJoinDate { get; set; }
        public string? StudentTypeName { get; set; }
        public string? ClassRoom { get; set; }
}

