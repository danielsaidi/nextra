using System;
using System.Collections.Generic;
using NExtra.Cache.Abstractions;

namespace NExtra.Cache
{
    /// <summary>
    /// This is a really simple cache that stores data
    /// in a dictionary. It should only be used for an
    /// extremely trivial caching scenario.
    /// </summary>
    public class DictionaryCache : ICacheManager
    {
        private readonly Dictionary<string, DictionaryCacheItem> cache;

        public DictionaryCache()
        {
            cache = new Dictionary<string, DictionaryCacheItem>();
        }


        public bool Contains(string key)
        {
            RemoveIfInvalid(key);
            return cache.ContainsKey(key);
        }

        public void Clear()
        {
            cache.Clear();
        }

        public T Get<T>(string key)
        {
            RemoveIfInvalid(key);
            return (T)cache[key].Obj;
        }

        public T Get<T>(string key, T fallback)
        {
            return !Contains(key) ? fallback : Get<T>(key);
        }

        public bool IsValid(string key)
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

        /// <summary>
        /// Insert a value into the cache, using a custom timeout.
        /// </summary>
        public void Set(string key, object value, TimeSpan timeout)
        {
            cache[key] = new DictionaryCacheItem(value, DateTime.Now.Add(timeout));
        }
    }

    
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
