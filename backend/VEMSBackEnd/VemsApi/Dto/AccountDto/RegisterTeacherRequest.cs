namespace VemsApi.Dto.AccountDto
{
    public class RegisterTeacherRequest
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; } = new Guid("01E27B7C-93CA-47F6-A09B-C7015717E2ED");
    }
}
