using NExtra.Web.Testing;
using NUnit.Framework;

namespace NExtra.Web.Tests.Testing
{
    [TestFixture]
    public class FakeMembershipUserBehavior
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Constructor_ShouldCreateInstance()
        {
            var user = new FakeMembershipUser();

            Assert.That(user, Is.Not.Null);
        }
    }
}