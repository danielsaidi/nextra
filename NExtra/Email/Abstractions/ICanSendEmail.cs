using System.Net.Mail;

namespace NExtra.Email.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes
    /// that should be able to send e-mail messages.
    /// </summary>
    public interface ICanSendEmail
    {
        /// <summary>
        /// Send an e-mail message.
        /// </summary>
        /// <param name="fromName">The name of the sender.</param>
        /// <param name="fromEmail">The sender e-mail address.</param>
        /// <param name="toEmail">The recipient e-mail address.</param>
        /// <param name="subject">The e-mail subject.</param>
        /// <param name="body">The e-mail body.</param>
        void SendEmail(string fromName, string fromEmail, string toEmail, string subject, string body);

        /// <summary>
        /// Send an e-mail message.
        /// </summary>
        /// <param name="mailMessage">The mail message to send.</param>
        void SendEmail(MailMessage mailMessage);
    }
}
