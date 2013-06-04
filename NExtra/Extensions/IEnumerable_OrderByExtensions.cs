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
    public static class IEnumerable_OrderByExtensions
    {
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, string propertyName)
        {
            return source.AsQueryable().OrderBy(propertyName);
        }

        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, string propertyName, bool descending)
        {
            return descending ? source.OrderBy(propertyName) : source.OrderByDescending(propertyName);
        }

        public static IEnumerable<T> OrderByDescending<T>(this IEnumerable<T> source, string propertyName)
        {
            return source.AsQueryable().OrderByDescending(propertyName);
        }

        public static IEnumerable<T> ThenBy<T>(this IEnumerable<T> source, string propertyName)
        {
            return source.AsQueryable().ThenBy(propertyName);
        }

        public static IEnumerable<T> ThenBy<T>(this IEnumerable<T> source, string propertyName, bool descending)
        {
            return descending ? source.ThenBy(propertyName) : source.ThenByDescending(propertyName);
        }

        public static IEnumerable<T> ThenByDescending<T>(this IEnumerable<T> source, string propertyName)
        {
            return source.AsQueryable().ThenByDescending(propertyName);
        }
    }
}
