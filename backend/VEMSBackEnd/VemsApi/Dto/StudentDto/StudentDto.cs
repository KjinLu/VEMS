using System;

namespace VemsApi.Dto.StudentDto;

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

}
