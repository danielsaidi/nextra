using System.Collections.Generic;
using EPiServer.DataAbstraction;

namespace NExtra.EpiServer.Extensions
{
	/// <summary>
	/// Extension methods for EPiServer.DataAbstraction.CategoryCollection.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public static class CategoryCollectionExtensions
	{
		/// <summary>
		/// Convert a CategoryCollection to a Category enumerable.
		/// </summary>
		/// <param name="categoryCollection">The CategoryCollection instance of interest.</param>
        /// <returns>Resulting Category enumerable.</returns>
		public static IEnumerable<Category> AsEnumerable(this CategoryCollection categoryCollection)
		{
			var list = new List<Category>();
			for (var i = 0; i < categoryCollection.Count; i++)
				list.Add(categoryCollection[i]);
			return list;
		}
	}
}
