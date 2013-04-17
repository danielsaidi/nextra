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
        bool Authenticate(string userName, string password);
        bool IsAuthenticated();
        void SignIn(string userName, bool rememberMe);
        void SignOut();
    }
}
