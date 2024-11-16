using ASM.Core.Entities;
using ASM.Core.DTOs;

namespace ASM.Services.Interfaces
{
    public interface IAuthService
    {
        public TokenDto GenerateJwtToken(ApplicationUser user);
        public string GenerateVerifyCode(string userId);
        public bool CheckVerifyCode(string userId, string code);
        public string GenerateSecureRandomDigits();
    }
}
