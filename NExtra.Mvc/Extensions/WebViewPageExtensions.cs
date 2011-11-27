using System.Web;
using System.Web.Mvc;
using NExtra.Mvc.HtmlHelpers;

namespace NExtra.Mvc.Extensions
{
    /// <summary>
    /// Extension methods for System.Web.Mvc.WebViewPage.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class WebViewPageExtensions
    {
        /// <summary>
        /// Format a global resource file value for display.
        /// </summary>
        public static IHtmlString GlobalResource(this WebViewPage page, string resource)
        {
            return page.Html.GlobalResource(resource);
        }

        /// <summary>
        /// Format a local resource file value for display.
        /// </summary>
        public static IHtmlString LocalResource(this WebViewPage page, string resourceKeyName)
        {
            return page.Html.LocalResource(page, resourceKeyName);
        }
    }
}
