using System.Collections.Generic;
using System.Web.Mvc;

namespace NExtra.Mvc.Extensions
{
    /// <summary>
    /// SelectList-related extension for IEnumerable, to
    /// convert various collection types to SelectLists.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class IEnumerable_SelectListExtensions
    {
        public static SelectList ToSelectList(this IEnumerable<string> list)
        {
            IDictionary<string, string> collection = new Dictionary<string, string>();
            foreach (var str in list)
                collection.Add(str, str);

            return new SelectList(collection, "Key", "Value", "SelectedValue");
        }
    }
}
