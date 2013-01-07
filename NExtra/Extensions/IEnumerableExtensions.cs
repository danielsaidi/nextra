using System.Collections.Generic;
using System.Linq;

namespace NExtra.Extensions
{
	/// <summary>
	/// Extension methods for System.Collections.Generic.IEnumerable.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Check whether or not an IEnumerable contains a certain value.
        /// </summary>
        public static bool Contains<T>(this IEnumerable<T> source, T value, bool handleNullSource)
        {
            if (handleNullSource && source == null)
                return false;
            return source.Contains(value);
        }

        /// <summary>
        /// Check whether or not an IEnumerable is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || source.Count() == 0;
        }
        
        /// <summary>
        /// Check whether or not an IEnumerable contains exactly one element.
        /// </summary>
        public static bool IsSingle<T>(this IEnumerable<T> source)
        {
            return source.Count() == 1;
        }

        /// <summary>
        /// Sort an IEnumerable, ascending by any property.
        /// </summary>
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, string propertyName)
        {
            return source.AsQueryable().OrderBy(propertyName);
        }

        /// <summary>
        /// Sort an IEnumerable, descending by any property.
        /// </summary>
        public static IEnumerable<T> OrderByDescending<T>(this IEnumerable<T> source, string propertyName)
        {
            return source.AsQueryable().OrderByDescending(propertyName);
        }

        /// <summary>
        /// Paginate an IEnumerable.
        /// </summary>
        /// <param name="source">The IEnumerable to paginate.</param>
        /// <param name="pageNumber">The page number for the items to retrieve, starting at 1.</param>
        /// <param name="pageSize">The max numbers of items that are displayed per page.</param>
        /// <returns>The resulting value.</returns>
		public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
        {
			return source.AsQueryable().Paginate(pageNumber, pageSize);
        }

        /// <summary>
        /// Continue sorting an IQueryable, ascending by any property.
        /// </summary>
        public static IEnumerable<T> ThenBy<T>(this IEnumerable<T> source, string propertyName)
        {
            return source.AsQueryable().ThenBy(propertyName);
        }

        /// <summary>
        /// Continue sorting an IQueryable, descending by any property.
        /// </summary>
        public static IEnumerable<T> ThenByDescending<T>(this IEnumerable<T> source, string propertyName)
        {
            return source.AsQueryable().ThenByDescending(propertyName);
        }
    }
}
