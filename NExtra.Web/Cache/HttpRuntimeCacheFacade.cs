using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace NExtra.Web.Cache
{
    /// <summary>
    /// This class can be used as a facade for the static
    /// HttpRuntime.Cache instance.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class HttpRuntimeCacheFacade : IHttpRuntimeCache
    {
        public object Add(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority)
        {
            return HttpRuntime.Cache.Add(key, value, dependencies, absoluteExpiration, slidingExpiration, priority, null);
        }

        public void Clear()
        {
            var allKeys = (from DictionaryEntry entry in HttpRuntime.Cache select (string) entry.Key);

            foreach (var key in allKeys)
            {
                HttpRuntime.Cache.Remove(key);
            }
        }

        public bool Contains(string key)
        {
            return HttpRuntime.Cache.Get(key) != null;
        }

        public object Get(string key)
        {
            return HttpRuntime.Cache.Get(key);
        }

        public T Get<T>(string key)
        {
            return (T) Get(key);
        }

        public T GetOrAdd<T>(string key, Func<T> fallback, TimeSpan timeout)
        {
            if (Contains(key))
            {
                return Get<T>(key);
            }

            var value = fallback();
            Set(key, value, timeout);
            return value;
        }

        public void Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }

        public void Set(string key, object value)
        {
            HttpRuntime.Cache.Insert(key, value);
        }

        public void Set(string key, object value, TimeSpan timeout)
        {
            var expires = DateTime.Now.Add(timeout);
            HttpRuntime.Cache.Insert(key, value, null, expires, new TimeSpan());
        }

        public void Set(string key, object value, CacheDependency dependencies)
        {
            HttpRuntime.Cache.Insert(key, value, dependencies);
        }

        public void Set(string key, object value, CacheDependency dependencies, DateTime absoluteExpires, TimeSpan slidingExpiration)
        {
            HttpRuntime.Cache.Insert(key, value, dependencies, absoluteExpires, slidingExpiration);
        }

        public void Set(string key, object value, CacheDependency dependencies, DateTime absoluteExpires, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback removedCallback)
        {
            HttpRuntime.Cache.Insert(key, value, dependencies, absoluteExpires, slidingExpiration, priority, removedCallback);
        }

        public void Set(string key, object value, CacheDependency dependencies, DateTime absoluteExpires, TimeSpan slidingExpiration, CacheItemUpdateCallback updateCallback)
        {
            HttpRuntime.Cache.Insert(key, value, dependencies, absoluteExpires, slidingExpiration, updateCallback);
        }

        public T TryGet<T>(string key, T fallback)
        {
            return !Contains(key) ? fallback : Get<T>(key);
        }
    }
}
