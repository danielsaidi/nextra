using System.ServiceModel.Syndication;

namespace NExtra.Syndication
{
    /// <summary>
    /// This interface can be implemented by classes that
    /// can load syndication feeds like RSS, ATOM etc.
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
		SyndicationFeed Load(string url);
	}
}
