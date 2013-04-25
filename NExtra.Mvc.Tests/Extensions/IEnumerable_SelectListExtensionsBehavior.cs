using System.Linq;
using NExtra.Mvc.Extensions;
using NSubstitute;
using NUnit.Framework;

namespace NExtra.Mvc.Tests.Extensions
{
    [TestFixture]
    public class IEnumerable_SelectListExtensionsBehavior
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void ToSelectList_ShouldSetTextAndValue()
        {
            var collection = new[] {"foo", "bar"};
            var result = collection.ToSelectList();
            

            Assert.That(result.First().Text, Is.EqualTo("foo"));
            Assert.That(result.First().Value, Is.EqualTo("foo"));
            Assert.That(result.Last().Text, Is.EqualTo("bar"));
            Assert.That(result.Last().Value, Is.EqualTo("bar"));
        }
    }
}
