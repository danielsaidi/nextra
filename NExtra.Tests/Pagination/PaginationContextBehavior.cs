using System.Collections.Generic;
using System.Linq;
using NExtra.Pagination;
using NUnit.Framework;

namespace NExtra.Tests.Pagination
{
	[TestFixture]
	public class PaginationContextBehavior
	{
		private PaginationContext<KeyValuePair<string, int>> context;
		private IQueryable<KeyValuePair<string, int>> queryable;

		private List<KeyValuePair<string, int>> searchResult;


		[SetUp]
		public void SetUp()
		{
			searchResult = new List<KeyValuePair<string, int>>
			{
				new KeyValuePair<string, int>("a", 99),
				new KeyValuePair<string, int>("b", 98),
				new KeyValuePair<string, int>("c", 97),
				new KeyValuePair<string, int>("d", 96),
				new KeyValuePair<string, int>("e", 95)
			};

			queryable = searchResult.AsQueryable();
			context = new PaginationContext<KeyValuePair<string, int>>(queryable, 1, 25, 10);
		}


		[Test]
		public void Constructor_IEnumerable_ShouldApplyCustomParameters()
		{
			context = new PaginationContext<KeyValuePair<string, int>>(queryable.AsEnumerable(), 2, 1, 5);

			Assert.That(context.PageNumber, Is.EqualTo(2));
			Assert.That(context.PageSize, Is.EqualTo(1));
			Assert.That(context.PageLinkMaxCount, Is.EqualTo(5));
		}

		[Test]
		public void Constructor_IQueryable_ShouldApplyDefaultParameters()
		{
			Assert.That(context.Collection, Is.EqualTo(searchResult.AsQueryable()));
			Assert.That(context.PageNumber, Is.EqualTo(1));
			Assert.That(context.PageSize, Is.EqualTo(25));
			Assert.That(context.PageLinkMaxCount, Is.EqualTo(10));
		}

		[Test]
		public void Constructor_IQueryable_ShouldApplyCustomParameters()
		{
			context = new PaginationContext<KeyValuePair<string, int>>(queryable, 2, 1, 5);

			Assert.That(context.PageNumber, Is.EqualTo(2));
			Assert.That(context.PageSize, Is.EqualTo(1));
			Assert.That(context.PageLinkMaxCount, Is.EqualTo(5));
		}



		[Test]
		public void Collection_ShouldReturnOriginalCollection()
		{
			Assert.That(context.Collection, Is.EqualTo(searchResult.AsQueryable()));
		}

		[Test]
		public void PageCount_ShouldReturnCorrectValue()
		{
			context.PageSize = 1;
			Assert.That(context.PageCount, Is.EqualTo(5));

			context.PageSize = 2;
			Assert.That(context.PageCount, Is.EqualTo(3));

			context.PageSize = 3;
			Assert.That(context.PageCount, Is.EqualTo(2));

			context.PageSize = 4;
			Assert.That(context.PageCount, Is.EqualTo(2));

			context.PageSize = 5;
			Assert.That(context.PageCount, Is.EqualTo(1));
		}

		[Test]
		public void PageLinkCount_ShouldLimitToPageLinkMaxCount()
		{
			var searchResult = new List<KeyValuePair<string, int>>();
			for (var i=0; i<500; i++)
				searchResult.Add(new KeyValuePair<string, int>(i.ToString(), i));

			context = new PaginationContext<KeyValuePair<string, int>>(searchResult.AsQueryable(), 1, 50, 9);

			Assert.That(context.PageCount, Is.EqualTo(10));
			Assert.That(context.PageLinkCount, Is.EqualTo(9));

			context.PageLinkMaxCount = 11;
			context.PageSize = 50;

			Assert.That(context.PageCount, Is.EqualTo(10));
			Assert.That(context.PageLinkCount, Is.EqualTo(10));
		}

		[Test]
		public void PageLinkMaxCount_ShouldGetSetValue()
		{
			Assert.That(context.PageLinkMaxCount, Is.EqualTo(10));
			context.PageLinkMaxCount = 5;
			Assert.That(context.PageLinkMaxCount, Is.EqualTo(5));
		}

		[Test]
		public void PageLinkMaxCount_ShouldAlwaysBePositive()
		{
			context.PageLinkMaxCount = -5;
			Assert.That(context.PageLinkMaxCount, Is.EqualTo(1));
		}



        [Test]
        public void PageLinks_ShouldHandleFirstPage()
        {
            context.PageSize = 1;
            context.PageNumber = 1;
            context.PageLinkMaxCount = 3;

            Assert.That(context.PageLinks[0], Is.EqualTo(1));
            Assert.That(context.PageLinks.Count, Is.EqualTo(3));
        }

        [Test]
        public void PageLinks_ShouldHandleLowPage()
        {
            context.PageSize = 1;
            context.PageNumber = 2;
            context.PageLinkMaxCount = 3;

            Assert.That(context.PageLinks[0], Is.EqualTo(1));
            Assert.That(context.PageLinks.Count, Is.EqualTo(3));
        }

