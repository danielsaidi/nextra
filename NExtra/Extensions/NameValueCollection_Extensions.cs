using System.Collections.Specialized;

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
        public static string TryGetValue(this NameValueCollection collection, string key, string fallback)
        {
            return collection[key] ?? fallback;
        }
    }
}
