using System.ServiceModel.Syndication;

namespace NExtra.Web.Abstractions
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// should be able to load syndication feeds, aka RSS.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
	public interface ISyndicationFeedLoader
	{
        /// <summary>
        /// Load a feed from a certain URL.
        /// </summary>
        /// <param name="url">The URL of the feed.</param>
        /// <returns>The resulting feed instance.</returns>
		SyndicationFeed Load(string url);
	}
}
