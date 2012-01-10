namespace NExtra.Web.Security
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// provides authentication services.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Sign in a certain user.
        /// </summary>
        void SignIn(string userName, bool createPersistentCookie);

        /// <summary>
        /// Sign out the currently signed in user.
        /// </summary>
        void SignOut();
    }
}
