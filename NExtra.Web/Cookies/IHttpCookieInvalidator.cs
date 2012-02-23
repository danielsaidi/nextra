namespace NExtra.Web.Cookies
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can be used to invalidate HTTP cookies.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public interface IHttpCookieInvalidator
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
