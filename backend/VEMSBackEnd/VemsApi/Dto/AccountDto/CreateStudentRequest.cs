using BusinessObject;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VemsApi.Dto.AccountDto
{
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
}
