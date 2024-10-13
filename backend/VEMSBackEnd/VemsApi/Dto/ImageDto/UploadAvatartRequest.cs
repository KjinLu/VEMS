namespace VemsApi.Dto.ImageDto
{
    public class UploadAvatartRequest
    {
        public Guid AccountID { get; set; }
        public IFormFile? file { get; set; }
    }

    public class DeleteAvatarRequest
    {
        public Guid AccountID { get; set; }
    }
}
