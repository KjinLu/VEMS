/**
using Azure.Core;
using BusinessObject.Models;
using CloudinaryDotNet;
using DataAccess.IRepository;
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
    public string GenerateJwtTokenStudent(Student student);
    public string GenerateJwtTokenTeacher(Teacher teacher);
    public string GenerateJwtRefreshTokenStudent(string token);
    public string GenerateJwtRefreshTokenTeacher(string token);
    public int? ValidateJwtTokenStudent(string? token);
    public int? ValidateJwtTokenTeacher(string? token);
}
public class JwtUtils : IJwtUtils
{
    private readonly AppSettings _appSettings;
    private readonly IStudentRepository _studentRepository;
    private readonly ITeacherRepository _teacherRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public JwtUtils(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
        _refreshTokenRepository = new RefreshTokenRepository();
        _studentRepository = new StudentRepository();
        _teacherRepository = new TeacherRepository();

        if (string.IsNullOrEmpty(_appSettings.Secret))
            throw new Exception("JWT secret not configured");
    }
    public string GenerateJwtTokenStudent(Student student)
    {
        // generate token that is valid for 1 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] {
                new Claim("id", student.StudentId.ToString()),
                new Claim("usertype", "student"),
                new Claim("roleid", student.RoleId.ToString())}
            ),
            Expires = DateTime.UtcNow.AddMinutes(120),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateJwtTokenTeacher(Teacher teacher)
    {
        // generate token that is valid for 1 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] {
                new Claim("id", teacher.TeacherId.ToString()),
                new Claim("usertype", "teacher"),
                new Claim("roleid", teacher.RoleId.ToString())}
            ),
            Expires = DateTime.UtcNow.AddMinutes(120),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string GenerateJwtRefreshTokenStudent(string accessToken)
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
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            var validateUser = _studentRepository.GetStudentByID(userId);


            // Validate if refresh token logic is implemented (placeholder for actual validation)
            if (validateUser == null)
            {
                return null;
            }

            // Generate a new access token with a shorter lifespan  
            var newTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim("id", validateUser.StudentId.ToString()),
                new Claim("usertype", "student"),
                new Claim("roleid", validateUser.RoleId.ToString())}
            ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var newToken = tokenHandler.CreateToken(newTokenDescriptor);
            var tokenResult = tokenHandler.WriteToken(newToken);
            _refreshTokenRepository.Create(validateUser.StudentId, 2, tokenResult);
            return tokenResult;
        }
        catch
        {
            return null;
        }
    }

    public string GenerateJwtRefreshTokenTeacher(string accessToken)
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
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            var validateUser = _teacherRepository.GetTeacherById(userId);


            // Validate if refresh token logic is implemented (placeholder for actual validation)
            if (validateUser == null)
            {
                return null;
            }

            // Generate a new access token with a shorter lifespan  
            var newTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim("id", validateUser.TeacherId.ToString()),
                new Claim("usertype", "teacher"),
                new Claim("roleid", validateUser.RoleId.ToString())}
            ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var newToken = tokenHandler.CreateToken(newTokenDescriptor);
            var tokenResult = tokenHandler.WriteToken(newToken);
            _refreshTokenRepository.Create(validateUser.TeacherId, 1, tokenResult);
            return tokenResult;
        }
        catch
        {
            return null;
        }
    }

    public int? ValidateJwtTokenStudent(string? token)
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


            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            // return user id from JWT token if validation successful
            return userId;
        }
        catch
        {
            // return null if validation fails
            return null;
        }
    }

    public int? ValidateJwtTokenTeacher(string? token)
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


            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            // return user id from JWT token if validation successful
            return userId;
        }
        catch
        {
            // return null if validation fails
            return null;
        }
    }
}
**/