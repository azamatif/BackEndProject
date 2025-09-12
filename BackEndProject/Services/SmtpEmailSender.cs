using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity.UI.Services;


namespace BackEndProject.Services
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public SmtpEmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var from = _config["Email:SmtpFrom"];
            var host = _config["Email:SmtpHost"];
            var port = int.Parse(_config["Email:SmtpPort"] ?? "25");
            var user = _config["Email:SmtpUser"];
            var pass = _config["Email:SmtpPass"];

            using var client = new SmtpClient(host, port)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(user, pass)
            };

            using var message = new MailMessage(from, email, subject, htmlMessage)
            {
                IsBodyHtml = true
            };

            await client.SendMailAsync(message);
        }
    }
}