using System.Web;
using System.Web.Mvc;
using NExtra.Localization;

namespace NExtra.Mvc.HtmlHelpers
{
    /// <summary>
    /// This helper class can be used to translate stuff,
    /// using a custom translator. You can use anyone of
    /// the ones in NExtra.Localization or create one of
    /// your own.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// Make sure to set up the ITranslator property when
    /// the application starts and you are good to go.
    /// </remarks>
    public static class TranslateHelper
    {
        public static ITranslator Translator { get; set; }


        public static IHtmlString Translate(this HtmlHelper helper, string resourceKey)
        {
            var translation = Translator.Translate(resourceKey);

            return ResourceFileValueHelper.ResourceFileValueToHtml(helper, translation);
        }
    }
}
