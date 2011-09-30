using NUnit.Framework;

namespace NExtra.Tests
{
    [TestFixture]
	public class NullableBehavior
    {
        [Test]
        public void Constructor_ShouldCreateDefaultInstance()
        {
            var obj = new Nullable<string>();

            Assert.That(obj.HasValue, Is.False);
        }

        [Test]
        public void Constructor_ShouldCreateCustomInstance()
        {
            var obj = new Nullable<string>("foo");

            Assert.That(obj.HasValue, Is.True);
            Assert.That(obj.Value, Is.EqualTo("foo"));
        }


		[Test]
		public void HasValue_ShouldReturnCorrectValue()
		{
			var nullable = new Nullable<string>();

			Assert.That(nullable.HasValue, Is.False);

			nullable.Value = "foo bar";

			Assert.That(nullable.HasValue, Is.True);
		}

		[Test]
		public void Value_ShouldGetSetCorrectValue()
		{
			var nullable = new Nullable<string>();

			Assert.That(nullable.Value, Is.Null);

			nullable.Value = "foo bar";

			Assert.That(nullable.Value, Is.EqualTo("foo bar"));
		}
    }
}