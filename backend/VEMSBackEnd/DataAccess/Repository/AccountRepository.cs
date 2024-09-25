using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccess.DAO;

namespace DataAccess.Repository
{

    public interface IAccountRepository
    {
<<<<<<< HEAD
        public Task<Admin> GetAdminByIdAsync(Guid accountID);
        public Task<Admin> GetAdminByUsernameAsync(string username);
        public Task<Admin> GetAdminByEmailAsync(string email);
        public Task<Student> GetStudentByIdAsync(Guid accountID);
        public Task<Student> GetStudentByUsernameAsync(string username);
        public Task<Student> GetStudentByEmailAsync(string email);
        public Task<Teacher> GetTeacherByIdAsync(Guid accountID);
        public Task<Teacher> GetTeacherByUsernameAsync(string username);
        public Task<Teacher> GetTeacherByEmailAsync(string email);
        public Task<CommonAccountType> GetAccountByEmailAsync(string username);
        public Task<CommonAccountType> GetAccountByIDAsync(Guid accountID);
        public Task<CommonAccountType> GetAccountByUsernameAsync(string username);
        public Task<bool> UpdateRefreshTokenAsync(Guid accountID, string token);
        public Task<bool> UpdatePassword(Guid accountID, string newPassword);
        public Task<List<Admin>> GetAllAdminAsync();
        public Task<List<Teacher>> GetAllTeacherAsync();
        public Task<List<Student>> GetAllStudentAsync();
        public Task<List<Student>> RegisterStudentAsync(List<Student> requests);
        public Task<List<Teacher>> RegisterTeacherAsync(List<Teacher> requests);
        public Task<Student> CreateAStudentAccount(Student request);
        public Task<Teacher> CreateTeacherAccount(Teacher request);
        public Task<bool> UpdateStudentProfile(Student request);
        public Task<bool> UpdateTeacherProfile(Teacher request);
        public Task<bool> UpdateAvatar(Guid accountID, string imageLink);

=======
        public List<Admin> GetAllAdmin();
        public Admin GetAdminById(Guid accountID);
        public Admin GetAdminByUsername(string username);
        public Admin GetAdminByEmail(string email);
        public List<Student> GetAllStudent();
        public Student GetStudentById(Guid accountID);
        public Student GetStudentByUsername(string username);
        public Student GetStudentByEmail(string email);
        public List<Teacher> GetAllTeacher();
        public Teacher GetTeacherById(Guid accountID);
        public Teacher GetTeacherByUsername(string username);
        public Teacher GetTeacherByEmail(string email);
        public object GetAccountByUserName(string username);
        public object GetAccountByEmail(string username);
        public object GetAccountByID(Guid accountID);
>>>>>>> 7b71eb53662e57dca054c91a3c37a5502da59b96
    }

    public class AccountRepository : IAccountRepository
    {

        public List<Admin> GetAllAdmin() => AccountDAO.Instance.GetAllAdmin();

        public List<Student> GetAllStudent() => AccountDAO.Instance.GetAllStudent();

        public List<Teacher> GetAllTeacher() => AccountDAO.Instance.GetAllTeacher();

        public object GetAccountByID(Guid accountID) => AccountDAO.Instance.GetAccountByID(accountID);

        public object GetAccountByUserName(string username) => AccountDAO.Instance.GetAccountByUserName(username);

        public object GetAccountByEmail(string email) => AccountDAO.Instance.GetAccountByEmail(email);

        public Admin GetAdminByEmail(string email) => AccountDAO.Instance.GetAdminByEmail(email);

        public Admin GetAdminById(Guid accountID) => AccountDAO.Instance.GetAdminById(accountID);

        public Admin GetAdminByUsername(string username) => AccountDAO.Instance.GetAdminByUsername(username);

        public Student GetStudentByEmail(string email) => AccountDAO.Instance.GetStudentByEmail(email);

        public Student GetStudentById(Guid accountID) => AccountDAO.Instance.GetStudentById(accountID);

        public Student GetStudentByUsername(string username) => AccountDAO.Instance.GetStudentByUsername(username);

        public Teacher GetTeacherByEmail(string email) => AccountDAO.Instance.GetTeacherByEmail(email);

        public Teacher GetTeacherById(Guid accountID) => AccountDAO.Instance.GetTeacherById(accountID);

<<<<<<< HEAD
        public async Task<bool> UpdateRefreshTokenAsync(Guid accountID, string token) => await AccountDAO.Instance.UpdateRefreshTokenAsync(accountID, token);
        public async Task<bool> UpdatePassword(Guid accountID, string token) => await AccountDAO.Instance.ChangePassword(accountID, token);

        public async Task<List<Student>> RegisterStudentAsync(List<Student> requests) => await AccountDAO.Instance.RegisterStudentAsync(requests);
        public async Task<List<Teacher>> RegisterTeacherAsync(List<Teacher> requests) => await AccountDAO.Instance.RegisterTeacherAsync(requests);

        public async Task<Student> CreateAStudentAccount(Student request) =>await AccountDAO.Instance.CreateAStudentAccount(request);

        public async Task<Teacher> CreateTeacherAccount(Teacher request) =>await AccountDAO.Instance.CreateATeacherAccount(request);

        public async Task<bool> UpdateStudentProfile(Student request) => await AccountDAO.Instance.UpdateStudentProfile(request);

        public async Task<bool> UpdateTeacherProfile(Teacher request) => await AccountDAO.Instance.UpdateTeacherProfile(request);

        public async Task<bool> UpdateAvatar(Guid accountID, string imageLink) => await AccountDAO.Instance.UpdateAvatarAsync(accountID, imageLink);
         
=======
        public Teacher GetTeacherByUsername(string username) => AccountDAO.Instance.GetTeacherByUsername(username);
>>>>>>> 7b71eb53662e57dca054c91a3c37a5502da59b96
    }
}
