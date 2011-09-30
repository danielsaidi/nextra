using System;
using System.Web;

namespace NExtra.Web.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to determine whether or not HTML5
    /// is supported for various resources.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public interface ICanDetermineHtml5ElementSupport
    {
        /// <summary>
        /// Check whether or not HTML5 is supported.
        /// </summary>
        /// <returns>Whether or not HTML5 is supported.</returns>
        bool HasHtml5ElementSupport();

        /// <summary>
        /// Check whether or not HTML5 is supported for a certain HTTP context.
        /// </summary>
        /// <param name="httpContext">The HTTP context of interest.</param>
        /// <returns>Whether or not HTML5 is supported for the HTTP context.</returns>
        bool HasHtml5ElementSupport(HttpContext httpContext);
        
        /// <summary>
        /// Check whether or not HTML5 is supported for a certain browser.
        /// </summary>
        /// <param name="browser">The browser of interest.</param>
        /// <returns>Whether or not HTML5 is supported for the browser.</returns>
        bool HasHtml5ElementSupport(HttpBrowserCapabilities browser);

        /// <summary>
        /// Check whether or not HTML5 is supported for a certain browser version.
        /// </summary>
        /// <param name="browserName">The name of the browser.</param>
        /// <param name="browserVersion">The browser version.</param>
        /// <returns>Whether or not HTML5 is supported for the browser version.</returns>
        bool HasHtml5ElementSupport(string browserName, Version browserVersion);
    }
}
