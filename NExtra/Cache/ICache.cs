using System;

namespace NExtra.Cache
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can cache data. The interface is, as of now, very
    /// simple and may be extended in future versions.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public interface ICache
    {
        /// <summary>
        /// Clear the entire cache.
        /// </summary>
        void Clear();

        /// <summary>
        /// Check whether or not a certain cache key exists.
        /// </summary>
        bool Contains(string key);

        /// <summary>
        /// Retrieve a certain cached value.
        /// </summary>
        object Get(string key);

        /// <summary>
        /// Retrieve a certain, typed cached value.
        /// </summary>
        T Get<T>(string key);

        /// <summary>
        /// Remove a certain cached value.
        /// </summary>
        void Remove(string key);

        /// <summary>
        /// Insert a value into the cache, using a default timeout.
        /// </summary>
        void Set(string key, object value);

        /// <summary>
        /// Insert a value into the cache, using a custom timeout.
        /// </summary>
        void Set(string key, object value, TimeSpan timeout);

        /// <summary>
        /// Try to retrieve a certain, typed cached value.
        /// </summary>
        T TryGet<T>(string key, T fallback);
    }
}
