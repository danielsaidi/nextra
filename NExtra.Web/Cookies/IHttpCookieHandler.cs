using System;
using System.Web;

namespace NExtra.Web.Cookies
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can handle cookies in various ways.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public interface IHttpCookieHandler
    {
        /// <summary>
        /// Check if a cookie exists.
        /// </summary>
        bool CookieExists(string cookieName);

        /// <summary>
        /// Get a certain cookie.
        /// </summary>
        HttpCookie GetCookie(string cookieName);

        /// <summary>
        /// Get the string value of a certain cookie.
        /// </summary>
        string GetCookieValue(string cookieName);

        /// <summary>
        /// Get the typed value of a certain cookie.
        /// </summary>
        T GetCookieValue<T>(string cookieName);

        /// <summary>
        /// Set a cookie value.
        /// </summary>
        void SetCookieValue(string cookieName, object data);

        /// <summary>
        /// Set a cookie value with an optional expiration date.
        /// </summary>
        void SetCookieValue(string cookieName, object data, DateTime? expires);
    }
}
