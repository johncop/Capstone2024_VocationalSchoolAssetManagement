using ASM.Application.Helper;
using ASM.Core.DTOs;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ASM.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDto GenerateJwtToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),  // Important claim
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expirationTime = DateTime.Now.AddMinutes(30);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expirationTime,   // Set this according to your needs
                signingCredentials: creds);

            return new TokenDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpirationTime = expirationTime,
            };
        }

        public string GenerateVerifyCode(string userId)
        {
            string verifyCode = GenerateSecureRandomDigits();
            VerificationCodeStoreHelper.StoreVerificationCode(userId, verifyCode); // Store in-memory

            return verifyCode;
        }

        public bool CheckVerifyCode(string userId, string code) => VerificationCodeStoreHelper.TryGetVerificationCode(userId, code, out _);

        public string GenerateSecureRandomDigits()
        {
            byte[] randomNumber = new byte[4]; // To generate a number large enough for a 6-digit integer.
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }

            int value = BitConverter.ToInt32(randomNumber, 0) & int.MaxValue; // Ensure non-negative.
            int result = 100000 + (value % 900000); // Modulo to fit in 6 digits.

            return result.ToString();
        }

        
    }
}
