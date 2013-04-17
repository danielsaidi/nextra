using System;
using System.Web;

namespace NExtra.Web.Cookies
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can be used to handle HTTP cookies.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IHttpCookieHandler
    {
        void AddCookie(HttpCookie cookie);
        bool CookieExists(string cookieName);
        HttpCookie GetCookie(string cookieName);
        string GetCookieValue(string cookieName);
        T GetCookieValue<T>(string cookieName);
        HttpCookieCollection GetRequestCookies();
        HttpCookieCollection GetResponseCookies();
        void InvalidateCookie(string cookieName);
        void SetCookieValue(string cookieName, object data);
        void SetCookieValue(string cookieName, object data, DateTime? expires);
    }
}
