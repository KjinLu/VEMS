namespace DataAccess.DTO
{
    public class StudentInClassResponse
    {
        public Guid StudentID { get; set; }
        public string StudentName { get; set; }
        public string PublicStudentID { get; set; }

    }


    public class AssignStudentTypeRequest
    {
        public Guid studentID { get; set; }
        public Guid studentTypeID { get; set; }

    }

}