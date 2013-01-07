using System;
using System.Web;

namespace NExtra.Web.Html
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can determine if HTML5 is supported.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IHtml5ElementSupportEvaluator
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
