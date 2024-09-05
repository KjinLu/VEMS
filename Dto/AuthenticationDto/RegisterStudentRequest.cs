namespace SchoolMate.Dto.AuthenticationDto
{
    public class RegisterStudentRequest
    {
        public string StudentId { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public string Gender { get; set; } = null!;

        public string? Address { get; set; }

        public string? Cccd { get; set; }

        public string? Phone { get; set; }

        public int RoleId { get; set; }

        public string? ParentContact { get; set; }

        public string ClassId { get; set; } = null!;

        public string? Image { get; set; }

        public string StatusAccount { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string RecoverPassword { get; set; } = null!;
    }
}
