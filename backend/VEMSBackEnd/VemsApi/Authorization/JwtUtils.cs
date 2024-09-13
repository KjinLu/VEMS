
using Azure.Core;
using BusinessObject;
using CloudinaryDotNet;
using DataAccess.DTO;
using DataAccess.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolMate.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolMate.Authorizotion;

public interface IJwtUtils
{
    public string GenerateJwtToken(CommonAccountType account);
    public string GenerateJwtRefreshToken(string token);
    public Guid? ValidateJwtToken(string? token);

}
public class JwtUtils : IJwtUtils
{
    private readonly AppSettings _appSettings;
    private readonly IAccountRepository _accountRepository;

    public JwtUtils(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
        _accountRepository = new AccountRepository();

        if (string.IsNullOrEmpty(_appSettings.Secret))
            throw new Exception("JWT secret not configured");
    }

    public string GenerateJwtRefreshToken(string accessToken)
    {
        if (accessToken == null)
        {
            return null;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret!);

        try
        {
            tokenHandler.ValidateToken(accessToken, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,  // Assuming you're not using issuer validation
                ValidateAudience = false, // Assuming you're not using audience validation
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            Guid userId = new Guid(jwtToken.Claims.First(x => x.Type == "id").Value);

            var validateUser = _accountRepository.GetAccountByID(userId);


            // Validate if refresh token logic is implemented (placeholder for actual validation)
            if (validateUser == null)
            {
                return null;
            }


            // Generate a new access token with a shorter lifespan  
            var newTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                 new Claim("id", validateUser.AccountID.ToString()),
                new Claim("role", validateUser.RoleName.ToString())
                }
            ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var newToken = tokenHandler.CreateToken(newTokenDescriptor);
            var tokenResult = tokenHandler.WriteToken(newToken);
            _accountRepository.UpdateRefreshToken(userId, tokenResult);

            return tokenResult;
        }
        catch
        {
            return null;
        }
    }

    public Guid? ValidateJwtToken(string? token)
    {
        if (token == null)
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret!);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;


            Guid userId = new Guid(jwtToken.Claims.First(x => x.Type == "id").Value);

            // return user id from JWT token if validation successful
            return userId;
        }
        catch
        {
            // return null if validation fails
            return null;
        }
    }

    public string GenerateJwtToken(CommonAccountType account)
    {
        // generate token that is valid for 1 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] {
                new Claim("id", account.AccountID.ToString()),
                new Claim("role", account.RoleName.ToString())}
            ),
            Expires = DateTime.UtcNow.AddMinutes(120),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenResult = tokenHandler.WriteToken(token);
        //_accountRepository.UpdateRefreshhToken(account.AccountID, tokenResult);
        return tokenResult;
    }
}
