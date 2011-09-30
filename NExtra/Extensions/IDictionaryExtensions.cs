using System.Collections.Generic;
using System.Linq;

namespace NExtra.Extensions
{
    /// <summary>
    /// Extension methods for System.Collections.Generic.IDictionary.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class IDictionaryExtensions
    {
        ///<summary>
        /// Add a range of items to a dictionary.
        ///</summary>
        ///<param name="dictionary">The dictionary to add the range to.</param>
        ///<param name="range">The range of items to add.</param>
        ///<typeparam name="T">The key type.</typeparam>
        ///<typeparam name="K">The value type.</typeparam>
        public static void AddRange<T, K>(this IDictionary<T, K> dictionary, IDictionary<T, K> range)
        {
            foreach (var dictionaryEntry in range.Where(dictionaryEntry => !dictionary.ContainsKey(dictionaryEntry.Key)))
            {
                dictionary.Add(dictionaryEntry);
            }
        }
    }
}
