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
        private readonly string domainHost;
        private readonly HttpContextBase httpContext;
        private readonly IHttpCookieHandler cookieHandler;


        /// <summary>
        /// Create an instance that uses the current HttpContext.
        /// </summary>
        /// <param name="domainHost">The domain host of interest, e.g. foo.bar.com.</param>
        /// <param name="httpContext">The HTTP context to use.</param>
        /// <param name="cookieHandler">The cookie handler to use for cookie invalidation.</param>
        public DomainCookieInvalidator(string domainHost, HttpContext httpContext, IHttpCookieHandler cookieHandler)
            : this(domainHost, new HttpContextWrapper(httpContext), cookieHandler)
        {
        }

        /// <summary>
        /// Create an instance that uses a custom HttpContextBase.
        /// </summary>
        /// <param name="domainHost">The domain host of interest, e.g. foo.bar.com.</param>
        /// <param name="httpContext">The HTTP context to use.</param>
        /// <param name="cookieHandler">The cookie handler to use for cookie invalidation.</param>
        public DomainCookieInvalidator(string domainHost, HttpContextBase httpContext, IHttpCookieHandler cookieHandler)
        {
            this.domainHost = domainHost;
            this.httpContext = httpContext;
            this.cookieHandler = cookieHandler;
        }


        /// <summary>
        /// Invalidate all existing cookies.
        /// </summary>
        public void InvalidateAllCookies()
        {
            foreach (string cookieName in cookieHandler.GetRequestCookies())
                InvalidateCookie(cookieName);
        }

        /// <summary>
        /// Invalidate a certain cookie.
        /// </summary>
        public void InvalidateCookie(string cookieName)
        {
            if (httpContext == null || httpContext.Request == null || httpContext.Request.Url == null)
                return;

            if (domainHost != httpContext.Request.Url.Host)
                return;
            
            cookieHandler.InvalidateCookie(cookieName);
        }
    }
}
