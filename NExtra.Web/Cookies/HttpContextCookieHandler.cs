using System;
using System.Web;
using System.Web.Script.Serialization;

namespace NExtra.Web.Cookies
{
    /// <summary>
    /// This class can be used to work with HTTP context
    /// cookies. It supports strongly typed data, so you
    /// can store complex objects in there as well. Just
    /// make sure to keep within the cookie size limit.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class HttpContextCookieHandler : IHttpCookieHandler
    {
        private readonly HttpContextBase httpContext;


        public HttpContextCookieHandler(HttpContext httpContext)
            : this(new HttpContextWrapper(httpContext))
        {
        }

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
