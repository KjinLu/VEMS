using BusinessObject;
using DataAccess.DTO;
using DataAccess.Repository;


    public interface ITeacherService
    {
        Task<bool> UpdateProfile(UpdateTeacherProfileRequest request);

        Task<bool> ChangePassword(UpdatePasswordRequest request);

        Task<bool> UploadAvatar(UploadAvatartRequest request);

        Task<bool> DeleteAvatar(DeleteAvatarRequest request);

        Task<TeacherResponse?> GetTeacherProfileByIdAsync(Guid accountID);
}

public class TeacherService : ITeacherService
    {

        private readonly IAccountRepository _accountRepository;
        public TeacherService()
        {
            _accountRepository = new AccountRepository();
        }
        public async Task<bool> UpdateProfile(UpdateTeacherProfileRequest request)
        {
            var account =await _accountRepository.GetTeacherByIdAsync(request.TeacherId);

            if (account == null) return false;

            account.FullName = request.FullName;
            account.PublicTeacherID = request.PublicTeacherID;
            account.CitizenID = request.CitizenID;
            account.Email = request.Email;
            account.Dob = DateOnly.Parse(request.Dob);
            account.Address = request.Address;
    

            return await _accountRepository.UpdateTeacherProfile(account);
            
        }

        public async Task<bool> ChangePassword(UpdatePasswordRequest request)
        {
            CommonAccountType account = await _accountRepository.GetAccountByIDAsync(request.AccountID);
            if (account == null) return false;
            if (CheckHashed(request.OldPassword, account.Password))
                return await _accountRepository.UpdatePassword(request.AccountID, Hashing(request.NewPassword));
            throw new Exception("Mật khẩu cũ không đúng!");
          }

        public bool CheckHashed(string origin, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(origin, hash);
        }

          public string Hashing(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 6);
        }

        public async Task<bool> UploadAvatar(UploadAvatartRequest request)
        {
            var a = ImageExtension.UploadFile(request.file);
            return await _accountRepository.UpdateAvatar(request.AccountID, a);
        }

        public async Task<bool> DeleteAvatar(DeleteAvatarRequest request)
        {
            return await _accountRepository.UpdateAvatar(request.AccountID, "");
        }

        public async Task<TeacherResponse?> GetTeacherProfileByIdAsync(Guid accountID)
        {
            return await _accountRepository.GetTeacherProfileByIdAsync(accountID);
        }
    }

