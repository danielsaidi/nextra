using System;
using System.Web.Caching;
using NExtra.Cache.Abstractions;

namespace NExtra.Web.Cache.Abstractions
{
    ///<summary>
    /// This interface can be implemented by classes that
    /// can cache data in a way similar to a HTTP runtime
    /// cache. Method naming differ from HttpRuntimeCache,
    /// since it extends the general ICache.
    ///</summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
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
