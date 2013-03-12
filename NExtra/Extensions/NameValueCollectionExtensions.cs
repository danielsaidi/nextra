using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace NExtra.Extensions
{
    /// <summary>
    /// This class contains a set of extension methods for
    /// System.Collections.Specialized.NameValueCollection.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class NameValueCollectionExtensions
    {
        public static string TryGetValue(this NameValueCollection collection, string key, string fallback)
        {
            return collection[key] ?? fallback;
        }
    }
}
