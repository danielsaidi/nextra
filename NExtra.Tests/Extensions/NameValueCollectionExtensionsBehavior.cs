using System.Collections.Specialized;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class NameValueCollectionExtensionsBehavior
    {
        private NameValueCollection collection;


        [SetUp]
        public void Setup()
        {
            collection = new NameValueCollection {{"foo", "bar"}};
        }


        [Test]
        public void TryGetValue_ShouldReturnFallbackForNonExistingKey()
        {
            var result = collection.TryGetValue("bar", "fallback");

            Assert.That(result, Is.EqualTo("fallback"));
        }

        [Test]
        public void TryGetValue_ShouldReturnExistingKey()
        {
            var result = collection.TryGetValue("foo", "fallback");

            Assert.That(result, Is.EqualTo("bar"));
        }
    }
}
