using Azure.Core;
using BusinessObject;
using DataAccess.DTO;
using DataAccess.Repository;
using Microsoft.AspNetCore.Identity.Data;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Ocsp;
using SchoolMate.Authorizotion;



    public interface IAuthService
    {
        Task<AuthenticationResponse?> Login(AuthenticationRequest model);
        Task<AuthenticationResponse?> RefreshToken(RefreshTokenRequest request);
        Task<CommonAccountType> Authetication(string token);
        Task<string> SendRecoverEmail(SendEmailRequest usernameOrEmail);
        Task<CommonAccountType> CheckVerifyEmail(ValidateEmailRequest usernameOrEmail );
        Task<bool> ChangePassword(ChangePasswordRequest usernameOrEmail );
    }

    public class AuthService : IAuthService
    {
        private readonly IJwtUtils _jwtUtils;
        private readonly IAccountRepository accountRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IEmailTokenRepository emailTokenRepository;
        private readonly IEmailService _emailService;

        public AuthService(IJwtUtils jwtUtils, IEmailService emailService)
        {
            _jwtUtils = jwtUtils;
            _emailService = emailService;
            accountRepository = new AccountRepository();
            roleRepository = new RoleRepository();
            emailTokenRepository = new EmailTokenRepository();
        }

        public async Task<AuthenticationResponse?> Login(AuthenticationRequest model)
        {
            var user = await accountRepository.GetAccountByUsernameAsync(model.Username);

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

     

        public bool CheckHashed(string origin, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(origin, hash);
        }

        public string Hashing(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 6);
        }

        public string GenerateRandomCode()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 1000000); 
            return randomNumber.ToString();
        }

        public string HandleHiddenEmail(string plainEmail)
        {
            // Split the email into two parts: the local part and the domain part
            var emailParts = plainEmail.Split('@');
            if (emailParts.Length != 2)
            {
                throw new ArgumentException("Invalid email format");
            }

            var localPart = emailParts[0];
            var domainPart = emailParts[1];

            // Determine how many characters to show from the local part
            int visibleChars = Math.Min(3, localPart.Length); // Show up to 3 characters

            // Create the hidden email format
            var hiddenEmail = localPart.Substring(0, visibleChars) + new string('*', localPart.Length - visibleChars) + "@" + domainPart;

            return hiddenEmail;
        }

    public async Task<string> SendRecoverEmail(SendEmailRequest request)
    {
        var checkEmail = await accountRepository.GetAccountByEmailAsync(request.UsernameOrEmail);
        var checkUsername = await accountRepository.GetAccountByUsernameAsync(request.UsernameOrEmail);

        var plainEmail = "";
        var hiddenEmail = "";
        Guid account;

        if (checkEmail == null && checkUsername == null)
            throw new Exception("Email hoặc tên đăng nhập không tồn tại");

        if (checkEmail != null)
        {
            plainEmail = checkEmail.Email;
            hiddenEmail = HandleHiddenEmail(checkEmail.Email);
            account = checkEmail.AccountID;
        }
        else
        {
            plainEmail = checkUsername.Email;
            hiddenEmail = HandleHiddenEmail(checkUsername.Email);
            account = checkUsername.AccountID;
        }

        EmailToken token = new EmailToken();
        var code = GenerateRandomCode();

        token.Token = code;
        token.CreateAt = DateTime.Now;
        token.AccountID = account;
        await emailTokenRepository.CreateToken(token);

        // Thiết kế giao diện email
        var emailBody = $@"
    <html>
      <body style='font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 0; margin: 0;'>
        <div style='max-width: 600px; margin: 20px auto; background-color: #ffffff; border-radius: 8px; overflow: hidden;'>
          <div style='background-color: #0056b3; padding: 20px; color: white; text-align: center;'>
            <h1 style='margin: 0; font-size: 24px;'>VEMS - Khôi phục mật khẩu</h1>
          </div>
          <div style='padding: 20px; color: #333333;'>
            <p>Xin chào,</p>
            <p>Bạn đã yêu cầu khôi phục mật khẩu cho tài khoản VEMS của mình.</p>
            <p>Để tiếp tục, vui lòng sử dụng mã xác nhận bên dưới:</p>
            <div style='text-align: center; margin: 20px 0;'>
              <span style='display: inline-block; padding: 15px 30px; font-size: 24px; color: #ffffff; background-color: #0056b3; border-radius: 8px;'>{code}</span>
            </div>
            <p>Vui lòng nhập mã này vào trang khôi phục mật khẩu của hệ thống trong vòng 15 phút.</p>
            <p style='margin-top: 20px;'>Nếu bạn không thực hiện yêu cầu này, xin vui lòng bỏ qua email này.</p>
            <p>Trân trọng,<br/>Đội ngũ hỗ trợ VEMS</p>
          </div>
          <div style='background-color: #f4f4f4; padding: 10px; text-align: center; color: #888888; font-size: 12px;'>
            <p>© 2024 VEMS. Tất cả các quyền được bảo lưu.</p>
          </div>
        </div>
      </body>
    </html>";

        _emailService.Send(plainEmail, "VEMS - Khôi phục mật khẩu", emailBody, null);

        return hiddenEmail;
    }


    public async Task<CommonAccountType> CheckVerifyEmail(ValidateEmailRequest request)
        {
            var checkEmail = await accountRepository.GetAccountByEmailAsync(request.UsernameOrEmail);
            var checkUsername = await accountRepository.GetAccountByUsernameAsync(request.UsernameOrEmail);

            CommonAccountType account;


            if (checkEmail == null && checkUsername == null) throw new Exception("Email hoặc tên đăng nhập không tồn tại");
            if (checkEmail != null)
            {
                account = checkEmail;
            }
            else
            {
                account = checkUsername;
            }

            var dbToken = await emailTokenRepository.GetTokenByAccountId(account.AccountID);
            if (dbToken == null) throw new Exception("Mã xác thực không tồn tại");

            if (DateTime.Now - dbToken.CreateAt > TimeSpan.FromMinutes(10)) throw new Exception("Mã xác thực đã hết hạn");
            if (request.Code != dbToken.Token) throw new Exception("Mã xác thực không đúng");

            return account;
        }


        public Task<bool> ChangePassword(ChangePasswordRequest request)
        {
            return accountRepository.UpdatePassword(request.AccountID, Hashing(request.NewPassword));
        }
    }


