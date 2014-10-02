using System;
using System.Linq;
using System.Runtime.Caching;

namespace NExtra.Cache
{
    /// <summary>
    /// This class can be used as a facade for the default
    /// System.Runtime.Caching.MemoryCache instance.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class MemoryCacheFacade : ICache
    {
        private readonly MemoryCache _cache;


        public MemoryCacheFacade()
        {
            _cache = MemoryCache.Default;
        }


        public void Clear()
        {
            foreach (var key in _cache.Select(item => item.Key).ToList())
                _cache.Remove(key);
        }

        public bool Contains(string key)
        {
            return _cache.Contains(key);
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public T Get<T>(string key)
        {
            return (T)Get(key);
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
            _cache.Remove(key);
        }

        public void Set(string key, object value, TimeSpan timeout)
        {
            var offset = DateTime.Now.Add(timeout);
            _cache.Set(key, value, new DateTimeOffset(offset));
        }

        public T TryGet<T>(string key, T fallback)
        {
            return !Contains(key) ? fallback : Get<T>(key);
        }
    }
}
