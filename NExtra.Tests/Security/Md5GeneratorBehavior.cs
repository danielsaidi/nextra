using NExtra.Security;
using NUnit.Framework;

namespace NExtra.Tests.Security
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
        [TestCase("test string", "test string")]
        public void GenerateHashValue_ShouldGenerateHashForStringValue(object obj, string stringRepresentation)
        {
            Assert.That(hashGenerator.GenerateHashValue(obj), Is.EqualTo(hashGenerator.GenerateHashValue(stringRepresentation)));
            Assert.That(hashGenerator.GenerateHashValue(obj), Is.Not.EqualTo(hashGenerator.GenerateHashValue(stringRepresentation.ToUpper())));
        }

        [Test]
        public void GenerateHashValue_ShouldHandleAnyObject()
        {
            Assert.That(hashGenerator.GenerateHashValue(5), Is.EqualTo(hashGenerator.GenerateHashValue("5")));
        }
    }
}