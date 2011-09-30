using System;
using System.Linq;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class StringExtensionsBehavior
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
        public void IsNullOrEmpty_ShouldHandleNull()
        {
            String testString = null;

            Assert.That(testString.IsNullOrEmpty(), Is.True);
        }

        [Test]
        public void IsNullOrEmpty_Trim_ShouldReturnTrueForEmptyString()
        {
            Assert.That("".IsNullOrEmpty(), Is.True);
        }

        [Test]
        public void IsNullOrEmpty_Trim_ShouldReturnFalseForNonEmptyString()
        {
            Assert.That(" ".IsNullOrEmpty(), Is.False);
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

		[Test]
		public void Split_ShouldHandleZeroElements()
		{
			var value = "".Split(",").ToList();

			Assert.That(value.Count, Is.EqualTo(1));
		}

		[Test]
		public void Split_ShouldHandleOneElement()
		{
			var value = "abcdef".Split(",").ToList();

			Assert.That(value.Count, Is.EqualTo(1));
			Assert.That(value[0], Is.EqualTo("abcdef"));
		}

		[Test]
		public void Split_ShouldHandleMultipleElements()
		{
			var value = "a_b_c_d_e_f".Split("_").ToList();

			Assert.That(value.Count, Is.EqualTo(6));
			Assert.That(value[0], Is.EqualTo("a"));
			Assert.That(value[1], Is.EqualTo("b"));
			Assert.That(value[2], Is.EqualTo("c"));
			Assert.That(value[3], Is.EqualTo("d"));
			Assert.That(value[4], Is.EqualTo("e"));
			Assert.That(value[5], Is.EqualTo("f"));
		}

		[Test]
		public void Split_Type_ShouldHandleZeroElements()
		{
			var value = "".Split<int>(",").ToList();

			Assert.That(value.Count, Is.EqualTo(0));
		}

		[Test]
		public void Split_Type_ShouldHandleOneElement()
		{
			var value = "1005".Split<int>(",").ToList();

			Assert.That(value.Count, Is.EqualTo(1));
			Assert.That(value[0], Is.EqualTo(1005));
		}

		[Test]
		public void Split_Type_ShouldHandleMultipleElements()
		{
			var value = "a_b_c_d_e_f".Split("_").ToList();

			Assert.That(value.Count, Is.EqualTo(6));
			Assert.That(value[0], Is.EqualTo("a"));
			Assert.That(value[1], Is.EqualTo("b"));
			Assert.That(value[2], Is.EqualTo("c"));
			Assert.That(value[3], Is.EqualTo("d"));
			Assert.That(value[4], Is.EqualTo("e"));
			Assert.That(value[5], Is.EqualTo("f"));
		}

		[Test]
		public void Split_Type_ShouldHandleIntegers()
		{
			var result = "1,2,3,4,5".Split<int>(",").ToList();

			Assert.That(result.Count, Is.EqualTo(5));
			Assert.That(result[0], Is.EqualTo(1));
			Assert.That(result[1], Is.EqualTo(2));
			Assert.That(result[2], Is.EqualTo(3));
			Assert.That(result[3], Is.EqualTo(4));
			Assert.That(result[4], Is.EqualTo(5));
		}

		[Test]
		public void Split_Type_ShouldHandleDoubles()
		{
			var result = "1,1;2,2;3,3;4,4;5,5".Split<double>(";").ToList();

			Assert.That(result.Count, Is.EqualTo(5));
			Assert.That(result[0], Is.EqualTo(1.1));
			Assert.That(result[1], Is.EqualTo(2.2));
			Assert.That(result[2], Is.EqualTo(3.3));
			Assert.That(result[3], Is.EqualTo(4.4));
			Assert.That(result[4], Is.EqualTo(5.5));
		}

		[Test]
		public void Split_Type_ShouldHandleBooleans()
		{
			var result = "true,false".Split<bool>(",").ToList();

			Assert.That(result.Count, Is.EqualTo(2));
			Assert.That(result[0], Is.True);
			Assert.That(result[1], Is.False);
		}

		[Test]
		public void Split_Type_ShouldHandleDecimals()
		{
			var result = "1,1111;2,2222;3,3333;4,4444;5,5555".Split<decimal>(";").ToList();

			Assert.That(result.Count, Is.EqualTo(5));
			Assert.That(result[0], Is.EqualTo(1.1111));
			Assert.That(result[1], Is.EqualTo(2.2222));
			Assert.That(result[2], Is.EqualTo(3.3333));
			Assert.That(result[3], Is.EqualTo(4.4444));
			Assert.That(result[4], Is.EqualTo(5.5555));
		}

		[Test]
		public void Split_Type_ShouldHandleDateTimes()
		{
			var result = "2010-10-01,a,   2010-10-02  ".Split<DateTime>(",").ToList();

			Assert.That(result.Count, Is.EqualTo(2));
			Assert.That(result[0], Is.EqualTo(new DateTime(2010, 10, 01)));
			Assert.That(result[1], Is.EqualTo(new DateTime(2010, 10, 02)));
		}

		[Test]
		public void Split_Type_ThrowExceptionOnError_ShouldSucceedForValidElements()
		{
			var result = "2010-10-01, 2010-10-02  ".Split<DateTime>(",", true).ToList();

			Assert.That(result.Count, Is.EqualTo(2));
			Assert.That(result[0], Is.EqualTo(new DateTime(2010, 10, 01)));
			Assert.That(result[1], Is.EqualTo(new DateTime(2010, 10, 02)));
		}

		[Test, ExpectedException(typeof(FormatException))]
		public void Split_Type_ThrowExceptionOnError_ShouldFailForInvalidElements()
		{
			var result = "2010-10-01,a,   2010-10-02  ".Split<DateTime>(",", true).ToList();

			Assert.That(result.Count, Is.EqualTo(2));
			Assert.That(result[0], Is.EqualTo(new DateTime(2010, 10, 01)));
			Assert.That(result[1], Is.EqualTo(new DateTime(2010, 10, 02)));
		}

		[Test]
		public void To_ShouldHandleNull()
		{
			String testString = null;
			Assert.That(testString.To<bool>(), Is.Null);
		}

		[Test]
		public void To_ShouldHandleInvalid()
		{
			Assert.That("a".To<bool>(), Is.Null);
		}

		[Test]
		public void To_ShouldHandleBoolean()
		{
			Assert.That("false".To<bool>(), Is.False);
			Assert.That("true".To<bool>(), Is.True);
		}

		[Test]
		public void To_ShouldHandleDouble()
		{
			Assert.That("1".To<double>(), Is.EqualTo(1.0));
			Assert.That("50".To<double>(), Is.EqualTo(50.0));
		}

		[Test]
		public void To_ShouldHandleInteger()
		{
			Assert.That("1".To<int>(), Is.EqualTo(1));
			Assert.That("50".To<int>(), Is.EqualTo(50));
		}

		[Test]
		public void ToEnum_ShouldFallbackForInvalidValue()
		{
			Assert.That("Nones".ToEnum(StringSplitOptions.RemoveEmptyEntries), Is.EqualTo(StringSplitOptions.RemoveEmptyEntries));
		}

		[Test]
		public void ToEnum_ShouldHandleValidValue()
		{
			Assert.That("None".ToEnum(StringSplitOptions.RemoveEmptyEntries), Is.EqualTo(StringSplitOptions.None));
			Assert.That("RemoveEmptyEntries".ToEnum(StringSplitOptions.RemoveEmptyEntries), Is.EqualTo(StringSplitOptions.RemoveEmptyEntries));
        }
    }
}