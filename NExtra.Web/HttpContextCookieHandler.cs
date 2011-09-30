using System;
using System.Web;
using System.Web.Script.Serialization;
using NExtra.Web.Abstractions;

namespace NExtra.Web
{
    /// <summary>
    /// This class is a shortcut to working with cookies for the
    /// current HttpContext. It supports strongly typed data, so
    /// make sure to keep within the cookie size limit.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class HttpContextCookieHandler : ICanHandleCookies
    {
        /// <summary>
        /// Check whether or not a certain cookie exists.
        /// </summary>
        /// <param name="cookieName">The name of the cookie.</param>
        /// <returns>Whether or not the cookie exists.</returns>
        public bool CookieExists(string cookieName)
        {
            return GetCookie(cookieName) != null;
        }

        /// <summary>
        /// Get a certain cookie.
        /// </summary>
        /// <param name="cookieName">The name of the cookie.</param>
        /// <returns>The cookie, if any.</returns>
        public HttpCookie GetCookie(string cookieName)
        {
            return HttpContext.Current.Request.Cookies[cookieName];
        }

        /// <summary>
        /// Get the string value of a certain cookie.
        /// </summary>
        /// <param name="cookieName">The name of the cookie.</param>
        /// <returns>The string value of the cookie.</returns>
        public string GetCookieValue(string cookieName)
        {
            return GetCookieValue<string>(cookieName);
        }

        /// <summary>
        /// Get the value of a certain cookie.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="cookieName">The name of the cookie.</param>
        /// <returns>The string value of the cookie.</returns>
        public T GetCookieValue<T>(string cookieName)
        {
            var cookie = GetCookie(cookieName);
            if (cookie == null || cookie.Value == null)
                return default(T);

            var serializer = new JavaScriptSerializer();

            return serializer.Deserialize<T>(cookie.Value);
        }

        /// <summary>
        /// Add a cookie that expires together with the current session.
        /// </summary>
        /// <param name="cookieName">The name of the cookie.</param>
        /// <param name="data">The data to store in the cookie.</param>
        public void SetCookieValue(string cookieName, object data)
        {
            SetCookieValue(cookieName, data, null);
        }

        /// <summary>
        /// Add a cookie with an optional expiration date.
        /// </summary>
        /// <param name="cookieName">The name of the cookie.</param>
        /// <param name="data">The data to store in the cookie.</param>
        /// <param name="expires">The optional date and time when the cookie expires.</param>
        public void SetCookieValue(string cookieName, object data, DateTime? expires)
        {
            var serializer = new JavaScriptSerializer();

            var cookie = new HttpCookie(cookieName) { Value = serializer.Serialize(data), Path = "/" };
            if (expires.HasValue)
                cookie.Expires = expires.Value;

            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}
