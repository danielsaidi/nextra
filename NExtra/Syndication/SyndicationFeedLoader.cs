using System.ServiceModel.Syndication;
using System.Xml;
using NExtra.Validation;

namespace NExtra.Syndication
{
	/// <summary>
	/// This class can be used to load Syndication feeds (RSS
	/// feeds) from any URL, using the non-abstract, built-in
	/// System.ServiceModel.Syndication.SyndicationFeed class.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
	public class SyndicationFeedLoader : ISyndicationFeedLoader
	{
		public SyndicationFeed Load(string url)
        {
            return !new UrlAttribute().IsValid(url)
                ? new SyndicationFeed()
                : SyndicationFeed.Load(XmlReader.Create(url));
        }
	}
}
