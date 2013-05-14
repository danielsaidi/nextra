namespace NExtra.Web.Security
{
    /// <summary>
    /// This class represents credentials that a user can
    /// provide to urls that require basic authentication.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class BasicAuthenticationCredentials
    {
        public BasicAuthenticationCredentials(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; } 
    }
}