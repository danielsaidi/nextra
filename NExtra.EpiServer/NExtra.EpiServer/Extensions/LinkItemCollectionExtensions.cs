using System.Collections.Generic;
using EPiServer;
using EPiServer.Core;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace NExtra.EpiServer.Extensions
{
	/// <summary>
	/// Extension methods for EPiServer.SpecializedProperties.LinkItemCollection.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public static class LinkItemCollectionExtensions
	{
		/// <summary>
		/// Convert a LinkItemCollection to a PageDataCollection.
		/// </summary>
		/// <remarks>
		/// Author:     Frederik Vig
        /// Link:   	http://www.frederikvig.com/2009/06/episerver-extension-methods-part-2/
		/// </remarks>
		/// <param name="linkItemCollection">The LinkItemCollection to convert.</param>
		/// <returns>The resulting PageDataCollection.</returns>
		public static PageDataCollection ToPageDataCollection(this LinkItemCollection linkItemCollection)
		{
			var pageDataCollection = new PageDataCollection();

			foreach (var linkItem in linkItemCollection)
			{
				var url = new UrlBuilder(linkItem.Href);
				
				if (!PermanentLinkMapStore.ToMapped(url))
					continue;

				var page = DataFactory.Instance.GetPage(PermanentLinkUtility.GetPageReference(url));
				if (page != null)
					pageDataCollection.Add(page);
			}

			return pageDataCollection;
		}

		/// <summary>
		/// Convert a LinkItemCollection to a PageData IEnumerable.
		/// </summary>
		/// <remarks>
		/// Author:     Joel Abrahamsson
        /// Link:   	http://joelabrahamsson.com/entry/convert-a-linkitemcollection-to-a-list-of-pagedata
		/// </remarks>
		/// <param name="linkItemCollection">The LinkItemCollection to convert.</param>
        /// <returns>The resulting PageData IEnumerable.</returns>
		public static IEnumerable<PageData> ToPageDataList(this LinkItemCollection linkItemCollection)
		{
			var pages = new List<PageData>();

			foreach (var linkItem in linkItemCollection)
			{
				string linkUrl;

				if (!PermanentLinkMapStore.TryToMapped(linkItem.Href, out linkUrl))
					continue;

				if (string.IsNullOrEmpty(linkUrl))
					continue;

				var pageReference = PageReference.ParseUrl(linkUrl);
				if (PageReference.IsNullOrEmpty(pageReference))
					continue;

				pages.Add(DataFactory.Instance.GetPage((pageReference)));
			}

			return pages;
		}
	}
}
