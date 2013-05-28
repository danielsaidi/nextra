using System.Collections.Specialized;
using System.Linq;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class NameValueCollection_ExtensionsBehavior
    {
        private NameValueCollection _collection;


        [SetUp]
        public void Setup()
        {
            _collection = new NameValueCollection {{"foo", "bar"}};
        }


        [Test]
        public void AsKeyValuePair_ShouldConvertCollectionToEnumerable()
        {
            var result = _collection.AsKeyValuePairs().ToList();

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.That(result.First().Key, Is.EqualTo("foo"));
            Assert.That(result.First().Value, Is.EqualTo("bar"));
        }

        [Test]
        public void TryGetValue_ShouldReturnFallbackForNonExistingKey()
        {
            var result = _collection.TryGetValue("bar", "fallback");

            Assert.That(result, Is.EqualTo("fallback"));
        }

        [Test]
        public void TryGetValue_ShouldReturnExistingKey()
        {
            var result = _collection.TryGetValue("foo", "fallback");

            Assert.That(result, Is.EqualTo("bar"));
        }
    }
}
