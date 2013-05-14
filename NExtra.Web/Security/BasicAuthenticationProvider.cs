using System;
using System.Web;

namespace NExtra.Web.Security
{
    /// <summary>
    /// This class can be used to see if the current user
    /// has provided basic authentication credentials. It
    /// can either be provided directly in the url, using
    /// http://username:password@url, or by returning the
    /// 401 status code to the client from the server. It
    /// will cause a login box to appear.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// The URL syntax does not work in Internet Explorer.
    /// When in IE, you will have to sign in with the 401
    /// status code approach.
    /// </remarks>
    public class BasicAuthenticationProvider : IBasicAuthenticationProvider
    {
        public bool IsAuthenticated()
        {
            var credentials = GetCurrentUserCredentials();

            return credentials != null;
        }

        public bool IsAuthenticatedWithCredentials(BasicAuthenticationCredentials requiredCredentials)
        {
            if (!IsAuthenticated())
                return false;

            var credentials = GetCurrentUserCredentials();
            var userNameMatch = credentials.UserName == requiredCredentials.UserName;
            var passwordMatch = credentials.Password == requiredCredentials.Password;

            return userNameMatch && passwordMatch;
        }

        public BasicAuthenticationCredentials GetCurrentUserCredentials()
        {
            var request = HttpContext.Current.Request;
            var header = request.Headers["Authorization"];
            if (string.IsNullOrWhiteSpace(header))
                return null;

            var authString = Convert.FromBase64String(header.Substring(6));
            var rawCredentials = System.Text.Encoding.ASCII.GetString(authString).Split(':');
            var credentials = new BasicAuthenticationCredentials(rawCredentials[0], rawCredentials[1]);
            
            return credentials;
        }
    }
}