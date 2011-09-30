using System.Collections.Generic;
using EPiServer;
using EPiServer.Core;

namespace NExtra.EpiServer.Extensions
{
	/// <summary>
	/// Extension methods for EPiServer.Core.PageReference.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public static class PageReferenceExtensions
    {
        /// <summary>
        /// Retrieve all direct children of a certain type for a PageReference instance.
        /// </summary>
        /// <typeparam name="T">The type of children to return.</typeparam>
        /// <param name="pageReference">The PageReference instance to load children for.</param>
        /// <returns>All direct children that are of a certain type.</returns>
        public static IEnumerable<T> GetChildrenOfType<T>(this PageReference pageReference)
        {
            return DataFactory.Instance.GetChildrenOfType<T>(pageReference);
        }

        /// <summary>
        /// Retrieve all descendents of a certain type for a PageReference instance.
        /// </summary>
        /// <typeparam name="T">The type of descendents to return.</typeparam>
        /// <param name="pageReference">The PageReference instance to load children for.</param>
        /// <returns>All descendents that are of a certain type.</returns>
        public static IEnumerable<T> GetDescendentsOfType<T>(this PageReference pageReference)
        {
            return DataFactory.Instance.GetDescendentsOfType<T>(pageReference);
        }

		/// <summary>
		/// Check if a PageReference instance is null or empty.
		/// </summary>
		/// <param name="pageReference">The PageReference instance of interest.</param>
		/// <returns>Whether or not the PageReference instance is null or empty.</returns>
		public static bool IsNullOrEmpty(this PageReference pageReference)
		{
			return PageReference.IsNullOrEmpty(pageReference);
		}

		/// <summary>
        /// Get the PageData instance that a PageReference instance refers to.
		/// </summary>
		/// <param name="pageReference">The PageReference instance of interest.</param>
		/// <returns>The referred PageData instance.</returns>
		public static PageData GetPageData(this PageReference pageReference)
		{
			return pageReference.IsNullOrEmpty() ? null : DataFactory.Instance.GetPage(pageReference);
		}
	}
}
