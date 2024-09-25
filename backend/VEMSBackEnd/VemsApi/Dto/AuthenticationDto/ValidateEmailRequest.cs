namespace MoneyDreamAPI.Dto.AuthDto
{
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
