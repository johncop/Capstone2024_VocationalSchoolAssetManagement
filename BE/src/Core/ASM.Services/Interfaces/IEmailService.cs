using ASM.Core.Entities;

namespace ASM.Services.Interfaces
{
    public interface IEmailService
    {
        public bool ConfirmEmail(ApplicationUser user, string token);
        public bool ResetPassword(string email, string newPassword);
        public bool TwoFactorAuth(string email, string code);
    }
}
