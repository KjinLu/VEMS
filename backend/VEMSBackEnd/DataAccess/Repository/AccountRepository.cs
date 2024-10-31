using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccess.DAO;
using DataAccess.DTO;

namespace DataAccess.Repository
{

    public interface IAccountRepository
    {
        public Task<Admin> GetAdminByIdAsync(Guid accountID);
        public Task<Admin> GetAdminByUsernameAsync(string username);
        public Task<Admin> GetAdminByEmailAsync(string email);
        public Task<Student> GetStudentByIdAsync(Guid accountID);
        public Task<Student> GetStudentByUsernameAsync(string username);
        public Task<Student> GetStudentByEmailAsync(string email);
        public Task<Teacher> GetTeacherByIdAsync(Guid accountID);
        public Task<TeacherResponse> GetTeacherProfileByIdAsync(Guid accountID);
        public Task<Teacher> GetTeacherByUsernameAsync(string username);
        public Task<Teacher> GetTeacherByEmailAsync(string email);
        public Task<CommonAccountType> GetAccountByEmailAsync(string username);
        public Task<CommonAccountType> GetAccountByIDAsync(Guid accountID);
        public Task<CommonAccountType> GetAccountByUsernameAsync(string username);
        public Task<bool> UpdateRefreshTokenAsync(Guid accountID, string token);
        public Task<bool> UpdatePassword(Guid accountID, string newPassword);
        public Task<List<Admin>> GetAllAdminAsync();
        public Task<List<TeacherResponse>> GetAllTeacherAsync();
        public Task<List<StudentResponse>> GetAllStudentAsync();
        public Task<List<Student>> RegisterStudentAsync(List<Student> requests);
        public Task<List<Teacher>> RegisterTeacherAsync(List<Teacher> requests);
        public Task<Student> CreateAStudentAccount(Student request);
        public Task<Teacher> CreateTeacherAccount(Teacher request);
        public Task<bool> UpdateStudentProfile(Student request);
        public Task<bool> UpdateTeacherProfile(Teacher request);
        public Task<bool> UpdateAvatar(Guid accountID, string imageLink);

    }

    public class AccountRepository : IAccountRepository
    {
        public async Task<List<Admin>> GetAllAdminAsync() => await AccountDAO.Instance.GetAllAdminAsync();

        public async Task<List<StudentResponse>> GetAllStudentAsync() => await AccountDAO.Instance.GetAllStudentAsync();

        public async Task<List<TeacherResponse>> GetAllTeacherAsync() => await AccountDAO.Instance.GetAllTeacherAsync();

        public async Task<CommonAccountType> GetAccountByIDAsync(Guid accountID) => await AccountDAO.Instance.GetAccountByIDAsync(accountID);

        public async Task<CommonAccountType> GetAccountByUsernameAsync(string username) => await AccountDAO.Instance.GetAccountByUsernameAsync(username);

        public async Task<CommonAccountType> GetAccountByEmailAsync(string email) => await AccountDAO.Instance.GetAccountByEmailAsync(email);

        public async Task<Admin> GetAdminByEmailAsync(string email) => await AccountDAO.Instance.GetAdminByEmailAsync(email);

        public async Task<Admin> GetAdminByIdAsync(Guid accountID) => await AccountDAO.Instance.GetAdminByIdAsync(accountID);

        public async Task<Admin> GetAdminByUsernameAsync(string username) => await AccountDAO.Instance.GetAdminByUsernameAsync(username);

        public async Task<Student> GetStudentByEmailAsync(string email) => await AccountDAO.Instance.GetStudentByEmailAsync(email);

        public async Task<Student> GetStudentByIdAsync(Guid accountID) => await AccountDAO.Instance.GetStudentByIdAsync(accountID);

        public async Task<Student> GetStudentByUsernameAsync(string username) => await AccountDAO.Instance.GetStudentByUsernameAsync(username);

        public async Task<Teacher> GetTeacherByEmailAsync(string email) => await AccountDAO.Instance.GetTeacherByEmailAsync(email);

        public async Task<Teacher> GetTeacherByIdAsync(Guid accountID) => await AccountDAO.Instance.GetTeacherByIdAsync(accountID);

        public async Task<Teacher> GetTeacherByUsernameAsync(string username) => await AccountDAO.Instance.GetTeacherByUsernameAsync(username);

        public async Task<bool> UpdateRefreshTokenAsync(Guid accountID, string token) => await AccountDAO.Instance.UpdateRefreshTokenAsync(accountID, token);
        public async Task<bool> UpdatePassword(Guid accountID, string token) => await AccountDAO.Instance.ChangePassword(accountID, token);

        public async Task<List<Student>> RegisterStudentAsync(List<Student> requests) => await AccountDAO.Instance.RegisterStudentAsync(requests);
        public async Task<List<Teacher>> RegisterTeacherAsync(List<Teacher> requests) => await AccountDAO.Instance.RegisterTeacherAsync(requests);

        public async Task<Student> CreateAStudentAccount(Student request) => await AccountDAO.Instance.CreateAStudentAccount(request);

        public async Task<Teacher> CreateTeacherAccount(Teacher request) => await AccountDAO.Instance.CreateATeacherAccount(request);

        public async Task<bool> UpdateStudentProfile(Student request) => await AccountDAO.Instance.UpdateStudentProfile(request);

        public async Task<bool> UpdateTeacherProfile(Teacher request) => await AccountDAO.Instance.UpdateTeacherProfile(request);

        public async Task<bool> UpdateAvatar(Guid accountID, string imageLink) => await AccountDAO.Instance.UpdateAvatarAsync(accountID, imageLink);

        public async Task<TeacherResponse?> GetTeacherProfileByIdAsync(Guid accountID) => await AccountDAO.Instance.GetTeacherProfileByIdAsync(accountID);
    }
}
