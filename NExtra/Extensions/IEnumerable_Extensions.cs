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
            return source == null || !source.Any();
        }
    }
}
