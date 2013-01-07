using System.Net;
using System.Net.Mail;

namespace NExtra.Email
{
    /// <summary>
    /// This ICanSendEmail implementation can be used to send e-mail
    /// messages, using the default SmtpClient.
    /// 
    /// To enable it, make CredentialCache.DefaultNetworkCredentials
    /// return valid credentials.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class EmailSender : IEmailSender
    {
        public void SendEmail(string fromName, string fromEmail, string toEmail, string subject, string body)
        {
            SendEmail(new MailMessage(fromEmail, toEmail, subject, body));
        }

        public void SendEmail(MailMessage mailMessage)
        {
            new SmtpClient { Timeout = 500, Credentials = CredentialCache.DefaultNetworkCredentials }.Send(mailMessage);
        }
    }
}
