using System.Collections.Generic;
using EPiServer;
using EPiServer.Core;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace NExtra.EpiServer.Extensions
{
    /// <summary>
    /// Extension methods for EPiServer.SpecializedProperties.PropertyLinkCollection.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi
    /// Link:       http://www.saidi.se/nextra
    /// </remarks>
    public static class PropertyLinkCollectionExtensions
    {
        /// <summary>
        /// Convert a PropertyLinkCollection to a PageData IEnumerable.
        /// </summary>
        /// <param name="linkItemCollection">The LinkItemCollection to convert.</param>
        /// <returns>The resulting PageData IEnumerable.</returns>
        public static IEnumerable<PageData> ToPageDataEnumerable(this PropertyLinkCollection linkItemCollection)
        {
            var pages = new List<PageData>();
            if (linkItemCollection == null)
                return pages;

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
