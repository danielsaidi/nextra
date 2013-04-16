using System.Collections.Generic;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
	public class IDictionary_ExtensionsBehavior
    {
        private Dictionary<string, string> obj;


        [SetUp]
        public void SetUp()
        {
            obj = new Dictionary<string, string> { { "foo", "bar" }, { "bar", "foo" } };
        }


        [Test]
        public void AddRange_ShouldNotAddAnyItemsWhenAllAreDuplicate()
        {
            var items = new Dictionary<string, string> { { "foo", "bar" }, { "bar", "foo" } };

            obj.AddRange(items);

            Assert.That(obj.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddRange_ShouldOnlyAddSomeItemsWhenSomeAreDuplicate()
        {
            var items = new Dictionary<string, string> { { "foo", "bar" }, { "bar1", "foo" } };

            obj.AddRange(items);

            Assert.That(obj.Count, Is.EqualTo(3));
        }

        [Test]
        public void AddRange_ShouldAddAllItemsWhenNoneAreDuplicate()
        {
            var items = new Dictionary<string, string> { { "foo1", "bar" }, { "bar1", "foo" } };

            obj.AddRange(items);

            Assert.That(obj.Count, Is.EqualTo(4));
        }


        [Test, ExpectedException(typeof(KeyNotFoundException))]
        public void Get_ShouldFailForNonExistingValye()
        {
            var result = obj.Get("foobar");

            Assert.That(result, Is.Null);
        }

        [Test]
        public void Get_ShouldReturnExistingValue()
        {
            var result = obj.Get("foo");

            Assert.That(result, Is.EqualTo("bar"));
        }
    }
}