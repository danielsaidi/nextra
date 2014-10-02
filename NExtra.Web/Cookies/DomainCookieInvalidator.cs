using System.Web;

namespace NExtra.Web.Cookies
{
    /// <summary>
    /// This class can be used to invalidate HTTP cookies
    /// for a certain domain. If the domain host does not
    /// match the host of the current request, no cookies
    /// will be invalidated.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class DomainCookieInvalidator : ICookieInvalidator
    {
        private readonly string _domainHost;
        private readonly HttpContextBase _httpContext;
        private readonly IHttpCookieHandler _cookieHandler;


        public DomainCookieInvalidator(string domainHost, HttpContext httpContext, IHttpCookieHandler cookieHandler)
            : this(domainHost, new HttpContextWrapper(httpContext), cookieHandler)
        {
        }

        public DomainCookieInvalidator(string domainHost, HttpContextBase httpContext, IHttpCookieHandler cookieHandler)
        {
            _domainHost = domainHost;
            _httpContext = httpContext;
            _cookieHandler = cookieHandler;
        }


        public void InvalidateAllCookies()
        {
            foreach (string cookieName in _cookieHandler.GetRequestCookies())
                InvalidateCookie(cookieName);
        }

        public void InvalidateCookie(string cookieName)
        {
            if (_httpContext == null || _httpContext.Request == null || _httpContext.Request.Url == null)
                return;

            if (_domainHost != _httpContext.Request.Url.Host)
                return;
            
            _cookieHandler.InvalidateCookie(cookieName);
        }
    }
}
