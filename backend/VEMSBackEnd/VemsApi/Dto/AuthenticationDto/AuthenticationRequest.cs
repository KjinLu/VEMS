using System.ComponentModel.DataAnnotations;

 
    public class AuthenticationRequest
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }

