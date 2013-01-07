using System.Collections.Generic;
using System.Linq;

namespace NExtra.Extensions
{
    /// <summary>
    /// Extension methods for System.Collections.Generic.IDictionary.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public static class IDictionaryExtensions
    {
        ///<summary>
        /// Add a range of items to a dictionary.
        ///</summary>
        public static void AddRange<T, K>(this IDictionary<T, K> dictionary, IDictionary<T, K> range)
        {
            foreach (var dictionaryEntry in range.Where(dictionaryEntry => !dictionary.ContainsKey(dictionaryEntry.Key)))
            {
                dictionary.Add(dictionaryEntry);
            }
        }
        
        /// <summary>
        /// Retrieve a value from the dictionary.
        /// </summary>
        public static K Get<T, K>(this IDictionary<T, K> dictionary, T key)
        {
            return dictionary[key];
        }
    }
}
