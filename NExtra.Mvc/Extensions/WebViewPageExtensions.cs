using System;
using System.Web;
using System.Web.Mvc;

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
        /// <param name="page">The WebViewPage instance that is to display the value.</param>
        /// <param name="str">The resource file value to format.</param>
        /// <returns>The formatted result.</returns>
        public static IHtmlString GlobalResource(this WebViewPage page, string str)
        {
            return page.Html.ResourceString(str);
        }

        /// <summary>
        /// Format a local resource file value for display.
        /// </summary>
        /// <param name="page">The WebViewPage instance that is to display the value.</param>
        /// <param name="key">The name of the local resource file value to format.</param>
        /// <returns>The formatted result.</returns>
        public static IHtmlString LocalResource(this WebViewPage page, string key)
        {
            var str = page.Html.ViewContext.HttpContext.GetLocalResourceObject(page.VirtualPath, key) as string;

            return page.Html.ResourceString(str);
        }


        /// <summary>
        /// Format a resource file value for display.
        /// </summary>
        /// <param name="helper">The HtmlHelper instance to use for formatting.</param>
        /// <param name="str">The resource file value of interest.</param>
        /// <returns>The formatted result.</returns>
        private static IHtmlString ResourceString(this HtmlHelper helper, string str)
        {
            return helper.Raw(str.Replace(Environment.NewLine, "<br/>"));
        }
    }
}
