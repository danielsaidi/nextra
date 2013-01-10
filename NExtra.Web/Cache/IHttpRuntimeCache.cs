using System;
using System.Web.Caching;
using NExtra.Cache;

namespace NExtra.Web.Cache
{
    ///<summary>
    /// This interface extends the base ICache interface in
    /// NExtra.Cache. It can be implemented by classes that
    /// can cache data in similar to the HTTP runtime cache.
    ///</summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
    public interface IHttpRuntimeCache : ICache
    {
        /// <summary>
        /// Add a value to the cache.
        /// </summary>
        object Add(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority);

        /// <summary>
        /// Insert a value into the cache.
        /// </summary>
        void Set(string key, object value, CacheDependency dependencies);

        /// <summary>
        /// Insert a value into the cache.
        /// </summary>
        void Set(string key, object value, CacheDependency dependencies, DateTime absoluteExpires, TimeSpan slidingExpiration);

        /// <summary>
        /// Insert a value into the cache.
        /// </summary>
        void Set(string key, object value, CacheDependency dependencies, DateTime absoluteExpires, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback removedCallback);

        /// <summary>
        /// Insert a value into the cache.
        /// </summary>
        void Set(string key, object value, CacheDependency dependencies, DateTime absoluteExpires, TimeSpan slidingExpiration, CacheItemUpdateCallback updateCallback);
    }
}
