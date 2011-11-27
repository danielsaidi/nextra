using System;
using System.Web;

namespace NExtra.Web.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can handle cookies in various ways.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface ICanHandleCookies
    {
        /// <summary>
        /// Check whether a cookie exists.
        /// </summary>
        bool CookieExists(string cookieName);

        /// <summary>
        /// Get a certain cookie.
        /// </summary>
        HttpCookie GetCookie(string cookieName);

        /// <summary>
        /// Get the value of a certain cookie.
        /// </summary>
        string GetCookieValue(string cookieName);

        /// <summary>
        /// Get the typed value of a certain cookie.
        /// </summary>
        T GetCookieValue<T>(string cookieName);

        /// <summary>
        /// Set the value of a cookie.
        /// </summary>
        void SetCookieValue(string cookieName, object data);

        /// <summary>
        /// Set the value of a cookie.
        /// </summary>
        void SetCookieValue(string cookieName, object data, DateTime? expires);
    }
}
