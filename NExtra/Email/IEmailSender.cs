using System.Net.Mail;

namespace NExtra.Email
{
    /// <summary>
    /// This interface can be implemented by classes
    /// that can send e-mail messages.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IEmailSender
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
