using System;
using System.Web;
using System.Web.Mvc;

namespace NExtra.Mvc.HtmlHelpers
{
    /// <summary>
    /// This helper can be used to handle resource values
    /// in view context.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class ResourceFileValueHelper
    {
        /// <summary>
        /// Format a resource string for HTML display. For
        /// now, it will only convert new lines to br tags.
        /// </summary>
        public static IHtmlString ResourceFileValueToHtml(HtmlHelper helper, string str)
        {
            var formattedString = str.Replace(Environment.NewLine, "<br/>");

            return helper.Raw(formattedString);
        }
    }
}
