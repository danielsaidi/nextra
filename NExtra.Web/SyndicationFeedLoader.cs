using System.ServiceModel.Syndication;
using System.Xml;
using NExtra.ValidationAttributes;
using NExtra.Web.Abstractions;

namespace NExtra.Web
{
	/// <summary>
	/// This class can be used to load Syndication feeds (RSS
	/// feeds) from any URL, using the non-abstract, built-in
	/// System.ServiceModel.Syndication.SyndicationFeed class.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public class SyndicationFeedLoader : ISyndicationFeedLoader
	{
        /// <summary>
        /// Load a syndication feed from any public URL.
        /// </summary>
		public SyndicationFeed Load(string url)
		{
		    return !(new UrlAttribute().IsValid(url)) ? new SyndicationFeed() : SyndicationFeed.Load(XmlReader.Create(url));
		}
	}
}
