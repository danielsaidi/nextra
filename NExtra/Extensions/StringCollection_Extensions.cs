using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace NExtra.Extensions
{
	/// <summary>
    /// Extension methods for System.Collections.Specialized.StringCollection.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class StringCollection_Extensions
    {
        public static IEnumerable<string> AsEnumerable(this StringCollection collection)
        {
            return collection == null ? null : collection.Cast<string>().ToList();
        }

        public static bool IsNullOrEmpty(this StringCollection collection)
        {
            return collection == null || collection.Count == 0;
        }
    }
}
