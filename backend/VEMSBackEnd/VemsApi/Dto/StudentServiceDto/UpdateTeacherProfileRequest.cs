namespace VemsApi.Dto.StudentServiceDto
{
    public class UpdateTeacherProfileRequest
    {
        public Guid TeacherId { get; set; }

        public string PublicTeacherID { get; set; } = string.Empty;
        public string FullName { get; set; }

        public string? CitizenID { get; set; } 

        public string? Email { get; set; } 

        public string? Dob { get; set; }

        public string? Address { get; set; } 

    }
}
