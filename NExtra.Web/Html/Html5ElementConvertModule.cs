using System;
using System.Web;

namespace NExtra.Web.Html
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
    /// Link:       http://www.dotnextra.com
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
        public void Init(HttpApplication application)
        {
            application.BeginRequest += Application_BeginRequest;
        }


        /// <summary>
        /// This event is called when the application begins a request.
        /// </summary>
        private static void Application_BeginRequest(object sender, EventArgs e)
        {
            var current = HttpContext.Current;
            current.Response.Filter = new Html5ElementConvertFilter(current.Response.Filter);
        }
    }
}
