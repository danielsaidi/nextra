using System.Net.Mail;

namespace NExtra.Email
{
    /// <summary>
    /// This class simulates sending e-mail messages, but
    /// does not actually send anything.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class EmailNonSender : IEmailSender
    {
        public void SendEmail(string fromName, string fromEmail, string toEmail, string subject, string body)
        {
        }

        public void SendEmail(MailMessage mailMessage)
        {
        }
    }
}
