using Azure.Core;
using BusinessObject;
using DataAccess.DTO;
using DataAccess.Repository;
using Microsoft.AspNetCore.Identity.Data;
using MoneyDreamAPI.Dto.AuthDto;
using MoneyDreamAPI.Services;
using Newtonsoft.Json.Linq;
using SchoolMate.Authorizotion;
using SchoolMate.Dto.AuthenticationDto;
using VemsApi.Dto.AuthenticationDto;

namespace VemsApi.Services
{

    public interface IAuthService
    {
        Task<AuthenticationResponse?> Login(AuthenticationRequest model);
        Task<AuthenticationResponse?> RefreshToken(RefreshTokenRequest request);
        Task<CommonAccountType> Authetication(string token);
        Task<List<Student>> RegisterStudent(List<RegisterStudentRequest> request);
        Task<List<Teacher>> RegisterTeacher(List<RegisterTeacherRequest> request);

        Task<string> SendRecoverEmail(SendEmailRequest usernameOrEmail);
        Task<bool> CheckVerifyEmail(SendEmailRequest usernameOrEmail,string code );
    }
    public class AuthService : IAuthService
    {
        private readonly IJwtUtils _jwtUtils;
        private readonly IAccountRepository accountRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IEmailService _emailService;

        public AuthService(IJwtUtils jwtUtils, IEmailService emailService)
        {
            _jwtUtils = jwtUtils;
            _emailService = emailService;
            accountRepository = new AccountRepository();
            roleRepository = new RoleRepository();
        }

        public async Task<AuthenticationResponse?> Login(AuthenticationRequest model)
        {
            var user = await accountRepository.GetAccountByUsernameAsync(model.Username);

            if(user.RefreshToken.Trim() == "") user.IsFisrtLogin = true;

            if (user != null)
            {
                if (user.Username == model.Username && CheckHashed(model.Password, user.Password))
                {
                    var accessToken = await _jwtUtils.GenerateJwtToken(user);
                    var refreshToken = await _jwtUtils.GenerateJwtRefreshToken(accessToken);
                    return new AuthenticationResponse(accessToken, refreshToken);
                }
            }
            return null;
        }

        public async Task<AuthenticationResponse?> RefreshToken(RefreshTokenRequest request)
        {
            var newToken = await _jwtUtils.GenerateJwtRefreshToken(request.RefreshToken);

            return new AuthenticationResponse("", newToken);
        }

        public async Task<CommonAccountType> Authetication(string token)
        {
            var validatedUser = await _jwtUtils.ValidateJwtToken(token);
            var userInfo = await this.accountRepository.GetAccountByIDAsync((Guid)validatedUser);
            if (validatedUser == null) return null;
            if(CheckHashed( "1", userInfo.Password)) userInfo.IsFisrtLogin = true;
            return userInfo;
        }

        public async Task<List<Student>> RegisterStudent(List<RegisterStudentRequest> request)
        {
            List<Student> newStudentList = new List<Student>();

            foreach (var student in request) {
                Student newStudent = new Student
                {
                    Username = student.PublicStudentID,
                    PublicStudentID = student.PublicStudentID,
                    FullName = student.FullName,
                    RoleId = student.RoleId,
                    ClassroomId = student.ClassroomId,
                    Password = Hashing("1")
                };
                newStudentList.Add(newStudent);
            }

            return await this.accountRepository.RegisterStudentAsync(newStudentList);
        }

        public async Task<List<Teacher>> RegisterTeacher(List<RegisterTeacherRequest> request)
        {
            List<Teacher> newTeacherList = new List<Teacher>();

            foreach (var teacher in request)
            {
                Teacher newTeacher = new Teacher
                {
                    Username = teacher.Phone,
                    Phone = teacher.Phone,
                    Email = teacher.Email,
                    FullName = teacher.FullName,
                    RoleId = teacher.RoleId,
                    //ClassroomId = student.ClassroomId,
                    Password = Hashing("1")
                };
                newTeacherList.Add(newTeacher);
            }

            return await this.accountRepository.RegisterTeacherAsync(newTeacherList);
        }

        private bool CheckHashed(string origin, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(origin, hash);
        }

        private string Hashing(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 6);
        }

        public async Task<string> SendRecoverEmail(SendEmailRequest request)
        {
            var account =await accountRepository.GetTeacherByEmailAsync(request.UsernameOrEmail);
            return account.Email;
        }

        public Task<bool> CheckVerifyEmail(SendEmailRequest usernameOrEmail, string code)
        {
            throw new NotImplementedException();
        }
    }

}
