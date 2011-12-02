using System;
using System.Linq;
using System.Runtime.Caching;
using NExtra.Cache.Abstractions;

namespace NExtra.Cache
{
    /// <summary>
    /// This class can be used as a facade for the default
    /// System.Runtime.Caching.MemoryCache instance.
    /// </summary>
    public class MemoryCacheFacade : ICache
    {
        private readonly MemoryCache cache;


        public MemoryCacheFacade()
        {
            cache = MemoryCache.Default;
        }


        /// <summary>
        /// Clear the entire cache.
        /// </summary>
        public void Clear()
        {
            foreach (var key in cache.Select(item => item.Key).ToList())
                cache.Remove(key);
        }

        /// <summary>
        /// Check whether or not a certain cache key exists.
        /// </summary>
        public bool Contains(string key)
        {
            return cache.Contains(key);
        }

        /// <summary>
        /// Retrieve a certain cached value.
        /// </summary>
        public object Get(string key)
        {
            return cache.Get(key);
        }

        /// <summary>
        /// Retrieve a certain, typed cached value.
        /// </summary>
        public T Get<T>(string key)
        {
            return (T)Get(key);
        }

        /// <summary>
        /// Remove a certain cached value.
        /// </summary>
        public void Remove(string key)
        {
            cache.Remove(key);
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
            cache.Set(key, value, new DateTimeOffset(DateTime.Now, timeout));
        }

        /// <summary>
        /// Retrieve a certain, typed cached value with a fallback value.
        /// </summary>
        public T TryGet<T>(string key, T fallback)
        {
            return !Contains(key) ? fallback : Get<T>(key);
        }
    }
}
