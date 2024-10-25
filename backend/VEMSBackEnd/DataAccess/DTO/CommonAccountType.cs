using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class CommonAccountType
    {
        public Guid AccountID { get; set; }
        public string Username { get; set; }
        public string? FullName { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Image { get; set; }
        public string RefreshToken { get; set; }
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }
        public string? StudentType { get; set; }

        public bool? IsFisrtLogin { get; set; } = false;
        public Guid? ClassroomID { get; set; }
    }
}
