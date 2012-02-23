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
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public class DomainHttpCookieInvalidator : IHttpCookieInvalidator
    {
        private readonly string domainHost;
        private readonly HttpContextBase httpContext;
        private readonly IHttpCookieHandler cookieHandler;


        /// <summary>
        /// Create a default instance that uses the current HttpContext.
        /// </summary>
        /// <param name="domainHost">The required request host.</param>
        /// <param name="cookieHandler">The cookie handler to use for invalidating the cookies.</param>
        public DomainHttpCookieInvalidator(string domainHost, IHttpCookieHandler cookieHandler)
            : this(domainHost, new HttpContextWrapper(HttpContext.Current), cookieHandler)
        {
        }

        /// <summary>
        /// Create a custom instance that uses a custom HttpContextBase.
        /// </summary>
        /// <param name="domainHost">The required request host.</param>
        /// <param name="httpContext">The HTTP context to use.</param>
        /// <param name="cookieHandler">The cookie handler to use for invalidating the cookies.</param>
        public DomainHttpCookieInvalidator(string domainHost, HttpContextBase httpContext, IHttpCookieHandler cookieHandler)
        {
            this.domainHost = domainHost;
            this.httpContext = httpContext;
            this.cookieHandler = cookieHandler;
        }


        public void InvalidateAllCookies()
        {
            if (!IsValidContext(httpContext, domainHost))
                return;

            foreach (string cookieName in cookieHandler.GetRequestCookies())
                cookieHandler.InvalidateCookie(cookieName);
        }

        public void InvalidateCookie(string cookieName)
        {
            if (!IsValidContext(httpContext, domainHost))
                return;
            
            cookieHandler.InvalidateCookie(cookieName);
        }


        /// <summary>
        /// Check if a certain HTTP context is valid for a required domain host condition.
        /// </summary>
        public static bool IsValidContext(HttpContextBase httpContext, string domainHost)
        {
            if (httpContext == null || httpContext.Request == null || httpContext.Request.Url == null)
                return false;

            return domainHost == httpContext.Request.Url.Host;
        }
    }
}
