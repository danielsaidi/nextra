using System;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class String_ExtensionsBehavior
	{
    	[Test]
        public void CountSubstring_ShouldReturnZeroForNonExistingPattern()
        {
            const string value = "foo";

            Assert.That(value.CountSubstring("bar"), Is.EqualTo(0));
        }

        [Test]
        public void CountSubstring_ShouldReturnCorrectCountForExistingPattern()
        {
            const string value = "foo bar foo";

            Assert.That(value.CountSubstring("foo"), Is.EqualTo(2));
            Assert.That(value.CountSubstring("bar"), Is.EqualTo(1));
        }

        [Test]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public void HasContent_ShouldReturnFalseForNullOrEmptyString(string value)
        {
            Assert.That(value.HasContent(), Is.False);
        }

        [Test]
        [TestCase("foo")]
        public void HasContent_ShouldReturnTrueForNonEmptyString(string value)
        {
            Assert.That(value.HasContent(), Is.True);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void IsNullOrEmpty_ShouldReturnTrueForNullOrEmptyString(string value)
        {
            Assert.That(value.IsNullOrEmpty(), Is.True);
        }

        [Test]
        [TestCase("   ")]
        [TestCase("foo")]
        public void IsNullOrEmpty_ShouldReturnFalseForNonEmptyString(string value)
        {
            Assert.That(value.IsNullOrEmpty(), Is.False);
        }

        [Test]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public void IsNullOrWhiteSpace_ShouldReturnTrueForNullOrEmptyString(string value)
        {
            Assert.That(value.IsNullOrWhiteSpace(), Is.True);
        }

        [Test]
        [TestCase("foo")]
        public void IsNullOrWhiteSpace_ShouldReturnFalseForNonEmptyString(string value)
        {
            Assert.That(value.IsNullOrWhiteSpace(), Is.False);
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Shorten_ShouldFailUsingNegativeMaxLength()
        {
            Assert.That("abcdefghijklmnopqrstuvxyz".Shorten(-1), Is.EqualTo("abcdefghijklmnopqrstuvxyz"));
        }

        [Test]
        public void Shorten_ShouldNotAffectShortStrings()
        {
            Assert.That("abcdefghijklmnopqrstuvxyz".Shorten(100).Length, Is.EqualTo("abcdefghijklmnopqrstuvxyz".Length));
        }

        [Test]
        public void Shorten_ShouldAffectLongStringsWithoutOverflowReplacement()
        {
            Assert.That("abcdefghijklmnopqrstuvxyz".Shorten(10), Is.EqualTo("abcdefghij"));
        }

        [Test]
        public void Shorten_ShouldAffectLongStringsWithOverflowReplacement()
        {
            Assert.That("abcdefghijklmnopqrstuvxyz".Shorten(10, "..."), Is.EqualTo("abcdefghij..."));
        }
    }
}