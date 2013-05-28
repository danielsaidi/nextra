using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace NExtra.Extensions
{
    /// <summary>
    /// Extension methods for System.Collections.Specialized.NameValueCollection.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class NameValueCollection_Extensions
    {
        public static IEnumerable<KeyValuePair<string, string>> AsKeyValuePairs(this NameValueCollection collection)
        {
            return collection.AllKeys.Select(key => new KeyValuePair<string, string>(key, collection.Get(key)));
        }

        public static string TryGetValue(this NameValueCollection collection, string key, string fallback)
        {
            return collection[key] ?? fallback;
        }
    }
}
