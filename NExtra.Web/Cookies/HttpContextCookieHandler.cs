using System;
using System.Web;
using System.Web.Script.Serialization;

namespace NExtra.Web.Cookies
{
    /// <summary>
    /// This class is a shortcut to working with cookies for the
    /// current HttpContext. It supports strongly typed data, so
    /// make sure to keep within the cookie size limit.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public class HttpContextCookieHandler : IHttpCookieHandler
    {
        /// <summary>
        /// Check if a certain cookie exists.
        /// </summary>
        public bool CookieExists(string cookieName)
        {
            return GetCookie(cookieName) != null;
        }

        /// <summary>
        /// Get a certain cookie.
        /// </summary>
        public HttpCookie GetCookie(string cookieName)
        {
            return HttpContext.Current.Request.Cookies[cookieName];
        }

        /// <summary>
        /// Get the string value of a certain cookie.
        /// </summary>
        public string GetCookieValue(string cookieName)
        {
            return GetCookieValue<string>(cookieName);
        }

        /// <summary>
        /// Get the typed value of a certain cookie.
        /// </summary>
        public T GetCookieValue<T>(string cookieName)
        {
            var cookie = GetCookie(cookieName);
            if (cookie == null || cookie.Value == null)
                return default(T);

            var serializer = new JavaScriptSerializer();

            return serializer.Deserialize<T>(cookie.Value);
        }

        /// <summary>
        /// Set a cookie value that expires together with the current session.
        /// </summary>
        public void SetCookieValue(string cookieName, object data)
        {
            SetCookieValue(cookieName, data, null);
        }

        /// <summary>
        /// Set a cookie value with an optional expiration date.
        /// </summary>
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
