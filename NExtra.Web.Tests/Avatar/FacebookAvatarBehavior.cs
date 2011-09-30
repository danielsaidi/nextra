using NExtra.Web.Avatar;
using NUnit.Framework;

namespace NExtra.Web.Tests.Avatar
{
    [TestFixture]
    public class FacebookAvatarBehavior
    {
        private FacebookAvatar avatarService;


        [SetUp]
        public void SetUp()
        {
            avatarService = new FacebookAvatar();
        }


        [Test]
        public void GetAvatarUrl_ShouldApplyDefaultSize()
        {
            var url = avatarService.GetAvatarUrl("foo@bar.com");

            Assert.That(url, Is.EqualTo(string.Format("http://graph.facebook.com/{0}/picture?type=small", "foo@bar.com")));
        }

        [Test]
        public void GetAvatarUrl_ShouldApplyCustomSize()
        {
            Assert.That(avatarService.GetAvatarUrl("foo@bar.com", FacebookAvatarSize.Large), Is.EqualTo(string.Format("http://graph.facebook.com/{0}/picture?type=large", "foo@bar.com")));
            Assert.That(avatarService.GetAvatarUrl("foo@bar.com", FacebookAvatarSize.Small), Is.EqualTo(string.Format("http://graph.facebook.com/{0}/picture?type=small", "foo@bar.com")));
            Assert.That(avatarService.GetAvatarUrl("foo@bar.com", FacebookAvatarSize.Square), Is.EqualTo(string.Format("http://graph.facebook.com/{0}/picture?type=square", "foo@bar.com")));
        }
    }
}