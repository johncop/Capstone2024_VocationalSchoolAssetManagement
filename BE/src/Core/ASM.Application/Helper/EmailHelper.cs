using System.Net.Mail;
using System.Net;

namespace ASM.Application.Helper
{
    public class EmailHelper
    {
        private string _smtpServer;
        private int _smtpPort;
        private string _smtpUser;
        private string _smtpPass;

        public EmailHelper(string smtpServer, int smtpPort, string smtpUser, string smtpPass)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _smtpUser = smtpUser;
            _smtpPass = smtpPass;
        }

        public bool SendEmail(string toEmail, string subject, string body, bool isHtml = true)
        {
            try
            {
                var fromAddress = new MailAddress(_smtpUser);
                var toAddress = new MailAddress(toEmail);

                using (var smtpClient = new SmtpClient
                {
                    UseDefaultCredentials = false,
                    Host = _smtpServer,
                    Port = _smtpPort,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(_smtpUser, _smtpPass)
                })
                {
                    using (var message = new MailMessage(fromAddress, toAddress))
                    {
                        message.Subject = subject;
                        message.Body = body;
                        message.IsBodyHtml = isHtml;

                        smtpClient.Send(message);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine("Error sending email: " + ex.Message);
                return false;
            }
        }
    }
}
