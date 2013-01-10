using System.Web;
using System.Web.Mvc;

namespace NExtra.Mvc.HtmlHelpers
{
    /// <summary>
    /// This helper can be used to access global resource
    /// values from within views.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class GlobalResourceHelper
    {
        /// <summary>
        /// Format a global resource value for display.
        /// </summary>
        public static IHtmlString GlobalResource(this HtmlHelper helper, string resource)
        {
            return ResourceFileValueHelper.ResourceFileValueToHtml(helper, resource);
        }
    }
}
