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
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class StringCollectionExtensions
    {
        /// <summary>
        /// Convert a string collection to an IEnumerable.
        /// </summary>
        /// <param name="collection">The collection of interest.</param>
        /// <returns>The resulting IEnumerable.</returns>
        public static IEnumerable<string> AsEnumerable(this StringCollection collection)
        {
            return collection == null ? null : collection.Cast<string>().ToList();
        }

        /// <summary>
        /// Check whether or not a string collection is null or empty.
        /// </summary>
		/// <param name="collection">The collection of interest.</param>
		/// <returns>Whether or not the collection is empty.</returns>
        public static bool IsNullOrEmpty(this StringCollection collection)
        {
            return collection == null || collection.Count == 0;
        }
    }
}
