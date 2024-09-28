namespace SchoolMate.Dto.AuthenticationDto
{
    public class ChangePasswordRequest
    {
        public Guid AccountID { get; set; }
        public string NewPassword { get; set; }
    }
}
