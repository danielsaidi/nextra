namespace NExtra.Web.Cookies
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can be used to invalidate cookies.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface ICookieInvalidator
    {
        void InvalidateAllCookies();
        void InvalidateCookie(string cookieName);
    }
}
