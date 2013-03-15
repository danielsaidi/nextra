namespace NExtra.Security
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// provides authentication services.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticate a certain username and password.
        /// </summary>
        bool Authenticate(string userName, string password);

        /// <summary>
        /// Check whether or not a logged in user exists.
        /// </summary>
        bool IsAuthenticated();

        /// <summary>
        /// Sign in a certain user.
        /// </summary>
        void SignIn(string userName, bool rememberMe);

        /// <summary>
        /// Sign out the currently signed in user.
        /// </summary>
        void SignOut();
    }
}
