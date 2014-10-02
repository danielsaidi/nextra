using System;

namespace NExtra.Cache
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can cache data in various ways. It is very simple,
    /// thoguh, and describes only the most basic caching
    /// functionality.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface ICache
    {
        void Clear();
        bool Contains(string key);
        object Get(string key);
        T Get<T>(string key);
        T GetOrAdd<T>(string key, Func<T> fallback, TimeSpan timeout);
        void Remove(string key);
        void Set(string key, object value, TimeSpan timeout);
        T TryGet<T>(string key, T fallback);
    }
}
