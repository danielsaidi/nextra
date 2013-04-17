using System.Net;
using System.Net.Mail;

namespace NExtra.Email
{
    /// <summary>
    /// This class can be used to send an e-mail message,
    /// using the default SmtpClient.
    /// 
    /// To enable it, configure the SMTP settings in the
    /// configuration file for the project, e.g. in your
    /// web.config file.
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
            new SmtpClient { Credentials = CredentialCache.DefaultNetworkCredentials }.Send(mailMessage);
        }
    }
}
