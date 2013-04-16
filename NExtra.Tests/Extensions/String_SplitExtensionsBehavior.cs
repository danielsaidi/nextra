using System;
using System.Linq;
using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
    [TestFixture]
    public class String_SplitExtensionsBehavior
	{
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
		public void SplitWithType_ShouldHandleZeroElements()
		{
			var value = "".Split<int>(",").ToList();

			Assert.That(value.Count, Is.EqualTo(0));
		}

		[Test]
		public void SplitWithType_ShouldHandleOneElement()
		{
			var value = "1005".Split<int>(",").ToList();

			Assert.That(value.Count, Is.EqualTo(1));
			Assert.That(value[0], Is.EqualTo(1005));
		}

		[Test]
		public void SplitWithType_ShouldHandleMultipleElements()
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
		public void SplitWithType_ShouldHandleIntegers()
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
		public void SplitWithType_ShouldHandleDoubles()
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
		public void SplitWithType_ShouldHandleBooleans()
		{
			var result = "true,false".Split<bool>(",").ToList();

			Assert.That(result.Count, Is.EqualTo(2));
			Assert.That(result[0], Is.True);
			Assert.That(result[1], Is.False);
		}

		[Test]
		public void SplitWithType_ShouldHandleDecimals()
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
		public void SplitWithType_ShouldHandleDateTimes()
		{
			var result = "2010-10-01,a,   2010-10-02  ".Split<DateTime>(",").ToList();

			Assert.That(result.Count, Is.EqualTo(2));
			Assert.That(result[0], Is.EqualTo(new DateTime(2010, 10, 01)));
			Assert.That(result[1], Is.EqualTo(new DateTime(2010, 10, 02)));
		}

		[Test]
		public void SplitWithType_ThrowExceptionOnError_ShouldSucceedForValidElements()
		{
			var result = "2010-10-01, 2010-10-02  ".Split<DateTime>(",", true).ToList();

			Assert.That(result.Count, Is.EqualTo(2));
			Assert.That(result[0], Is.EqualTo(new DateTime(2010, 10, 01)));
			Assert.That(result[1], Is.EqualTo(new DateTime(2010, 10, 02)));
		}

		[Test, ExpectedException(typeof(FormatException))]
		public void SplitWithType_ThrowExceptionOnError_ShouldFailForInvalidElements()
		{
			var result = "2010-10-01,a,   2010-10-02  ".Split<DateTime>(",", true).ToList();

			Assert.That(result.Count, Is.EqualTo(2));
			Assert.That(result[0], Is.EqualTo(new DateTime(2010, 10, 01)));
			Assert.That(result[1], Is.EqualTo(new DateTime(2010, 10, 02)));
		}
    }
}