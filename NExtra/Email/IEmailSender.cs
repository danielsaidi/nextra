using System.Net.Mail;

namespace NExtra.Email
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can be used to send e-mail messages.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IEmailSender
    {
        void SendEmail(string fromName, string fromEmail, string toEmail, string subject, string body);
        void SendEmail(MailMessage mailMessage);
    }
}
