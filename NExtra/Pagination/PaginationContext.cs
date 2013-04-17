using System;
using System.Collections.Generic;
using System.Linq;
using NExtra.Extensions;

namespace NExtra.Pagination
{
    /// <summary>
	/// This class can handle pagination for any kind of
	/// IEnumerable or IQueryable collection.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// </remarks>
	public class PaginationContext<T> : IPaginationContext<T>
    {
		private int pageLinkMaxCount;
		private int pageNumber;
		private int pageSize;


		public PaginationContext(IEnumerable<T> collection, int pageNumber, int pageSize, int pageLinkMaxCount)
			: this(collection.AsQueryable(), pageNumber, pageSize, pageLinkMaxCount)
		{
		}

		public PaginationContext(IQueryable<T> collection, int pageNumber, int pageSize, int pageLinkMaxCount)
		{
			Collection = collection;

			PageSize = pageSize;
			PageNumber = pageNumber;
			PageLinkMaxCount = pageLinkMaxCount;
		}


		public IQueryable<T> Collection { get; private set; }

        public int NextPageLink
        {
            get { return ShowNextPageLink ? PageLinks[PageLinks.Count-1] + 1 : -1; }
        }

		public int PageCount
		{
			get
			{
				return (int)Math.Ceiling(Collection.Count() / (double)PageSize);
			}
		}

		public int PageLinkCount
		{
			get
			{
				return PageCount < PageLinkMaxCount ? PageCount : PageLinkMaxCount;
			}
		}

		public int PageLinkMaxCount
		{
			get { return pageLinkMaxCount; }
			set { pageLinkMaxCount = value.Limit(1, value); }
		}

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

		public int PageNumber
		{
			get { return pageNumber.Limit(1, PageCount); }
			set { pageNumber = value.Limit(1, PageCount); }
		}

		public int PageSize
		{
			get { return pageSize; }
			set { pageSize = value.Limit(1, value); }
		}

        public int PreviousPageLink
        {
            get { return ShowPreviousPageLink ? PageLinks[0] - 1 : -1; }
        }

        public bool ShowNextPageLink
        {
            get { return (PageLinks.Count > 0 && PageLinks[PageLinks.Count - 1] < PageCount); }
        }

        public bool ShowPreviousPageLink
        {
            get { return (PageLinks.Count > 0 && PageLinks[0] > 1); }
        }


	    public IQueryable<T> GetPaginationResult()
	    {
	        return Collection.Skip((PageNumber - 1)*PageSize).Take(PageSize);
	    }
	}
}
