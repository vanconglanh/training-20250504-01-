

using ATDS.Business.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace ATDS.Business
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> appSettings)
        {
            _emailSettings = appSettings.Value;
        }

        public async Task Send(string emailto, string subject, string html)
        {
            try
            {
                SmtpClient mySmtpClient = new SmtpClient(_emailSettings.Host, _emailSettings.Port);
                mySmtpClient.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicAuthenticationInfo = new
                   System.Net.NetworkCredential(_emailSettings.Username, _emailSettings.Password);

                mySmtpClient.Credentials = basicAuthenticationInfo;
                mySmtpClient.EnableSsl = _emailSettings.EnableSsl;

                MailAddress from = new MailAddress(_emailSettings.Username, _emailSettings.SenderName);
                MailAddress to = new MailAddress(emailto, "");
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                myMail.Subject = $"{_emailSettings.Prefix} {subject}";
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                myMail.Body = html;
                myMail.BodyEncoding = System.Text.Encoding.UTF8;

                myMail.IsBodyHtml = true;
                await mySmtpClient.SendMailAsync(myMail);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
