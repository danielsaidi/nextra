using NExtra.Web.Security;
using NUnit.Framework;

namespace NExtra.Web.Tests.Security
{
    [TestFixture]
    public class Md5GeneratorBehavior
    {
        private Md5Generator hashGenerator;


        [SetUp]
        public void SetUp()
        {
            hashGenerator = new Md5Generator();
        }


        [Test]
        public void GenerateHashValue_ShouldGenerateHashValueWithCorrectLength()
        {
            Assert.That(hashGenerator.GenerateHashValue("test string").Length, Is.EqualTo(32));
        }

        [Test]
        public void GenerateHashValue_ShouldGenerateCaseSensitiveHashValue()
        {
            Assert.That(hashGenerator.GenerateHashValue("test string"), Is.EqualTo(hashGenerator.GenerateHashValue("test string")));
            Assert.That(hashGenerator.GenerateHashValue("test string"), Is.Not.EqualTo(hashGenerator.GenerateHashValue("Test string")));
        }

		[Test]
        public void GenerateHashValue_ShouldHandleAnyObject()
        {
            Assert.That(hashGenerator.GenerateHashValue(5), Is.EqualTo(hashGenerator.GenerateHashValue("5")));
		}
    }
}