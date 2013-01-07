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
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class HttpContextCookieHandler : IHttpCookieHandler
    {
        private readonly HttpContextBase httpContext;


        /// <summary>
        /// Create a default instance that uses the current HttpContext.
        /// </summary>
        public HttpContextCookieHandler(HttpContext httpContext)
            : this(new HttpContextWrapper(httpContext))
        {
        }

        /// <summary>
        /// Create a custom instance that uses a custom HttpContextBase.
        /// </summary>
        public HttpContextCookieHandler(HttpContextBase httpContext)
        {
            this.httpContext = httpContext;
        }


        /// <summary>
        /// Add a custom cookie to the current request and response.
        /// </summary>
        public void AddCookie(HttpCookie cookie)
        {
            httpContext.Request.Cookies.Remove(cookie.Name);
            httpContext.Response.Cookies.Remove(cookie.Name);

            httpContext.Request.Cookies.Add(cookie);
            httpContext.Response.Cookies.Add(cookie);
        }

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
            return httpContext.Request.Cookies[cookieName];
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
        /// Get all cookies that are sent from the client.
        /// </summary>
        public HttpCookieCollection GetRequestCookies()
        {
            return httpContext.Request.Cookies;
        }

        /// <summary>
        /// Get all cookies that will be sent to the client.
        /// </summary>
        public HttpCookieCollection GetResponseCookies()
        {
            return httpContext.Response.Cookies;
        }

        /// <summary>
        /// Invalidate a certain cookie by setting the value
        /// to null and expires to an already passed day.
        /// </summary>
        /// <param name="cookieName"></param>
        public void InvalidateCookie(string cookieName)
        {
            SetCookieValue(cookieName, "", DateTime.MinValue);
        }

        /// <summary>
        /// Set a cookie value with a session-based expire time.
        /// To make the get methods work, tha method will set a
        /// cookie in both the response and request collections.
        /// </summary>
        public void SetCookieValue(string cookieName, object data)
        {
            SetCookieValue(cookieName, data, null);
        }

        /// <summary>
        /// Set a cookie value with an optional expiration date.
        /// To make the get methods work, tha method will set a
        /// cookie in both the response and request collections.
        /// </summary>
        public void SetCookieValue(string cookieName, object data, DateTime? expires)
        {
            var serializer = new JavaScriptSerializer();

            var cookie = new HttpCookie(cookieName) { Value = serializer.Serialize(data), Path = "/" };
            if (expires.HasValue)
                cookie.Expires = expires.Value;

            AddCookie(cookie);
        }
    }
}