        [Test]
        public void PageLinks_ShouldHandleMidPage()
        {
            context.PageSize = 1;
            context.PageNumber = 3;
            context.PageLinkMaxCount = 3;

            Assert.That(context.PageLinks[0], Is.EqualTo(2));
            Assert.That(context.PageLinks.Count, Is.EqualTo(3));
        }

        [Test]
        public void PageLinks_ShouldHandleHighPage()
        {
            context.PageSize = 1;
            context.PageNumber = 4;
            context.PageLinkMaxCount = 3;

            Assert.That(context.PageLinks[0], Is.EqualTo(3));
            Assert.That(context.PageLinks.Count, Is.EqualTo(3));
        }

        [Test]
        public void PageLinks_ShouldHandleLastPage()
        {
            context.PageSize = 1;
            context.PageNumber = 5;
            context.PageLinkMaxCount = 3;

            Assert.That(context.PageLinks[0], Is.EqualTo(3));
            Assert.That(context.PageLinks.Count, Is.EqualTo(3));
        }

        [Test]
        public void PageLinks_ShouldHandleAllPageLinks()
        {
            context.PageSize = 1;
            context.PageNumber = 5;
            context.PageLinkMaxCount = 1000;

            Assert.That(context.PageLinks[0], Is.EqualTo(1));
            Assert.That(context.PageLinks.Count, Is.EqualTo(5));
        }

		[Test]
		public void PageNumber_ShouldGetSetValue()
		{
			context.PageSize = 1;

			Assert.That(context.PageCount, Is.EqualTo(5));
			Assert.That(context.PageNumber, Is.EqualTo(1));

			context.PageNumber = 3;

			Assert.That(context.PageNumber, Is.EqualTo(3));
		}

		[Test]
		public void PageNumber_ShouldLimitToPageCount()
		{
			context.PageSize = 1;

			Assert.That(context.PageCount, Is.EqualTo(5));
			Assert.That(context.PageNumber, Is.EqualTo(1));

			context.PageNumber = 30;

			Assert.That(context.PageNumber, Is.EqualTo(5));
		}

		[Test]
		public void PageNumber_ShouldAlwaysBePositive()
		{
			context.PageSize = 1;

			Assert.That(context.PageCount, Is.EqualTo(5));
			Assert.That(context.PageNumber, Is.EqualTo(1));

			context.PageNumber = -1;

			Assert.That(context.PageNumber, Is.EqualTo(1));
		}

		[Test]
		public void PageSize_ShouldGetSetValue()
		{
			Assert.That(context.PageSize, Is.EqualTo(25));
			context.PageSize = 5;
			Assert.That(context.PageSize, Is.EqualTo(5));
		}

		[Test]
		public void PageSize_ShouldAlwaysBePositive()
		{
			context.PageSize = -5;
			Assert.That(context.PageSize, Is.EqualTo(1));
		}

		[Test]
		public void ShowPreviousPageLink_ShouldReturnFalseIfFirstPageIsShowing()
		{
			context.PageSize = 1;
			context.PageNumber = 2;
			context.PageLinkMaxCount = 3;

			Assert.That(context.ShowPreviousPageLink, Is.False);
		}

		[Test]
		public void ShowPreviousPageLink_ShouldReturnTrueIfFirstPageIsNotShowing()
		{
			context.PageSize = 1;
			context.PageNumber = 3;
			context.PageLinkMaxCount = 3;

			Assert.That(context.ShowPreviousPageLink, Is.True);
		}

		[Test]
		public void ShowNextPageLink_ShouldReturnFalseIfLastPageIsShowing()
		{
			context.PageSize = 1;
			context.PageNumber = 4;
			context.PageLinkMaxCount = 3;

			Assert.That(context.ShowNextPageLink, Is.False);
		}

		[Test]
		public void ShowNextPageLink_ShouldReturnTrueIfLastPageIsNotShowing()
		{
			context.PageSize = 1;
			context.PageNumber = 3;
			context.PageLinkMaxCount = 3;

			Assert.That(context.ShowNextPageLink, Is.True);
		}


        [Test]
        public void GetPaginationResult_ShouldHandleFirstItems()
        {
            context.PageSize = 2;
            context.PageNumber = 1;

            var result = context.GetPaginationResult();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(searchResult.AsQueryable().Skip(0).Take(2)));
        }

        [Test]
        public void GetPaginationResult_ShouldHandleMiddleItems()
        {
            context.PageSize = 2;
            context.PageNumber = 2;

            var result = context.GetPaginationResult();

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(searchResult.AsQueryable().Skip(2).Take(2)));
        }

        [Test]
        public void GetPaginationResult_ShouldHandleLastItems()
        {
            context.PageSize = 2;
            context.PageNumber = 3;

            var result = context.GetPaginationResult();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result, Is.EqualTo(searchResult.AsQueryable().Skip(4).Take(2)));
        }
	}
}
