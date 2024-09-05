using BusinessObject.Models;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Identity.Data;
using SchoolMate.Authorizotion;
using SchoolMate.Dto.AuthenticationDto;

namespace SchoolMate.Services
{
    public interface IAuthenticationService
    {
        AuthenticationResponse? LoginStudent(AuthenticationRequest model);
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtUtils _jwtUtils;
        private readonly IStudentRepository _repository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
       
        public AuthenticationService(IJwtUtils jwtUtils)
        {
            _jwtUtils = jwtUtils;
            _repository = new StudentRepository();
            _refreshTokenRepository = new RefreshTokenRepository();
        }
        public AuthenticationResponse? LoginStudent(AuthenticationRequest model)
        {
            var students = _repository.GetAllStudent();
            Student student = students.SingleOrDefault(x => x.Identifier == model.Username && CheckHashed(model.Password, x.Password));

            // return null if user not found
            if (student == null) return null;

            if (!CheckIsValidatedEmail(student.StudentId)) throw new Exception("Email is not validated");

            // authentication successful so generate jwt token
            var accessToken = _jwtUtils.GenerateJwtToken(student);
            var refreshToken = _jwtUtils.GenerateJwtRefreshToken(accessToken);

            refreshTokenRepository.Create(user.AccountId, refreshToken);

            return new AuthResponse(accessToken, refreshToken);
        }

        public AuthResponse? RefreshToken(string token)
        {
            var refreshToken = _jwtUtils.GenerateJwtRefreshToken(token);

            return new AuthResponse(token, refreshToken);
        }

        public MoneyDreamClassLibrary.DataAccess.Account? Authentication(string token)
        {
            var validatedUser = _jwtUtils.ValidateJwtToken(token);

            return validatedUser != null ? this.repository.GetAllAccountByID((int)validatedUser) : null;
        }

        public MoneyDreamClassLibrary.DataAccess.Account Register(RegisterRequest model)
        {
            var account = new MoneyDreamClassLibrary.DataAccess.Account();
            account.FullName = model.FullName;
            account.UserName = model.UserName;
            account.Password = Hashing(model.Password);
            account.Email = model.Email;
            account.PhoneNumber = model.PhoneNumber;
            account.DateofBirth = model.DateofBirth;
            account.Created = DateTime.Now.ToString();
            account.RoleId = 2;

            repository.CreateNewAccount(account);

            var _emailToken = new EmailToken();
            var codeToken = RandomValidateCode();
            _emailToken.Token = codeToken;
            _emailToken.Created = DateTime.Now.ToString();
            _emailToken.AccountId = account.AccountId;

            var code = _emailTokenRepository.CreateEmailToken(_emailToken);

            _emailService.Send(account.Email, "REGISTER ACCOUNT", new RegisterMail(account.FullName, codeToken).MailWelcome(), null);

            return account;
        }

        private bool CheckHashed(string origin, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(origin, hash);
        }
    }
}
