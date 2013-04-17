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
    public static class IEnumerable_Extensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || source.Count() == 0;
        }

        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, string propertyName)
        {
            return source.AsQueryable().OrderBy(propertyName);
        }

        public static IEnumerable<T> OrderByDescending<T>(this IEnumerable<T> source, string propertyName)
        {
            return source.AsQueryable().OrderByDescending(propertyName);
        }

        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
        {
			return source.AsQueryable().Paginate(pageNumber, pageSize);
        }

        public static IEnumerable<T> ThenBy<T>(this IEnumerable<T> source, string propertyName)
        {
            return source.AsQueryable().ThenBy(propertyName);
        }

        public static IEnumerable<T> ThenByDescending<T>(this IEnumerable<T> source, string propertyName)
        {
            return source.AsQueryable().ThenByDescending(propertyName);
        }
    }
}
