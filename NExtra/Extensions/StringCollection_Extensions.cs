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
        /// <summary>
        /// Convert a string collection to an IEnumerable.
        /// </summary>
        public static IEnumerable<string> AsEnumerable(this StringCollection collection)
        {
            return collection == null ? null : collection.Cast<string>().ToList();
        }

        /// <summary>
        /// Check whether or not a string collection is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty(this StringCollection collection)
        {
            return collection == null || collection.Count == 0;
        }
    }
}
