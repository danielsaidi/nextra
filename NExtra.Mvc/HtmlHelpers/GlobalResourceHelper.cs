using System.Web;
using System.Web.Mvc;

namespace NExtra.Mvc.HtmlHelpers
{
    /// <summary>
    /// This helper can be used to format global resource
    /// file values to proper HTML.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class GlobalResourceHelper
    {
        public static IHtmlString GlobalResource(this HtmlHelper helper, string resourceKeyName)
        {
            return ResourceFileValueHelper.ResourceFileValueToHtml(helper, resourceKeyName);
        }
    }
}
