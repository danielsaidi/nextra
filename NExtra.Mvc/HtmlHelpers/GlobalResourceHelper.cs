using System.Web;
using System.Web.Mvc;

namespace NExtra.Mvc.HtmlHelpers
{
    /// <summary>
    /// This helper can be used to work with global resource files.
    /// 
    /// The helper will automatically adjust resource file values
    /// for display. For example, line feeds are replaced with br
    /// tags.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class GlobalResourceHelper
    {
        /// <summary>
        /// Adjust a global resource file value for display.
        /// </summary>
        /// <param name="helper">HtmlHelper instance.</param>
        /// <param name="str">The resource file value to adjust.</param>
        /// <returns>The HTML formatted result.</returns>
        public static IHtmlString GlobalResource(this HtmlHelper helper, string str)
        {
            return ResourceStringHelper.ToHtml(helper, str);
        }
    }
}
