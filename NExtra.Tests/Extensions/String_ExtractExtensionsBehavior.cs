using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class String_ExtractExtensionsBehavior
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void ExtractDouble_ShouldReturnZeroForNoDouble()
        {
            var result = "foo".ExtractDouble();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void ExtractDouble_ShouldHandleIntegerAsWell()
        {
            var result = "123".ExtractDouble();

            Assert.That(result, Is.EqualTo(123));
        }

        [Test]
        public void ExtractDouble_ShouldReturnPlainDouble()
        {
            var result = "123.5".ExtractDouble();

            Assert.That(result, Is.EqualTo(123.5));
        }

        [Test]
        public void ExtractDouble_ShouldReturnDoubleBeforeString()
        {
            var result = "123.5 foo".ExtractDouble();

            Assert.That(result, Is.EqualTo(123.5));
        }

        [Test]
        public void ExtractDouble_ShouldReturnDoubleAfterString()
        {
            var result = "foo 123.5".ExtractDouble();

            Assert.That(result, Is.EqualTo(123.5));
        }

        [Test]
        public void ExtractInt_ShouldReturnZeroForNoInteger()
        {
            var result = "foo".ExtractInt();

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void ExtractInt_ShouldReturnPlainInteger()
        {
            var result = "123".ExtractInt();

            Assert.That(result, Is.EqualTo(123));
        }

        [Test]
        public void ExtractInt_ShouldReturnIntegerBeforeString()
        {
            var result = "123 foo".ExtractInt();

            Assert.That(result, Is.EqualTo(123));
        }

        [Test]
        public void ExtractInt_ShouldReturnIntegerAfterString()
        {
            var result = "foo 123".ExtractInt();

            Assert.That(result, Is.EqualTo(123));
        }
    }
}
