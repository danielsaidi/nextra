using System;
using System.Web;
using NExtra.Web.ResponseFilters;

namespace NExtra.Web.HttpModules
{
    /// <summary>
    /// This module can be used to automatically convert all HTML5
    /// elements to HTML4 elements if the browser does not support
    /// HTML5 elements.
    /// 
    /// The module initializes a default Html5ElementConvertFilter
    /// instance, which is used to filter the HTML that is sent to
    /// the client. For now, you have to create a new module if it
    /// requires any custom implementations.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public class Html5ElementConvertModule : IHttpModule
    {
        /// <summary>
        /// Dispose the module.
        /// </summary>
        public void Dispose() { }


        /// <summary>
        /// Initialize the module.
        /// </summary>
        /// <param name="application">The HTTP application to which the module should apply.</param>
        public void Init(HttpApplication application)
        {
            application.BeginRequest += application_BeginRequest;
        }


        /// <summary>
        /// This event is called when the application begins a request.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">Event arguments.</param>
        private static void application_BeginRequest(object sender, EventArgs e)
        {
            var current = HttpContext.Current;
            current.Response.Filter = new Html5ElementConvertFilter(current.Response.Filter);
        }
    }
}
