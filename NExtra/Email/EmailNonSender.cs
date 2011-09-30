using System.Net.Mail;
using NExtra.Email.Abstractions;

namespace NExtra.Email
{
    /// <summary>
    /// This class implements the ICanSendEmail interface. It simulates
    /// sending e-mail messages, but does not actually send anything.
    /// 
    /// If you use IoC/DI, you can easily replace the EmailSender class
    /// with this one to disable e-mails from being sent.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class EmailNonSender : ICanSendEmail
    {
        /// <summary>
        /// Mimic an e-mail message send operation.
        /// </summary>
        /// <param name="fromName">The name of the sender.</param>
        /// <param name="fromEmail">The sender e-mail address.</param>
        /// <param name="toEmail">The recipient e-mail address.</param>
        /// <param name="subject">The e-mail subject.</param>
        /// <param name="body">The e-mail body.</param>
        public void SendEmail(string fromName, string fromEmail, string toEmail, string subject, string body)
        {
        }

        /// <summary>
        /// Mimic an e-mail message send operation.
        /// </summary>
        /// <param name="mailMessage">The mail message to send.</param>
        public void SendEmail(MailMessage mailMessage)
        {
        }
    }
}
