using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace NExtra.Web.Cache
{
    /// <summary>
    /// This class can be used as a facade for the
    /// HttpRuntime.Cache instance.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public class HttpRuntimeCacheFacade : IHttpRuntimeCache
    {
        /// <summary>
        /// Add a value to the cache.
        /// </summary>
        public object Add(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority)
        {
            return HttpRuntime.Cache.Add(key, value, dependencies, absoluteExpiration, slidingExpiration, priority, null);
        }

        /// <summary>
        /// Clear the entire cache.
        /// </summary>
        public void Clear()
        {
            var allKeys = (from DictionaryEntry entry in HttpRuntime.Cache select (string) entry.Key);

            foreach (var key in allKeys)
            {
                HttpRuntime.Cache.Remove(key);
            }
        }

        /// <summary>
        /// Check whether or not a certain cache key exists.
        /// </summary>
        public bool Contains(string key)
        {
            return HttpRuntime.Cache.Get(key) != null;
        }

        /// <summary>
        /// Retrieve a certain cached value.
        /// </summary>
        public object Get(string key)
        {
            return HttpRuntime.Cache.Get(key);
        }

        /// <summary>
        /// Retrieve a certain, typed cached value.
        /// </summary>
        public T Get<T>(string key)
        {
            return (T) Get(key);
        }

        /// <summary>
        /// Remove a certain cached value.
        /// </summary>
        public void Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }

        /// <summary>
        /// Insert a value into the cache, using a default timeout of one hour.
        /// </summary>
        public void Set(string key, object value)
        {
            HttpRuntime.Cache.Insert(key, value);
        }

        /// <summary>
        /// Insert a value into the cache, using a custom timeout.
        /// </summary>
        public void Set(string key, object value, TimeSpan timeout)
        {
            var expires = DateTime.Now.Add(timeout);
            HttpRuntime.Cache.Insert(key, value, null, expires, new TimeSpan());
        }

        /// <summary>
        /// Insert a value into the cache.
        /// </summary>
        public void Set(string key, object value, CacheDependency dependencies)
        {
            HttpRuntime.Cache.Insert(key, value, dependencies);
        }

        /// <summary>
        /// Insert a value into the cache.
        /// </summary>
        public void Set(string key, object value, CacheDependency dependencies, DateTime absoluteExpires, TimeSpan slidingExpiration)
        {
            HttpRuntime.Cache.Insert(key, value, dependencies, absoluteExpires, slidingExpiration);
        }

        /// <summary>
        /// Insert a value into the cache.
        /// </summary>
        public void Set(string key, object value, CacheDependency dependencies, DateTime absoluteExpires, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback removedCallback)
        {
            HttpRuntime.Cache.Insert(key, value, dependencies, absoluteExpires, slidingExpiration, priority, removedCallback);
        }

        /// <summary>
        /// Insert a value into the cache.
        /// </summary>
        public void Set(string key, object value, CacheDependency dependencies, DateTime absoluteExpires, TimeSpan slidingExpiration, CacheItemUpdateCallback updateCallback)
        {
            HttpRuntime.Cache.Insert(key, value, dependencies, absoluteExpires, slidingExpiration, updateCallback);
        }

        /// <summary>
        /// Try to retrieve a certain, typed cached value.
        /// </summary>
        public T TryGet<T>(string key, T fallback)
        {
            return !Contains(key) ? fallback : Get<T>(key);
        }
    }
}
