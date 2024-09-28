namespace VemsApi.Dto.AccountDto
{
    public class RegisterStudentRequest
    {

        public string PublicStudentID { get; set; }

        public string FullName { get; set; }

        public Guid ClassroomId { get; set; } = new Guid("AFAB05EF-E3E7-4902-A141-05C3057B92F3");

        public Guid RoleId { get; set; } = new Guid("01E27B7C-93CA-47F6-A09B-C7015717E2ED");


    }
}


