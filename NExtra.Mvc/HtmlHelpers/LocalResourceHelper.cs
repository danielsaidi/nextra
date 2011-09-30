using System.Web;
using System.Web.Mvc;

namespace NExtra.Mvc.HtmlHelpers
{
    /// <summary>
    /// This helper can be used to work with local resource files.
    /// 
    /// The helper will automatically adjust resource file values
    /// for display. For example, line feeds are replaced with br
    /// tags.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class LocalResourceHelper
    {
        /// <summary>
        /// Adjust a local resource file value for display.
        /// </summary>
        /// <param name="helper">HtmlHelper instance.</param>
        /// <param name="page">The current page instance.</param>
        /// <param name="key">The resource file key of interest.</param>
        /// <returns>The HTML formatted result.</returns>
        public static IHtmlString LocalResource(this HtmlHelper helper, WebViewPage page, string key)
        {
            var str = helper.ViewContext.HttpContext.GetLocalResourceObject(page.VirtualPath, key) as string;

            return ResourceStringHelper.ToHtml(helper, str);
        }
    }
}
