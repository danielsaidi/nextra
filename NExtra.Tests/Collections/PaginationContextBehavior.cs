using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NExtra.Collections;
using NUnit.Framework;

namespace NExtra.Tests.Collections
{
	[TestFixture]
	public class PaginationContextBehavior
	{
		private PaginationContext<KeyValuePair<string, int>> _context;
		private IQueryable<KeyValuePair<string, int>> _queryable;
		private List<KeyValuePair<string, int>> _searchResult;


		[SetUp]
		public void SetUp()
		{
			_searchResult = new List<KeyValuePair<string, int>>
			{
				new KeyValuePair<string, int>("a", 99),
				new KeyValuePair<string, int>("b", 98),
				new KeyValuePair<string, int>("c", 97),
				new KeyValuePair<string, int>("d", 96),
				new KeyValuePair<string, int>("e", 95)
			};

			_queryable = _searchResult.AsQueryable();
			_context = new PaginationContext<KeyValuePair<string, int>>(_queryable, 1, 25, 10);
		}


		[Test]
		public void Constructor_IEnumerable_ShouldApplyCustomParameters()
		{
			_context = new PaginationContext<KeyValuePair<string, int>>(_queryable.AsEnumerable(), 2, 1, 5);

			Assert.That(_context.PageNumber, Is.EqualTo(2));
			Assert.That(_context.PageSize, Is.EqualTo(1));
			Assert.That(_context.PageLinkMaxCount, Is.EqualTo(5));
		}

		[Test]
		public void Constructor_IQueryable_ShouldApplyDefaultParameters()
		{
			Assert.That(_context.Collection, Is.EqualTo(_searchResult.AsQueryable()));
			Assert.That(_context.PageNumber, Is.EqualTo(1));
			Assert.That(_context.PageSize, Is.EqualTo(25));
			Assert.That(_context.PageLinkMaxCount, Is.EqualTo(10));
		}

		[Test]
		public void Constructor_IQueryable_ShouldApplyCustomParameters()
		{
			_context = new PaginationContext<KeyValuePair<string, int>>(_queryable, 2, 1, 5);

			Assert.That(_context.PageNumber, Is.EqualTo(2));
			Assert.That(_context.PageSize, Is.EqualTo(1));
			Assert.That(_context.PageLinkMaxCount, Is.EqualTo(5));
		}



		[Test]
		public void Collection_ShouldReturnOriginalCollection()
		{
			Assert.That(_context.Collection, Is.EqualTo(_searchResult.AsQueryable()));
		}

		[Test]
		public void PageCount_ShouldReturnCorrectValue()
		{
			_context.PageSize = 1;
			Assert.That(_context.PageCount, Is.EqualTo(5));

			_context.PageSize = 2;
			Assert.That(_context.PageCount, Is.EqualTo(3));

			_context.PageSize = 3;
			Assert.That(_context.PageCount, Is.EqualTo(2));

			_context.PageSize = 4;
			Assert.That(_context.PageCount, Is.EqualTo(2));

			_context.PageSize = 5;
			Assert.That(_context.PageCount, Is.EqualTo(1));
		}

		[Test]
		public void PageLinkCount_ShouldLimitToPageLinkMaxCount()
		{
			var searchResult = new List<KeyValuePair<string, int>>();
			for (var i=0; i<500; i++)
				searchResult.Add(new KeyValuePair<string, int>(i.ToString(CultureInfo.InvariantCulture), i));

			_context = new PaginationContext<KeyValuePair<string, int>>(searchResult.AsQueryable(), 1, 50, 9);

			Assert.That(_context.PageCount, Is.EqualTo(10));
			Assert.That(_context.PageLinkCount, Is.EqualTo(9));

			_context.PageLinkMaxCount = 11;
			_context.PageSize = 50;

			Assert.That(_context.PageCount, Is.EqualTo(10));
			Assert.That(_context.PageLinkCount, Is.EqualTo(10));
		}

		[Test]
		public void PageLinkMaxCount_ShouldGetSetValue()
		{
			Assert.That(_context.PageLinkMaxCount, Is.EqualTo(10));
			_context.PageLinkMaxCount = 5;
			Assert.That(_context.PageLinkMaxCount, Is.EqualTo(5));
		}

		[Test]
		public void PageLinkMaxCount_ShouldAlwaysBePositive()
		{
			_context.PageLinkMaxCount = -5;
			Assert.That(_context.PageLinkMaxCount, Is.EqualTo(1));
		}



        [Test]
        public void PageLinks_ShouldHandleFirstPage()
        {
            _context.PageSize = 1;
            _context.PageNumber = 1;
            _context.PageLinkMaxCount = 3;

            Assert.That(_context.PageLinks[0], Is.EqualTo(1));
            Assert.That(_context.PageLinks.Count, Is.EqualTo(3));
        }

        [Test]
        public void PageLinks_ShouldHandleLowPage()
        {
            _context.PageSize = 1;
            _context.PageNumber = 2;
            _context.PageLinkMaxCount = 3;

            Assert.That(_context.PageLinks[0], Is.EqualTo(1));
            Assert.That(_context.PageLinks.Count, Is.EqualTo(3));
        }

