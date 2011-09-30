using System.Net;
using System.Net.Mail;
using NExtra.Email.Abstractions;

namespace NExtra.Email
{
    /// <summary>
    /// This class implements the ICanSendEmail interface and can be
    /// used to send e-mail messages using a default SmtpClient.
    /// 
    /// If you use IoC/DI, you can easily replace this class with an
    /// EmailNonSender to disable e-mails from being sent.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// 
    /// For this to work in a web application, you must specify your
    /// SMTP settings in the system.net/mailSettings/smtp tag of the
    /// web.config file.
    /// </remarks>
    public class EmailSender : ICanSendEmail
    {
        /// <summary>
        /// Send an e-mail message.
        /// </summary>
        /// <param name="fromName">The name of the sender.</param>
        /// <param name="fromEmail">The sender e-mail address.</param>
        /// <param name="toEmail">The recipient e-mail address.</param>
        /// <param name="subject">The e-mail subject.</param>
        /// <param name="body">The e-mail body.</param>
        public void SendEmail(string fromName, string fromEmail, string toEmail, string subject, string body)
        {
            SendEmail(new MailMessage(fromEmail, toEmail, subject, body));
        }

        /// <summary>
        /// Send an e-mail message.
        /// </summary>
        /// <param name="mailMessage">The mail message to send.</param>
        public void SendEmail(MailMessage mailMessage)
        {
            new SmtpClient { Timeout = 500, Credentials = CredentialCache.DefaultNetworkCredentials }.Send(mailMessage);
        }
    }
}
