using Developer_Exam.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Developer_Exam.Services
{

    public interface IAuthService
    {
        Task<AuthResponse> GetToken();
    }

    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<AuthResponse> GetToken()
        {

            return new AuthResponse
            {
                Message = "success",
                Token = GenerateToken()
            };

        }

        private string GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
             issuer: _configuration["JWT:Issuer"],
             audience: _configuration["JWT:Audience"],
             expires: DateTime.Now.AddHours(8),
             signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature)
             );

            return tokenHandler.WriteToken(token);
        }


    }






}
