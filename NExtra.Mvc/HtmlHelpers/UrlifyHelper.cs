using System.Web.Mvc;
using NExtra.Url;

namespace NExtra.Mvc.HtmlHelpers
{
    /// <summary>
    /// This helper class can be used to urlify strings,
    /// using a custom string urlifier. You can use the
    /// one in NExtra.Url or create one of your own.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// Make sure to set the Urlifier property when the
    /// application starts, and you are good to go.
    /// </remarks>
    public static class UrlifyHelper
    {
        public static IUrlifier<string> Urlifier { get; set; }


        public static string Urlify(this HtmlHelper helper, string str)
        {
            return Urlifier.Urlify(str);
        }
    }
}
