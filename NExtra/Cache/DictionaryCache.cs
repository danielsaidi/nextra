using System;
using System.Collections.Generic;

namespace NExtra.Cache
{
    /// <summary>
    /// This is a really simple ICache implementation that
    /// caches data in a memory dictionary. It requires no
    /// setup, but should only be used in trivial cases.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public class DictionaryCache : ICache
    {
        private readonly Dictionary<string, DictionaryCacheItem> _cache;


        public DictionaryCache()
        {
            _cache = new Dictionary<string, DictionaryCacheItem>();
        }


        public void Clear()
        {
            _cache.Clear();
        }

        public bool Contains(string key)
        {
            RemoveIfInvalid(key);
            return _cache.ContainsKey(key);
        }

        public object Get(string key)
        {
            RemoveIfInvalid(key);
            return _cache[key].Obj;
        }

        public T Get<T>(string key)
        {
            return (T)Get(key);
        }

        public T GetOrAdd<T>(string key, Func<T> fallback, TimeSpan timeout)
        {
            DictionaryCacheItem item;
            if (_cache.TryGetValue(key, out item))
            {
                if (item.Expires > DateTime.Now)
                {
                    return (T) item.Obj;
                }
            }
            
            var value = fallback();
            Set(key, value, timeout);
            return value;
        }

        private bool IsValid(string key)
        {
            return _cache[key].Expires > DateTime.Now;
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        private void RemoveIfInvalid(string key)
        {
            if (!_cache.ContainsKey(key))
                return;
            if (!IsValid(key))
                Remove(key);
        }

        public void Set(string key, object value, TimeSpan timeout)
        {
            _cache[key] = new DictionaryCacheItem(value, DateTime.Now.Add(timeout));
        }

        public T TryGet<T>(string key, T fallback)
        {
            return !Contains(key) ? fallback : Get<T>(key);
        }
    }
}
