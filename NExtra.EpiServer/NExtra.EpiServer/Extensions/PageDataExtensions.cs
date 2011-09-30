using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPiServer;
using EPiServer.BaseLibrary;
using EPiServer.Core;
using EPiServer.DataAbstraction;

namespace NExtra.EpiServer.Extensions
{
	/// <summary>
	/// Extension methods for EPiServer.Core.PageData.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public static class PageDataExtensions
	{
        /// <summary>
        /// Retrieve all direct children of a certain type for a PageData instance.
        /// </summary>
        /// <typeparam name="T">The type of children to return.</typeparam>
        /// <param name="pageData">The PageData instance to load children for.</param>
        /// <returns>All direct children that are of a certain type.</returns>
        public static IEnumerable<T> GetChildrenOfType<T>(this PageData pageData)
        {
            return DataFactory.Instance.GetChildrenOfType<T>(pageData.PageLink);
        }

	    /// <summary>
        /// Retrieve all descendents of a certain type for a PageData instance.
	    /// </summary>
	    /// <typeparam name="T">The type of descendents to return.</typeparam>
        /// <param name="pageData">The PageData instance to load children for.</param>
	    /// <returns>All descendents that are of a certain type.</returns>
	    public static IEnumerable<T> GetDescendentsOfType<T>(this PageData pageData)
        {
            return DataFactory.Instance.GetDescendentsOfType<T>(pageData.PageLink);
        }

		/// <summary>
		/// Get a friendly version of the LinkURL property.
		/// </summary>
		/// <param name="pageData">The PageData instance of interest.</param>
		/// <returns>A friendly  version of the LinkURL property</returns>
		public static string GetFriendlyLinkUrl(this PageData pageData)
		{
			var url = new UrlBuilder(pageData.LinkURL);
			Global.UrlRewriteProvider.ConvertToExternal(url, pageData.PageLink, Encoding.UTF8);
			return url.ToString();
		}

		/// <summary>
		/// Safely retrieve a property value from a PageData instance.
		/// If the property can not be retrieved, the default T value
		/// will be returned.
		/// </summary>
		/// <typeparam name="T">The property type.</typeparam>
		/// <param name="pageData">The PageData instance of interest.</param>
		/// <param name="propertyName">The name of the property to retrieve.</param>
		/// <returns>Property value or default value for T.</returns>
		public static T GetPropertyValue<T>(this PageData pageData, string propertyName)
		{
			return GetPropertyValue(pageData, propertyName, default(T));
		}

		/// <summary>
		/// Safely retrieve a property value for a PageData instance.
		/// </summary>
		/// <typeparam name="T">The property type.</typeparam>
		/// <param name="pageData">The PageData instance of interest.</param>
		/// <param name="propertyName">The name of the property to retrieve.</param>
		/// <param name="fallbackValue">A fallback value to return if anything goes wrong.</param>
		/// <returns>Property value or fallback value.</returns>
		public static T GetPropertyValue<T>(this PageData pageData, string propertyName, T fallbackValue)
		{
			try { return pageData[propertyName] == null ? fallbackValue : (T) pageData[propertyName]; }
			catch (Exception) { return fallbackValue; }
		}

		/// <summary>
        /// Get all selected categories for a PageData instance.
		/// </summary>
		/// <param name="pageData">The PageData instance of interest.</param>
		/// <param name="rootCategoryName">Category root name.</param>
		/// <returns>A list of selected categories.</returns>
		public static IEnumerable<Category> GetSelectedCategories(this PageData pageData, string rootCategoryName)
		{
			var pageCategories = pageData.Category;
			var rootCategory = Category.Find(rootCategoryName);

			return rootCategory == null
				? new List<Category>()
				: rootCategory.Categories.AsEnumerable().Where(c => pageCategories.MemberOf(c.ID)).ToList();
		}

		/// <summary>
		/// Check if a PageData instance has a certain property value.
		/// </summary>
		/// <param name="pageData">The PageData instance of interest.</param>
		/// <param name="propertyName">The name of the property to check for.</param>
		/// <returns>Whether or not the property value exists.</returns>
		public static bool HasPropertyValue(this PageData pageData, string propertyName)
		{
			var propertyData = pageData.Property[propertyName];

			return (propertyData != null && !propertyData.IsNull);
		}

        /// <summary>
        /// Check if a PageData instance is new and unsaved.
        /// </summary>
        /// <remarks>
        /// Author:     Frederik Vig
        /// Link:		http://www.frederikvig.com/2009/05/episerver-extension-methods/
        /// </remarks>
        /// <param name="pageData">The PageData instance of interest.</param>
        /// <returns>Whether or not the PageData instance is published.</returns>
        public static bool IsNew(this PageData pageData)
        {
            return pageData.WorkPageID == 0;
        }

		/// <summary>
		/// Check if a PageData instance is published.
		/// </summary>
		/// <remarks>
		/// Author:     Frederik Vig
		/// Link:		http://www.frederikvig.com/2009/05/episerver-extension-methods/
		/// </remarks>
		/// <param name="pageData">The PageData instance of interest.</param>
		/// <returns>Whether or not the PageData instance is published.</returns>
		public static bool IsPublished(this PageData pageData)
		{
			return HasPublishedStatus(pageData, PagePublishedStatus.Published);
		}

		/// <summary>
		/// Check if a PageData instance has a certain publish status.
		/// </summary>
		/// <remarks>
		/// Author:     Frederik Vig
		/// Link:		http://www.frederikvig.com/2009/05/episerver-extension-methods/
		/// </remarks>
		/// <param name="pageData">The PageData instance of interest.</param>
		/// <param name="status">The publish status to check for.</param>
		/// <returns>Whether or not the PageData instance has the certain publish status.</returns>
		public static bool HasPublishedStatus(this PageData pageData, PagePublishedStatus status)
		{
			if (status != PagePublishedStatus.Ignore)
			{
				if (pageData.PendingPublish)
					return false;
				if (pageData.Status != VersionStatus.Published)
					return false;
				if ((status >= PagePublishedStatus.PublishedIgnoreStopPublish) && (pageData.StartPublish > Context.Current.RequestTime))
					return false;
				if ((status >= PagePublishedStatus.Published) && (pageData.StopPublish < Context.Current.RequestTime))
					return false;
			}

			return true;
		}
	}
}
