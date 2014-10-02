using NExtra.Security;
using NUnit.Framework;

namespace NExtra.Tests.Security
{
    [TestFixture]
    public class Md5GeneratorBehavior
    {
        private Md5Generator _hashGenerator;


        [SetUp]
        public void SetUp()
        {
            _hashGenerator = new Md5Generator();
        }


        [Test]
        public void GenerateHashValue_ShouldGenerateHashValueWithCorrectLength()
        {
            Assert.That(_hashGenerator.GenerateHashValue("test string").Length, Is.EqualTo(32));
        }

        [Test]
        [TestCase("test string", "test string")]
        public void GenerateHashValue_ShouldGenerateHashForStringValue(object obj, string stringRepresentation)
        {
            Assert.That(_hashGenerator.GenerateHashValue(obj), Is.EqualTo(_hashGenerator.GenerateHashValue(stringRepresentation)));
            Assert.That(_hashGenerator.GenerateHashValue(obj), Is.Not.EqualTo(_hashGenerator.GenerateHashValue(stringRepresentation.ToUpper())));
        }

        [Test]
        public void GenerateHashValue_ShouldHandleAnyObject()
        {
            Assert.That(_hashGenerator.GenerateHashValue(5), Is.EqualTo(_hashGenerator.GenerateHashValue("5")));
        }
    }
}