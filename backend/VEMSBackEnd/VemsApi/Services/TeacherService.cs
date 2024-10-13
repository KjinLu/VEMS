using BusinessObject;
using DataAccess.Repository;
using VemsApi.Dto.ImageDto;
using VemsApi.Dto.StudentServiceDto;

namespace VemsApi.Services
{
    public interface ITeacherService
    {
        Task<bool> UpdateProfile(UpdateTeacherProfileRequest request);

        Task<bool> ChangePassword(ChangePasswordRequest request);

        Task<bool> UploadAvatar(UploadAvatartRequest request);

        Task<bool> DeleteAvatar(DeleteAvatarRequest request);
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

        public async Task<bool> ChangePassword(ChangePasswordRequest request)
        {
            return await _accountRepository.UpdatePassword(request.AccountID, Hashing(request.NewPassword));
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

    }
}
