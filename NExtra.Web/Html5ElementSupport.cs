using System;
using System.Web;
using NExtra.Web.Abstractions;

namespace NExtra.Web
{
    /// <summary>
    /// This class can determine whether or not the current
    /// context or browser supports HTML5 elements like nav,
    /// section etc.
    /// 
    /// For now, this class will return true if the current
    /// browser is NOT IE8 or below.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class Html5ElementSupport : ICanDetermineHtml5ElementSupport
    {
        /// <summary>
        /// Check whether or not the current HTTP context supports HTML5.
        /// </summary>
        /// <returns>Whether or not the current HTTP context supports HTML5.</returns>
        public bool HasHtml5ElementSupport()
        {
            return HasHtml5ElementSupport(HttpContext.Current);
        }

        /// <summary>
        /// Check whether or not a certain HTTP context supports HTML5.
        /// </summary>
        /// <param name="httpContext">The HTTP context of interest.</param>
        /// <returns>Whether or not the HTTP context supports HTML5.</returns>
        public bool HasHtml5ElementSupport(HttpContext httpContext)
        {
            return HasHtml5ElementSupport(httpContext.Request.Browser);
        }

        /// <summary>
        /// Check whether or not a certain browser supports HTML5.
        /// </summary>
        /// <param name="browser">The browser definition.</param>
        /// <returns>Whether or not the browser supports HTML5.</returns>
        public bool HasHtml5ElementSupport(HttpBrowserCapabilities browser)
        {
            return HasHtml5ElementSupport(browser.Browser, new Version(browser.Version));
        }

        /// <summary>
        /// Check whether or not a certain browser supports HTML5.
        /// </summary>
        /// <param name="browser">The browser definition.</param>
        /// <param name="browserVersion">The browser version.</param>
        /// <returns>Whether or not the browser supports HTML5.</returns>
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
