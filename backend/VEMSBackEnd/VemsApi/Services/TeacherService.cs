using BusinessObject;
using DataAccess.Repository;
using SchoolMate.Dto.AuthenticationDto;
using VemsApi.Dto.StudentServiceDto;

namespace VemsApi.Services
{
    public interface ITeacherService
    {
        Task<bool> UpdateProfile(UpdateTeacherProfileRequest request);

        Task<bool> ChangePassword(ChangePasswordRequest request);
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

    }
}
