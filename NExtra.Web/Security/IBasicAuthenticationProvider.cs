namespace NExtra.Web.Security
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can be used to handle basic authentication. Basic
    /// authentication credentials can either be provided
    /// in the url, using http://username:password@url or
    /// by returning a 401 from the server. Doing so will
    /// cause a login box to appear for the client.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// The URL syntax does not work in Internet Explorer.
    /// When in IE, you will have to sign in with the 401
    /// status code approach.
    /// </remarks>
    public interface IBasicAuthenticationProvider
    {
        bool IsAuthenticated();
        bool IsAuthenticatedWithCredentials(BasicAuthenticationCredentials requiredCredentials);
        BasicAuthenticationCredentials GetCurrentUserCredentials();
    }
}