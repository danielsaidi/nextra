using NUnit.Framework;

namespace NExtra.Tests
{
    [TestFixture]
    public class EventArgsBehavior
    {
        [SetUp]
        public void SetUp()
        {
        }


        [Test]
        public void Constructor_ShouldSetFields()
        {
            const string obj = "";
            var args = new EventArgs<string>(obj);

            Assert.That(args.Object, Is.EqualTo(obj));
        }
    }
}