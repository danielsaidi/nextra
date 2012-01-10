using System.Web;
using System.Web.Mvc;

namespace NExtra.Mvc.HtmlHelpers
{
    /// <summary>
    /// This helper can be used to handle local resources for views.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public static class LocalResourceHelper
    {
        /// <summary>
        /// Format a local resource file value for display.
        /// </summary>
        public static IHtmlString LocalResource(this HtmlHelper helper, WebViewPage page, string resourceKeyName)
        {
            var localResource = helper.ViewContext.HttpContext.GetLocalResourceObject(page.VirtualPath, resourceKeyName) as string;

            return ResourceFileValueHelper.ResourceFileValueToHtml(helper, localResource);
        }
    }
}
