using System;
using System.Web;

namespace NExtra.Web.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to handle cookies in various ways.
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
        /// <param name="cookieName">The name of the cookie of interest.</param>
        /// <returns>Whether or not the cookie exists.</returns>
        bool CookieExists(string cookieName);

        /// <summary>
        /// Get a certain cookie.
        /// </summary>
        /// <param name="cookieName">The name of the cookie of interest.</param>
        /// <returns>The cookie, if any.</returns>
        HttpCookie GetCookie(string cookieName);

        /// <summary>
        /// Get the value of a certain cookie.
        /// </summary>
        /// <param name="cookieName">The name of the cookie of interest.</param>
        /// <returns>The value of the cookie, if any.</returns>
        string GetCookieValue(string cookieName);

        /// <summary>
        /// Get the typed value of a certain cookie.
        /// </summary>
        /// <typeparam name="T">The type of data.</typeparam>
        /// <param name="cookieName">The name of the cookie of interest.</param>
        /// <returns>The value of the cookie, if any.</returns>
        T GetCookieValue<T>(string cookieName);

        /// <summary>
        /// Set the value of a cookie.
        /// </summary>
        /// <param name="cookieName">The name of the cookie of interest.</param>
        /// <param name="data">The data to store in the cookie.</param>
        void SetCookieValue(string cookieName, object data);

        /// <summary>
        /// Set the value of a cookie.
        /// </summary>
        /// <param name="cookieName">The name of the cookie of interest.</param>
        /// <param name="data">The data to store in the cookie.</param>
        /// <param name="expires">When the cookie data expires.</param>
        void SetCookieValue(string cookieName, object data, DateTime? expires);
    }
}
