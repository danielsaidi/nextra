using System;
using System.Web;

namespace NExtra.Web.Html
{
    /// <summary>
    /// This class can determine whether or not the current
    /// context or browser supports HTML5 elements like nav,
    /// section etc. For now, it only considers IE8 and the
    /// earlier versions of IE to not support HTML5.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public class Html5ElementSupportEvaluator : IHtml5ElementSupportEvaluator
    {
        /// <summary>
        /// Check whether or not the current HTTP context supports HTML5.
        /// </summary>
        public bool HasHtml5ElementSupport()
        {
            return HasHtml5ElementSupport(HttpContext.Current);
        }

        /// <summary>
        /// Check whether or not a certain HTTP context supports HTML5.
        /// </summary>
        public bool HasHtml5ElementSupport(HttpContext httpContext)
        {
            return HasHtml5ElementSupport(httpContext.Request.Browser);
        }

        /// <summary>
        /// Check whether or not a certain browser supports HTML5.
        /// </summary>
        public bool HasHtml5ElementSupport(HttpBrowserCapabilities browser)
        {
            return HasHtml5ElementSupport(browser.Browser, new Version(browser.Version));
        }

        /// <summary>
        /// Check whether or not a certain browser supports HTML5.
        /// </summary>
        public bool HasHtml5ElementSupport(string browser, Version browserVersion)
        {
            switch (browser)
            {
                case "IE":
                    return browserVersion >= new Version(9, 0, 0, 0);
                default:
                    return true;
            }
        }
    }
}
