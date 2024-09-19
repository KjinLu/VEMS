using BusinessObject;
using DataAccess.Repository;
using SchoolMate.Dto.AuthenticationDto;
using VemsApi.Dto.StudentServiceDto;

namespace VemsApi.Services
{
    public interface IStudentService
    {
        Task<bool> UpdateProfile(UpdateStudentProfileRequest request);
        Task<bool> ChangePassword(ChangePasswordRequest request);
    }

    public class StudentService : IStudentService
    {

        private readonly IAccountRepository _accountRepository;
        public StudentService()
        {
            _accountRepository = new AccountRepository();
        }
        public async Task<bool> UpdateProfile(UpdateStudentProfileRequest request)
        {
            var account =await _accountRepository.GetStudentByIdAsync(request.StudentId);

            if (account == null) return false;

            account.FullName = request.FullName;
            account.CitizenID = request.CitizenID;
            account.Email = request.Email;
            account.Dob = DateOnly.Parse(request.Dob);
            account.Address = request.Address;
            account.Phone = request.Phone;
            account.ParentPhone = request.ParentPhone;
            account.HomeTown = request.HomeTown;
            account.UnionJoinDate = DateOnly.Parse(request.UnionJoinDate);

            return await _accountRepository.UpdateStudentProfile(account);
            
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
