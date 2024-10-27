using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class AuthenticationRequest
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }

    public class AuthenticationResponse
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }

        public AuthenticationResponse(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }

    public class ChangePasswordRequest
    {
        public Guid AccountID { get; set; }
        public string NewPassword { get; set; }
    }

    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; }
    }

    public class ReSendValidateEmail
    {
        public int AccountID { get; set; }
        public string Email { get; set; }
    }

    public class ValidateEmailRequest
    {
        public string UsernameOrEmail { get; set; }
        public string Code { get; set; }
    }

    public class SendEmailRequest
    {
        public string UsernameOrEmail { get; set; }
    }
}
