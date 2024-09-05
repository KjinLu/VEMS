using System.ComponentModel.DataAnnotations;

namespace SchoolMate.Dto.AuthenticationDto
{
    public class AuthenticationRequest
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
