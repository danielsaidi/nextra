using System;
using System.Collections.Generic;
using System.Linq;
using NExtra.Extensions;

namespace NExtra.Pagination
{
	/// <summary>
	/// This class can handle the pagination for any IEnumerable
	/// or IQueryable collection. It can calculate the number of
	/// pages for collection, given a certain page size, and can
	/// also determine how it can be paginated, according to the
	/// current page number.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	/// <typeparam name="T">The type that is handled by the context.</typeparam>
	public class PaginationContext<T>
	{
		private int pageLinkMaxCount;
		private int pageNumber;
		private int pageSize;


		/// <summary>
		/// Create an instance of the class.
		/// </summary>
		/// <param name="collection">The collection to base the context on.</param>
		/// <param name="pageNumber">The current page number.</param>
		/// <param name="pageSize">The max number of items to display per page.</param>
		/// <param name="pageLinkMaxCount">The max number of page links to display in a pagination UI component.</param>
		public PaginationContext(IEnumerable<T> collection, int pageNumber = 1, int pageSize = 25, int pageLinkMaxCount = 10)
			: this(collection.AsQueryable(), pageNumber, pageSize, pageLinkMaxCount)
		{
		}

		/// <summary>
		/// Create an instance of the class.
		/// </summary>
		/// <param name="collection">The collection to base the context on.</param>
		/// <param name="pageNumber">The current page number.</param>
		/// <param name="pageSize">The max number of items to display per page.</param>
		/// <param name="pageLinkMaxCount">The max number of page links to display in a pagination UI component.</param>
		public PaginationContext(IQueryable<T> collection, int pageNumber = 1, int pageSize = 25, int pageLinkMaxCount = 10)
		{
			Collection = collection;

			PageSize = pageSize;
			PageNumber = pageNumber;
			PageLinkMaxCount = pageLinkMaxCount;
		}


		/// <summary>
		/// The loaded collection.
		/// </summary>
		/// <returns>The loaded collection.</returns>
		public IQueryable<T> Collection { get; private set; }

        /// <summary>
        /// The page index for a "next" page; -1 if none exists.
        /// </summary>
        public int NextPageLink
        {
            get { return ShowNextPageLink ? PageLinks[PageLinks.Count-1] + 1 : -1; }
        }

		/// <summary>
		/// The total number of available pages.
		/// </summary>
		public int PageCount
		{
			get
			{
				return (int)Math.Ceiling(Collection.Count() / (double)PageSize);
			}
		}

		/// <summary>
		/// The total number of page links to display, limited
		/// by the PageCount and PageLinkMaxCount properties.
		/// </summary>
		public int PageLinkCount
		{
			get
			{
				return PageCount < PageLinkMaxCount ? PageCount : PageLinkMaxCount;
			}
		}

		/// <summary>
		/// The max number of page links to display; minimum 1.
		/// </summary>
		public int PageLinkMaxCount
		{
			get { return pageLinkMaxCount; }
			set { pageLinkMaxCount = value.Limit(1, value); }
		}

        /// <summary>
        /// The page links to display in a pagination component.
        /// </summary>
        public List<int> PageLinks
        {
            get
            {
                var startPage = PageNumber - (PageLinkMaxCount / 2);
                if (startPage + PageLinkMaxCount > PageCount)
                    startPage = PageCount - PageLinkMaxCount + 1;
                if (startPage < 1)
                    startPage = 1;

                var result = new List<int>();
                for (var i = startPage; i < startPage + PageLinkCount; i++)
                    result.Add(i);

                return result;
            }
        }

		/// <summary>
		/// The current page number; minimum 1 and maximum PageCount.
		/// </summary>
		public int PageNumber
		{
			get { return pageNumber.Limit(1, PageCount); }
			set { pageNumber = value.Limit(1, PageCount); }
		}

		/// <summary>
		/// The max number of items to display per page; minimum 1.
		/// </summary>
		public int PageSize
		{
			get { return pageSize; }
			set { pageSize = value.Limit(1, value); }
		}

        /// <summary>
        /// The page index for a "previous" page; -1 if none exists.
        /// </summary>
        public int PreviousPageLink
        {
            get { return ShowPreviousPageLink ? PageLinks[0] - 1 : -1; }
        }

        /// <summary>
        /// Whether or not a "next" page link should be displayed.
        /// </summary>
        public bool ShowNextPageLink
        {
            get { return (PageLinks.Count > 0 && PageLinks[PageLinks.Count - 1] < PageCount); }
        }

        /// <summary>
        /// Whether or not a "previous" page link should be displayed.
        /// </summary>
        public bool ShowPreviousPageLink
        {
            get { return (PageLinks.Count > 0 && PageLinks[0] > 1); }
        }



	    /// <summary>
	    /// The paginated, resulting collection.
	    /// </summary>
	    public IQueryable<T> GetPaginationResult()
	    {
	        return Collection.Skip((PageNumber - 1)*PageSize).Take(PageSize);
	    }
	}
}
