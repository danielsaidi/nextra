using System;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class String_ConvertExtensionsBehavior
    {
        [Test]
        public void ConvertTo_ShouldHandleNull()
        {
            String testString = null;
            Assert.That(testString.ConvertTo<bool>(), Is.Null);
        }
        [Test]
        public void ConvertTo_ShouldHandleNullWithFallback()
        {
            String testString = null;
            Assert.That(testString.ConvertTo(true), Is.True);
        }

        [Test]
        public void ConvertTo_ShouldHandleInvalid()
        {
            Assert.That("a".ConvertTo<bool>(), Is.Null);
        }

        [Test]
        public void ConvertTo_ShouldHandleInvalidWithFallback()
        {
            Assert.That("a".ConvertTo(true), Is.True);
        }

		[Test]
		public void ConvertTo_ShouldHandleBoolean()
		{
			Assert.That("false".ConvertTo<bool>(), Is.False);
			Assert.That("true".ConvertTo<bool>(), Is.True);
		}

		[Test]
		public void ConvertTo_ShouldHandleDouble()
		{
			Assert.That("1".ConvertTo<double>(), Is.EqualTo(1.0));
			Assert.That("50".ConvertTo<double>(), Is.EqualTo(50.0));
		}

		[Test]
		public void ConvertTo_ShouldHandleInteger()
		{
			Assert.That("1".ConvertTo<int>(), Is.EqualTo(1));
			Assert.That("50".ConvertTo<int>(), Is.EqualTo(50));
		}

		[Test]
		public void ConvertToEnum_ShouldFallbackForInvalidValue()
		{
			Assert.That("Nones".ConvertToEnum(StringSplitOptions.RemoveEmptyEntries), Is.EqualTo(StringSplitOptions.RemoveEmptyEntries));
		}

		[Test]
        public void ConvertToEnum_ShouldHandleValidValue()
		{
			Assert.That("None".ConvertToEnum(StringSplitOptions.RemoveEmptyEntries), Is.EqualTo(StringSplitOptions.None));
			Assert.That("RemoveEmptyEntries".ConvertToEnum(StringSplitOptions.RemoveEmptyEntries), Is.EqualTo(StringSplitOptions.RemoveEmptyEntries));
        }
    }
}