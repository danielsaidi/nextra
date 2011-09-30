using NExtra.Web.Avatar;
using NExtra.Web.Security;
using NUnit.Framework;

namespace NExtra.Web.Tests.Avatar
{
    [TestFixture]
    public class GravatarBehavior
    {
        private Gravatar avatarService;


        [SetUp]
        public void SetUp()
        {
            avatarService = new Gravatar();
        }


        [Test]
        public void GetAvatarUrl_ShouldUseCorrectDefaultSize()
        {
            var url = avatarService.GetAvatarUrl("foo@bar.com");
            var md5 = new Md5Generator().GenerateHashValue("foo@bar.com").ToLower();

            Assert.That(url, Is.EqualTo(string.Format("http://www.gravatar.com/avatar/{0}?s=80", md5)));
        }

        [Test]
        public void GetAvatarUrl_ShouldReturnUrlWithEmailAddressMd5ValueAndCustomSize()
        {
            var url = avatarService.GetAvatarUrl("foo@bar.com", 200);
            var md5 = new Md5Generator().GenerateHashValue("foo@bar.com").ToLower();

            Assert.That(url, Is.EqualTo(string.Format("http://www.gravatar.com/avatar/{0}?s=200", md5)));
        }
    }
}
