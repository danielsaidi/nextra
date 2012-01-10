using System.Web;
using System.Web.Mvc;

namespace NExtra.Mvc.HtmlHelpers
{
    /// <summary>
    /// This helper can be used to handle global resources for views.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
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
