using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
	[TestFixture]
	public class EnumExtensionsBehavior
    {
        enum MessageStatus
        {
            New = 1,
            Sent = 2,
            Received = 4
        }


	    private MessageStatus status;


	    [SetUp]
	    public void SetUp()
	    {
	        status = MessageStatus.New;
        }


	    [Test]
	    public void Enum_ShouldHaveInitialFlagState()
        {
            Assert.That(status.HasFlag(MessageStatus.New), Is.True);
            Assert.That(status.HasFlag(MessageStatus.Sent), Is.False);
            Assert.That(status.HasFlag(MessageStatus.Received), Is.False);  
	    }


        [Test]
        public void AddFlag_ShouldAddSingleFlag()
        {
            status = status.AddFlag(MessageStatus.Sent);

            Assert.That(status.HasFlag(MessageStatus.New), Is.True);
            Assert.That(status.HasFlag(MessageStatus.Sent), Is.True);
            Assert.That(status.HasFlag(MessageStatus.Received), Is.False);
        }

        [Test]
        public void AddFlag_ShouldChainMultipleFlags()
        {
            status = status.AddFlag(MessageStatus.Sent).AddFlag(MessageStatus.Received);

            Assert.That(status.HasFlag(MessageStatus.New), Is.True);
            Assert.That(status.HasFlag(MessageStatus.Sent), Is.True);
            Assert.That(status.HasFlag(MessageStatus.Received), Is.True);
        }

        [Test]
        public void RemoveFlag_ShouldRemoveSingleFlag()
        {
            status = status.RemoveFlag(MessageStatus.New);

            Assert.That(status.HasFlag(MessageStatus.New), Is.False);
            Assert.That(status.HasFlag(MessageStatus.Sent), Is.False);
            Assert.That(status.HasFlag(MessageStatus.Received), Is.False);
        }

        [Test]
        public void RemoveFlag_ShouldChainMultipleFlags()
        {
            status = status.AddFlag(MessageStatus.Sent).AddFlag(MessageStatus.Received).RemoveFlag(MessageStatus.New);

            Assert.That(status.HasFlag(MessageStatus.New), Is.False);
            Assert.That(status.HasFlag(MessageStatus.Sent), Is.True);
            Assert.That(status.HasFlag(MessageStatus.Received), Is.True);
        }
        
	}
}
