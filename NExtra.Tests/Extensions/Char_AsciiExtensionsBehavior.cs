using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class Char_AsciiExtensionsBehavior
    {
        [Test]
        [TestCase('a')]
        [TestCase('0')]
        [TestCase('€')]
        public void RemapInternationalCharToAscii_ShouldReturnEmptyStringForNonInternationalChars(char c)
        {
            var result = c.RemapInternationalCharToAscii();

            Assert.That(result, Is.EqualTo(string.Empty));
        }

        [Test]
        [TestCase('å', "a")]
        [TestCase('ö', "o")]
        [TestCase('ü', "u")]
        public void RemapInternationalCharToAscii_ShouldReturnAsciiStringForInternationalChars(char c, string expected)
        {
            var result = c.RemapInternationalCharToAscii();

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}