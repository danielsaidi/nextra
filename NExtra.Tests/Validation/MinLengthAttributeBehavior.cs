using NExtra.Validation;
using NUnit.Framework;

namespace NExtra.Tests.Validation
{
	[TestFixture]
	public class MinLengthAttributeBehavior
    {
        public IValidator GetValidator(int minLength)
        {
            return new MinLengthAttribute(minLength);
        }

        
		[Test]
		public void IsValid_ShouldHandleNull()
		{
            Assert.That(GetValidator(0).IsValid(null), Is.False);
		}

		[Test]
		public void IsValid_ShouldHandleEmptyString()
        {
            Assert.That(GetValidator(0).IsValid(""), Is.True);
            Assert.That(GetValidator(1).IsValid(""), Is.False);
		}

		[Test]
		public void IsValid_ShouldHandleNonEmptyString()
        {
            Assert.That(GetValidator(0).IsValid("foo"), Is.True);
            Assert.That(GetValidator(1).IsValid("foo"), Is.True);
            Assert.That(GetValidator(2).IsValid("foo"), Is.True);
            Assert.That(GetValidator(3).IsValid("foo"), Is.True);
            Assert.That(GetValidator(4).IsValid("foo"), Is.False);
		}
	}
}