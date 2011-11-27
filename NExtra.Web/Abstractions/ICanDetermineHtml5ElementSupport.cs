using System;
using System.Web;

namespace NExtra.Web.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can determine if HTML5 is supported.
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
        bool HasHtml5ElementSupport();

        /// <summary>
        /// Check whether or not HTML5 is supported for a certain HTTP context.
        /// </summary>
        bool HasHtml5ElementSupport(HttpContext httpContext);
        
        /// <summary>
        /// Check whether or not HTML5 is supported for a certain browser.
        /// </summary>
        bool HasHtml5ElementSupport(HttpBrowserCapabilities browser);

        /// <summary>
        /// Check whether or not HTML5 is supported for a certain browser version.
        /// </summary>
        bool HasHtml5ElementSupport(string browserName, Version browserVersion);
    }
}
