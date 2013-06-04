using System.Collections.Generic;
using System.Linq;
using NExtra.Collections;
using NUnit.Framework;

namespace NExtra.Tests.Collections
{
    [TestFixture]
    public class OrderContextTests
    {
        private IOrderContext<KeyValuePair<string, int>> _context;
        private List<KeyValuePair<string, int>> _fakeSearchResult;


        [SetUp]
        public void Setup()
        {
            _fakeSearchResult = new List<KeyValuePair<string, int>>
			{
				new KeyValuePair<string, int>("a", 99),
				new KeyValuePair<string, int>("b", 98),
				new KeyValuePair<string, int>("c", 97),
				new KeyValuePair<string, int>("d", 96),
				new KeyValuePair<string, int>("e", 95)
			};

            _context = new OrderContext<KeyValuePair<string, int>>(_fakeSearchResult, "Key", false);
        }


        [Test]
        public void Constructor_ShouldApplyDefaultParameters()
        {
            Assert.That(_context.Collection, Is.EqualTo(_fakeSearchResult));
            Assert.That(_context.OrderByPropertyName, Is.EqualTo("Key"));
            Assert.That(_context.Descending, Is.EqualTo(false));
        }


        [Test]
        public void GetOrderedResult_ShouldApplyDefaultParameters()
        {
            var result = _context.GetOrderedResult();

            Assert.That(result, Is.EqualTo(_fakeSearchResult));
        }

        [Test]
        public void GetOrderedResult_ShouldApplyDescending()
        {
            _context.Descending = true;

            var result = _context.GetOrderedResult();

            Assert.That(result.Reverse(), Is.EqualTo(_fakeSearchResult));
        }

        [Test]
        public void GetOrderedResult_ShouldApplyOrderByPropertyName()
        {
            _context.OrderByPropertyName = "Value";

            var result = _context.GetOrderedResult();

            Assert.That(result.Reverse(), Is.EqualTo(_fakeSearchResult));
        }

        [Test]
        public void GetOrderedResult_ShouldApplyOrderByPropertyNameWithDescending()
        {
            _context.OrderByPropertyName = "Value";
            _context.Descending = true;

            var result = _context.GetOrderedResult();

            Assert.That(result, Is.EqualTo(_fakeSearchResult));
        }
         
    }
}