        [Test]
        public void PageLinks_ShouldHandleMidPage()
        {
            _context.PageSize = 1;
            _context.PageNumber = 3;
            _context.PageLinkMaxCount = 3;

            Assert.That(_context.PageLinks[0], Is.EqualTo(2));
            Assert.That(_context.PageLinks.Count, Is.EqualTo(3));
        }

        [Test]
        public void PageLinks_ShouldHandleHighPage()
        {
            _context.PageSize = 1;
            _context.PageNumber = 4;
            _context.PageLinkMaxCount = 3;

            Assert.That(_context.PageLinks[0], Is.EqualTo(3));
            Assert.That(_context.PageLinks.Count, Is.EqualTo(3));
        }

        [Test]
        public void PageLinks_ShouldHandleLastPage()
        {
            _context.PageSize = 1;
            _context.PageNumber = 5;
            _context.PageLinkMaxCount = 3;

            Assert.That(_context.PageLinks[0], Is.EqualTo(3));
            Assert.That(_context.PageLinks.Count, Is.EqualTo(3));
        }

        [Test]
        public void PageLinks_ShouldHandleAllPageLinks()
        {
            _context.PageSize = 1;
            _context.PageNumber = 5;
            _context.PageLinkMaxCount = 1000;

            Assert.That(_context.PageLinks[0], Is.EqualTo(1));
            Assert.That(_context.PageLinks.Count, Is.EqualTo(5));
        }

		[Test]
		public void PageNumber_ShouldGetSetValue()
		{
			_context.PageSize = 1;

			Assert.That(_context.PageCount, Is.EqualTo(5));
			Assert.That(_context.PageNumber, Is.EqualTo(1));

			_context.PageNumber = 3;

			Assert.That(_context.PageNumber, Is.EqualTo(3));
		}

		[Test]
		public void PageNumber_ShouldLimitToPageCount()
		{
			_context.PageSize = 1;

			Assert.That(_context.PageCount, Is.EqualTo(5));
			Assert.That(_context.PageNumber, Is.EqualTo(1));

			_context.PageNumber = 30;

			Assert.That(_context.PageNumber, Is.EqualTo(5));
		}

		[Test]
		public void PageNumber_ShouldAlwaysBePositive()
		{
			_context.PageSize = 1;

			Assert.That(_context.PageCount, Is.EqualTo(5));
			Assert.That(_context.PageNumber, Is.EqualTo(1));

			_context.PageNumber = -1;

			Assert.That(_context.PageNumber, Is.EqualTo(1));
		}

		[Test]
		public void PageSize_ShouldGetSetValue()
		{
			Assert.That(_context.PageSize, Is.EqualTo(25));
			_context.PageSize = 5;
			Assert.That(_context.PageSize, Is.EqualTo(5));
		}

		[Test]
		public void PageSize_ShouldAlwaysBePositive()
		{
			_context.PageSize = -5;
			Assert.That(_context.PageSize, Is.EqualTo(1));
		}

		[Test]
		public void ShowPreviousPageLink_ShouldReturnFalseIfFirstPageIsShowing()
		{
			_context.PageSize = 1;
			_context.PageNumber = 2;
			_context.PageLinkMaxCount = 3;

			Assert.That(_context.ShowPreviousPageLink, Is.False);
		}

		[Test]
		public void ShowPreviousPageLink_ShouldReturnTrueIfFirstPageIsNotShowing()
		{
			_context.PageSize = 1;
			_context.PageNumber = 3;
			_context.PageLinkMaxCount = 3;

			Assert.That(_context.ShowPreviousPageLink, Is.True);
		}

		[Test]
		public void ShowNextPageLink_ShouldReturnFalseIfLastPageIsShowing()
		{
			_context.PageSize = 1;
			_context.PageNumber = 4;
			_context.PageLinkMaxCount = 3;

			Assert.That(_context.ShowNextPageLink, Is.False);
		}

		[Test]
		public void ShowNextPageLink_ShouldReturnTrueIfLastPageIsNotShowing()
		{
			_context.PageSize = 1;
			_context.PageNumber = 3;
			_context.PageLinkMaxCount = 3;

			Assert.That(_context.ShowNextPageLink, Is.True);
		}


        [Test]
        public void GetPaginationResult_ShouldHandleFirstItems()
        {
            _context.PageSize = 2;
            _context.PageNumber = 1;

            var result = _context.GetPaginationResult();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(_searchResult.AsQueryable().Skip(0).Take(2)));
        }

        [Test]
        public void GetPaginationResult_ShouldHandleMiddleItems()
        {
            _context.PageSize = 2;
            _context.PageNumber = 2;

            var result = _context.GetPaginationResult();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(_searchResult.AsQueryable().Skip(2).Take(2)));
        }

        [Test]
        public void GetPaginationResult_ShouldHandleLastItems()
        {
            _context.PageSize = 2;
            _context.PageNumber = 3;

            var result = _context.GetPaginationResult();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result, Is.EqualTo(_searchResult.AsQueryable().Skip(4).Take(2)));
        }
	}
}
