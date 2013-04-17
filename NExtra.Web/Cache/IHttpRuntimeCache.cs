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
        object Add(string key, object value, CacheDependency dependencies, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority);
        void Set(string key, object value, CacheDependency dependencies);
        void Set(string key, object value, CacheDependency dependencies, DateTime absoluteExpires, TimeSpan slidingExpiration);
        void Set(string key, object value, CacheDependency dependencies, DateTime absoluteExpires, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback removedCallback);
        void Set(string key, object value, CacheDependency dependencies, DateTime absoluteExpires, TimeSpan slidingExpiration, CacheItemUpdateCallback updateCallback);
    }
}
