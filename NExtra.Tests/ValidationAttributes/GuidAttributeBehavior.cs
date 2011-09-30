using System;
using NExtra.ValidationAttributes;
using NUnit.Framework;

namespace NExtra.Tests.ValidationAttributes
{
	[TestFixture]
	public class GuidAttributeBehavior
    {
        [Test]
        public void IsValid_ShouldReturnFalseForNullAndRequired()
        {
            Assert.That(new GuidAttribute().IsValid(null), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForNullAndOptional()
        {
            Assert.That(new GuidAttribute(false).IsValid(null), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnFalseForEmptyStringAndRequired()
        {
            Assert.That(new GuidAttribute().IsValid(""), Is.False);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForEmptyStringAndOptional()
        {
            Assert.That(new GuidAttribute(false).IsValid(""), Is.True);
        }

		[Test]
		public void IsValid_ShouldReturnFalseForInvalidString()
		{
			Assert.That(new GuidAttribute().IsValid("weghighuihgaweuihgweui"), Is.False);
		}

		[Test]
		public void IsValid_ShouldReturnTrueForValidStrings()
		{
			Assert.That(new GuidAttribute().IsValid(Guid.Empty), Is.True);
			Assert.That(new GuidAttribute().IsValid(Guid.NewGuid()), Is.True);
		}
	}
}