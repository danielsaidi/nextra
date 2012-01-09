using System.Net;
using System.Net.Mail;

namespace NExtra.Email
{
    /// <summary>
    /// This class implements the ICanSendEmail interface. It can be
    /// used to send e-mail messages, using the default SmtpClient.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class EmailSender : ICanSendEmail
    {
        /// <summary>
        /// Send an e-mail message.
        /// </summary>
        public void SendEmail(string fromName, string fromEmail, string toEmail, string subject, string body)
        {
            SendEmail(new MailMessage(fromEmail, toEmail, subject, body));
        }

        /// <summary>
        /// Send an e-mail message.
        /// </summary>
        public void SendEmail(MailMessage mailMessage)
        {
            new SmtpClient { Timeout = 500, Credentials = CredentialCache.DefaultNetworkCredentials }.Send(mailMessage);
        }
    }
}
