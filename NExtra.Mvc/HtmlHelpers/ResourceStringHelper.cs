using System;
using System.Web;
using System.Web.Mvc;

namespace NExtra.Mvc.HtmlHelpers
{
    /// <summary>
    /// This helper can be used to convert resource file stings
    /// to HTML prepared strings. For now, it only replaces new
    /// lines with br tags.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// 
    /// This class is used by the GlobalResourceHtmlHelper and
    /// LocalResourceHtmlHelper classes. It should not have to
    /// be used in any other context. If so, the class will be
    /// replaced by a public and more general class.
    /// </remarks>
    internal static class ResourceStringHelper
    {
        /// <summary>
        /// Format a string for HTML display.
        /// </summary>
        /// <param name="helper">HtmlHelper instance.</param>
        /// <param name="str">The string to format.</param>
        /// <returns>The HTML formatted result.</returns>
        internal static IHtmlString ToHtml(HtmlHelper helper, string str)
        {
            return helper.Raw(str.Replace(Environment.NewLine, "<br/>"));
        }
    }
}
