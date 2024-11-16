using ASM.Application.Helper;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using static ASM.Application.Constants;

namespace ASM.Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmailService(IHttpContextAccessor httpContextAccessor) 
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool ConfirmEmail(ApplicationUser user, string token)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                return false;
            }

            var emailHelper = new EmailHelper(SmtpInfo.SMTP_SERVER, SmtpInfo.SMTP_PORT, SmtpInfo.SMTP_USER, SmtpInfo.SMTP_PASS);
            var subject = "Confirm Email";
            var body = $"<p>Hello {user.UserName},\n" +
                $"<a href=\"{_httpContextAccessor?.HttpContext?.Request.Scheme}://{_httpContextAccessor?.HttpContext?.Request.Host}{_httpContextAccessor?.HttpContext?.Request.PathBase}/api/account/confirm-email?userId={user.Id}&token={Uri.EscapeDataString(token)}\" >Click link</a> to confirm email.<p>";

            return emailHelper.SendEmail(user.Email, subject, body);
        }

        public bool ResetPassword(string email, string newPassword)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            // Send mail for user
            var emailHelper = new EmailHelper(SmtpInfo.SMTP_SERVER, SmtpInfo.SMTP_PORT, SmtpInfo.SMTP_USER, SmtpInfo.SMTP_PASS);
            var subject = "Reset Password";
            var body = $"<p>Hello,</p>\n" +
                $"<p>Your password has been changed to <span style=\"font-weight: bold; color: red;\">{newPassword}</span></p>";

            return emailHelper.SendEmail(email, subject, body);
        }

        public bool TwoFactorAuth(string email, string code)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(code))
            {
                return false;
            }

            // Send mail for user
            var emailHelper = new EmailHelper(SmtpInfo.SMTP_SERVER, SmtpInfo.SMTP_PORT, SmtpInfo.SMTP_USER, SmtpInfo.SMTP_PASS);
            var subject = "Verification Code";
            var body = $"<p>Hello,</p>\n" +
                $"<p>For security purposes, you must enter the code below to verify your account to access your login. The code will only work for 15 minustes and if you request a new code, this code will stop working.</p>\n" +
                $"<p>Account verification code: <span style=\"font-weight: bold; color: red;\">{code}</span></p>";

            return emailHelper.SendEmail(email, subject, body);
        }
    }
}
