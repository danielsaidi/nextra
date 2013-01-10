namespace NExtra.Web.Cookies
{
    /// <summary>
    /// This interface can be implemented by classes that can
    /// be used to invalidate cookies.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface ICookieInvalidator
    {
        /// <summary>
        /// Invalidate all existing cookies.
        /// </summary>
        void InvalidateAllCookies();

        /// <summary>
        /// Invalidate a certain cookie.
        /// </summary>
        void InvalidateCookie(string cookieName);
    }
}
