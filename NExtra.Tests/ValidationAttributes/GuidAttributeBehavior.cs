using System;
using NExtra.ValidationAttributes;
using NUnit.Framework;

namespace NExtra.Tests.ValidationAttributes
{
	[TestFixture]
	public class GuidAttributeBehavior
    {
        [Test]
        public void IsValid_ShouldReturnTrueForNullValue()
        {
            Assert.That(new GuidAttribute().IsValid(null), Is.True);
        }

        [Test]
        public void IsValid_ShouldReturnTrueForEmptyString()
        {
            Assert.That(new GuidAttribute().IsValid(""), Is.True);
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