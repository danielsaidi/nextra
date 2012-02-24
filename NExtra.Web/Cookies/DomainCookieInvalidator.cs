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
            if (!IsValidContextBase(httpContext, domainHost))
                return;

            foreach (string cookieName in cookieHandler.GetRequestCookies())
                cookieHandler.InvalidateCookie(cookieName);
        }

        /// <summary>
        /// Invalidate a certain cookie.
        /// </summary>
        public void InvalidateCookie(string cookieName)
        {
            if (!IsValidContextBase(httpContext, domainHost))
                return;
            
            cookieHandler.InvalidateCookie(cookieName);
        }

        /// <summary>
        /// Check if a certain HTTP context is valid for a
        /// required domain host condition. This method is
        /// convenient to use if the class is used in each
        /// request, to avoid creating unneeded instances.
        /// </summary>
        public static bool IsValidContext(HttpContext httpContext, string domainHost)
        {
            if (httpContext == null)
                return false;

            return domainHost == httpContext.Request.Url.Host;
        }

        /// <summary>
        /// Check if a certain HTTP context is valid for a
        /// required domain host condition. This method is
        /// convenient to use if the class is used in each
        /// request, to avoid creating unneeded instances.
        /// </summary>
        public static bool IsValidContextBase(HttpContextBase httpContext, string domainHost)
        {
            if (httpContext == null || httpContext.Request == null || httpContext.Request.Url == null)
                return false;

            return domainHost == httpContext.Request.Url.Host;
        }
    }
}
