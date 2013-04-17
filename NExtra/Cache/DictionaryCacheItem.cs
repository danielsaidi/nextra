using System;

namespace NExtra.Cache
{
    /// <summary>
    /// This class represents data stored by a dictionary
    /// cache instance.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    internal class DictionaryCacheItem
    {
        public DictionaryCacheItem(object obj, DateTime expires)
        {
            Obj = obj;
            Expires = expires;
        }

        public object Obj { get; set; }
        public DateTime Expires { get; set; }
    }
}