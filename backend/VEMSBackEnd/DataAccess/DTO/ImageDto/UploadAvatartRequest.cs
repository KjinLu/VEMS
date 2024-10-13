using Microsoft.AspNetCore.Http;

 
    public class UploadAvatartRequest
    {
        public Guid AccountID { get; set; }
        public IFormFile? file { get; set; }
    }

    public class DeleteAvatarRequest
    {
        public Guid AccountID { get; set; }
    }

