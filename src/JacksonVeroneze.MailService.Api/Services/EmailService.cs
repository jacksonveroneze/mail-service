using System.Threading.Tasks;
using JacksonVeroneze.MailService.Api.Models;
using JacksonVeroneze.MailService.Api.Util;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace JacksonVeroneze.MailService.Api.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> appSettings)
            => _smtpSettings = appSettings.Value;

        public async Task Send(MailRequest mailRequest)
        {
            MimeMessage email = new();
            email.From.Add(MailboxAddress.Parse(mailRequest.From));
            email.To.Add(MailboxAddress.Parse(mailRequest.To));
            email.Subject = mailRequest.Subject;
            email.Body = new TextPart(TextFormat.Html) {Text = mailRequest.Text};

            using SmtpClient smtp = new();
            await smtp.ConnectAsync(_smtpSettings.SmtpHost, _smtpSettings.SmtpPort, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_smtpSettings.SmtpUser, _smtpSettings.SmtpPass);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}
