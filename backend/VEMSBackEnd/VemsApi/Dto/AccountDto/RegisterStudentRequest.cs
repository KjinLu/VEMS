namespace VemsApi.Dto.AccountDto
{
    public class RegisterStudentRequest
    {

        public string PublicStudentID { get; set; }

        public string FullName { get; set; }

        public Guid ClassroomId { get; set; }

        public Guid RoleId { get; set; }

    }
}


