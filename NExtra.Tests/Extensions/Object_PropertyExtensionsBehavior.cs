using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class Object_PropertyExtensionsBehavior
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void GetPropertyName_ShouldHandleFirstLevelPathComponent()
        {
            var obj = new { Name = "foo" };
            var result = obj.GetFullPropertyName(x => x.Name);

            Assert.That(result, Is.EqualTo("Name"));
        }

        [Test]
        public void GetPropertyName_ShouldHandleSecondLevelPathComponent()
        {
            var obj = new { Address = new { Name = "foo" } };
            var result = obj.GetFullPropertyName(x => x.Address.Name);

            Assert.That(result, Is.EqualTo("Address.Name"));
        }

        [Test]
        public void GetPropertyName_ShouldHandleThirdLevelPathComponent()
        {
            var obj = new { Address = new { AddressComponent = new { Name = "foo" } } };
            var result = obj.GetFullPropertyName(x => x.Address.AddressComponent.Name);

            Assert.That(result, Is.EqualTo("Address.AddressComponent.Name"));
        }
    }
}
