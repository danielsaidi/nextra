using NExtra.Web.Avatar;
using NExtra.Web.Security;
using NUnit.Framework;

namespace NExtra.Web.Tests.Avatar
{
    [TestFixture]
    public class GravatarServiceBehavior
    {
        private GravatarService _service;


        [SetUp]
        public void SetUp()
        {
            _service = new GravatarService();
        }


        [Test]
        public void GetAvatarUrl_ShouldReturnUrlWithEmailAddressMd5ValueAndCustomSize()
        {
            var url = _service.GetAvatarUrl("foo@bar.com", 200);
            var md5 = new FormsAuthenticationBasedMd5Generator().GenerateHashValue("foo@bar.com").ToLower();

            Assert.That(url, Is.EqualTo(string.Format("http://www.gravatar.com/avatar/{0}?s=200", md5)));
        }
    }
}
