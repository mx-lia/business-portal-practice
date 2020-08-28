using Application.Common.Interfaces;
using MimeKit;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        async public Task<bool> SendRecoveryPasswordMessage(string token, string email, string subject)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Recovery password", "PWdextim@yandex.by"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"Для сброса пароля пройдите по ссылке: <a href='https://localhost:44341/api/PasswordRecovery/CheckToken/{token}'>link</a>"
            };
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 25, false);
                await client.AuthenticateAsync("PWdextim@yandex.by", "wedextim");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
            return await Task.FromResult(true);
        }
    }
}
