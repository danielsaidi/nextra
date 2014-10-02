using System.Collections.Generic;
using System.Linq;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class IEnumerable_PaginateExtensionsBehavior
    {
        private List<KeyValuePair<string, int>> _collection;


        [SetUp]
        public void SetUp()
        {
            _collection = new List<KeyValuePair<string, int>> {
				new KeyValuePair<string, int>("a", 99),
				new KeyValuePair<string, int>("b", 98),
				new KeyValuePair<string, int>("c", 97),
				new KeyValuePair<string, int>("d", 96),
				new KeyValuePair<string, int>("e", 95)
			};
        }

        [Test]
        public void Paginate_ShouldHandleFirstItems()
        {
            var result = _collection.Paginate(1, 2);

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(_collection.Skip(0).Take(2)));
        }

        [Test]
        public void Paginate_ShouldHandleMiddleItems()
        {
            var result = _collection.Paginate(2, 2);

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result, Is.EqualTo(_collection.Skip(2).Take(2)));
        }

        [Test]
        public void Paginate_ShouldHandleLastItems()
        {
            var result = _collection.Paginate(3, 2);

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result, Is.EqualTo(_collection.Skip(4).Take(2)));
        }
    }
}
