 
    public class ChangePasswordRequest
    {
        public Guid AccountID { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

    }
 
