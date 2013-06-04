using System.Collections.Generic;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class IEnumerable_ExtensionsBehavior
    {
        [Test]
        public void IsNullOrEmpty_ShouldReturnTrueForNullCollection()
        {
            IEnumerable<string> collection = null;

            Assert.That(collection.IsNullOrEmpty(), Is.True);
        }

        [Test]
        public void IsNullOrEmpty_ShouldReturnTrueForEmptyCollection()
        {
            IEnumerable<string> collection = new List<string>();

            Assert.That(collection.IsNullOrEmpty(), Is.True);
        }
    }
}
