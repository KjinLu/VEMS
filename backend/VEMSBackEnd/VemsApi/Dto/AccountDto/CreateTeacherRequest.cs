using BusinessObject;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VemsApi.Dto.AccountDto
{
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
}
