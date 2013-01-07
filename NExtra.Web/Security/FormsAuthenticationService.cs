using System.Web.Security;

namespace NExtra.Web.Security
{
    /// <summary>
    /// This class can be used as a facade for the static
    /// FormsAuthentication class.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class FormsAuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// Sign in a user.
        /// </summary>
        public void SignIn(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        /// <summary>
        /// Sign out the currently logged in user.
        /// </summary>
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
