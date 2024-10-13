namespace VemsApi.Dto.StudentServiceDto
{
    public class UpdateStudentProfileRequest
    {
        public Guid StudentId { get; set; }

        public string FullName { get; set; }

        public string? CitizenID { get; set; } 

        public string? Email { get; set; } 

        public string? Dob { get; set; }

        public string? Address { get; set; } 

        public string? Phone { get; set; } 

        public string? ParentPhone { get; set; } 

        public string? HomeTown { get; set; } 

        public string? UnionJoinDate { get; set; }

    }
}
