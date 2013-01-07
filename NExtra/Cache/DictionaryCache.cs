using System;
using System.Collections.Generic;

namespace NExtra.Cache
{
    /// <summary>
    /// This is a really simple ICache implementation that caches
    /// data in a memory dictionary. It requires no configuration
    /// at all, but should only be used in really trivial cases.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class DictionaryCache : ICache
    {
        private readonly Dictionary<string, DictionaryCacheItem> cache;


        public DictionaryCache()
        {
            cache = new Dictionary<string, DictionaryCacheItem>();
        }


        public void Clear()
        {
            cache.Clear();
        }

        public bool Contains(string key)
        {
            RemoveIfInvalid(key);
            return cache.ContainsKey(key);
        }

        public object Get(string key)
        {
            RemoveIfInvalid(key);
            return cache[key].Obj;
        }

        public T Get<T>(string key)
        {
            return (T)Get(key);
        }

        private bool IsValid(string key)
        {
            return cache[key].Expires > DateTime.Now;
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }

        private void RemoveIfInvalid(string key)
        {
            if (!cache.ContainsKey(key))
                return;

            if (!IsValid(key))
                Remove(key);
        }

        /// <summary>
        /// Insert a value into the cache, using a default timeout of one hour.
        /// </summary>
        public void Set(string key, object value)
        {
            Set(key, value, new TimeSpan(0, 1, 0, 0));
        }

        public void Set(string key, object value, TimeSpan timeout)
        {
            cache[key] = new DictionaryCacheItem(value, DateTime.Now.Add(timeout));
        }

        public T TryGet<T>(string key, T fallback)
        {
            return !Contains(key) ? fallback : Get<T>(key);
        }
    }

    
    /// <summary>
    /// This internal class is how data is stored in the dictionary cache.
    /// </summary>
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
