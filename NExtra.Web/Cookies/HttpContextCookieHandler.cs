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


        public void AddCookie(HttpCookie cookie)
        {
            httpContext.Request.Cookies.Remove(cookie.Name);
            httpContext.Response.Cookies.Remove(cookie.Name);

            httpContext.Request.Cookies.Add(cookie);
            httpContext.Response.Cookies.Add(cookie);
        }

        public bool CookieExists(string cookieName)
        {
            return GetCookie(cookieName) != null;
        }

        public HttpCookie GetCookie(string cookieName)
        {
            return httpContext.Request.Cookies[cookieName];
        }

        public string GetCookieValue(string cookieName)
        {
            return GetCookieValue<string>(cookieName);
        }

        public T GetCookieValue<T>(string cookieName)
        {
            var cookie = GetCookie(cookieName);
            if (cookie == null || cookie.Value == null)
                return default(T);

            var serializer = new JavaScriptSerializer();

            return serializer.Deserialize<T>(cookie.Value);
        }

        public HttpCookieCollection GetRequestCookies()
        {
            return httpContext.Request.Cookies;
        }

        public HttpCookieCollection GetResponseCookies()
        {
            return httpContext.Response.Cookies;
        }

        public void InvalidateCookie(string cookieName)
        {
            SetCookieValue(cookieName, "", DateTime.MinValue);
        }

        public void SetCookieValue(string cookieName, object data)
        {
            SetCookieValue(cookieName, data, null);
        }

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
