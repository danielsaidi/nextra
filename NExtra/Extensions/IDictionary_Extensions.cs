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
    public static class IDictionary_Extensions
    {
        public static void AddRange<TK, TV>(this IDictionary<TK, TV> dictionary, IDictionary<TK, TV> range)
        {
            foreach (var dictionaryEntry in range.Where(dictionaryEntry => !dictionary.ContainsKey(dictionaryEntry.Key)))
            {
                dictionary.Add(dictionaryEntry);
            }
        }
        
        public static TV Get<TK, TV>(this IDictionary<TK, TV> dictionary, TK key)
        {
            return dictionary[key];
        }
    }
}
