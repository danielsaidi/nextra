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
    public class DictionaryCache : ICache
    {
        private readonly Dictionary<string, DictionaryCacheItem> cache;


        public DictionaryCache()
        {
            cache = new Dictionary<string, DictionaryCacheItem>();
        }


        /// <summary>
        /// Clear the entire cache.
        /// </summary>
        public void Clear()
        {
            cache.Clear();
        }

        /// <summary>
        /// Check whether or not a certain cache key exists.
        /// </summary>
        public bool Contains(string key)
        {
            RemoveIfInvalid(key);
            return cache.ContainsKey(key);
        }

        /// <summary>
        /// Retrieve a certain cached value.
        /// </summary>
        public object Get(string key)
        {
            RemoveIfInvalid(key);
            return cache[key].Obj;
        }

        /// <summary>
        /// Retrieve a certain, typed cached value.
        /// </summary>
        public T Get<T>(string key)
        {
            return (T)Get(key);
        }

        /// <summary>
        /// Check whether or not a cache key is valid.
        /// </summary>
        private bool IsValid(string key)
        {
            return cache[key].Expires > DateTime.Now;
        }

        /// <summary>
        /// Remove a certain cached value.
        /// </summary>
        public void Remove(string key)
        {
            cache.Remove(key);
        }

        /// <summary>
        /// Remove a cached value, if it is invalid.
        /// </summary>
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

        /// <summary>
        /// Try to retrieve a certain, typed cached value.
        /// </summary>
        public T TryGet<T>(string key, T fallback)
        {
            return !Contains(key) ? fallback : Get<T>(key);
        }
    }

    
    /// <summary>
    /// This internal class is what is stored by this cache.
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
