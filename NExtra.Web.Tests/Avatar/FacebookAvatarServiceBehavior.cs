using NExtra.Web.Avatar;
using NUnit.Framework;

namespace NExtra.Web.Tests.Avatar
{
    [TestFixture]
    public class FacebookAvatarServiceBehavior
    {
        private FacebookAvatarService _service;


        [SetUp]
        public void SetUp()
        {
            _service = new FacebookAvatarService();
        }


        [Test]
        public void GetAvatarUrl_ShouldApplyCustomSize()
        {
            Assert.That(_service.GetAvatarUrl("foo@bar.com", FacebookAvatarSize.Large), Is.EqualTo(string.Format("http://graph.facebook.com/{0}/picture?type=large", "foo@bar.com")));
            Assert.That(_service.GetAvatarUrl("foo@bar.com", FacebookAvatarSize.Small), Is.EqualTo(string.Format("http://graph.facebook.com/{0}/picture?type=small", "foo@bar.com")));
            Assert.That(_service.GetAvatarUrl("foo@bar.com", FacebookAvatarSize.Square), Is.EqualTo(string.Format("http://graph.facebook.com/{0}/picture?type=square", "foo@bar.com")));
        }
    }
}