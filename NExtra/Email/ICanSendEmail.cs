using System.Net.Mail;

namespace NExtra.Email
{
    /// <summary>
    /// This interface can be implemented by classes
    /// that can send e-mail messages.
    /// </summary>
    public interface ICanSendEmail
    {
        /// <summary>
        /// Send an e-mail message.
        /// </summary>
        void SendEmail(string fromName, string fromEmail, string toEmail, string subject, string body);

        /// <summary>
        /// Send an e-mail message.
        /// </summary>
        void SendEmail(MailMessage mailMessage);
    }
}
