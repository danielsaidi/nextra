using System;
using System.Web;
using System.Web.Mvc;

namespace NExtra.Mvc.HtmlHelpers
{
    /// <summary>
    /// This helper can be used to format a resource file
    /// value to proper HTML.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class ResourceFileValueHelper
    {
        public static IHtmlString ResourceFileValueToHtml(HtmlHelper helper, string str)
        {
            var formattedString = str.Replace(Environment.NewLine, "<br/>");

            return helper.Raw(formattedString);
        }
    }
}
