using DataAccess.DTO;
using DataAccess.Repository;
using Microsoft.AspNetCore.Identity.Data;
using MoneyDreamAPI.Services;
using SchoolMate.Authorizotion;
using SchoolMate.Dto.AuthenticationDto;

namespace VemsApi.Services
{

    public interface IAuthService
    {
        AuthenticationResponse? Login(AuthenticationRequest model);
        CommonAccountType Authetication(string token);
        //object Register(RegisterRequest model);
        //object? Authentication(string token);
    }
    public class AuthService : IAuthService
    {
        private readonly IJwtUtils _jwtUtils;
        private readonly IAccountRepository accountRepository;
        private readonly IEmailService _emailService;

        public AuthService(IJwtUtils jwtUtils, IEmailService emailService)
        {
            _jwtUtils = jwtUtils;
            _emailService = emailService;
            accountRepository = new AccountRepository();
        }

        public AuthenticationResponse? Login(AuthenticationRequest model)
        {
            var user = accountRepository.GetAccountByUsername(model.Username);

            if (user != null)
            {
                if (user.Username == model.Username && CheckHashed(model.Password, user.Password))
                {
                    var accessToken = _jwtUtils.GenerateJwtToken(user);
                    var refreshToken = _jwtUtils.GenerateJwtRefreshToken(accessToken);
                    return new AuthenticationResponse(accessToken, refreshToken);
                }
            }
            return null;
        }

        public CommonAccountType Authetication(string token)
        {
            var validatedUser = _jwtUtils.ValidateJwtToken(token);

            return validatedUser != null ? this.accountRepository.GetAccountByID((Guid)validatedUser) : null;
        }

        private bool CheckHashed(string origin, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(origin, hash);
        }

        private string Hashing(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 6);
        }

    }

}
