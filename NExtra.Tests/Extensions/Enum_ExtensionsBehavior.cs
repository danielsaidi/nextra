using NExtra.Extensions;
using NUnit.Framework;

namespace NExtra.Tests.Extensions
{
	[TestFixture]
	public class Enum_ExtensionsBehavior
    {
        enum MessageStatus
        {
            New = 1,
            Sent = 2,
            Received = 4
        }


	    private MessageStatus _status;


	    [SetUp]
	    public void SetUp()
	    {
	        _status = MessageStatus.New;
        }


	    [Test]
	    public void Enum_ShouldHaveInitialFlagState()
        {
            Assert.That(_status.HasFlag(MessageStatus.New), Is.True);
            Assert.That(_status.HasFlag(MessageStatus.Sent), Is.False);
            Assert.That(_status.HasFlag(MessageStatus.Received), Is.False);  
	    }


        [Test]
        public void AddFlag_ShouldAddSingleFlag()
        {
            _status = _status.AddFlag(MessageStatus.Sent);

            Assert.That(_status.HasFlag(MessageStatus.New), Is.True);
            Assert.That(_status.HasFlag(MessageStatus.Sent), Is.True);
            Assert.That(_status.HasFlag(MessageStatus.Received), Is.False);
        }

        [Test]
        public void AddFlag_ShouldChainMultipleFlags()
        {
            _status = _status.AddFlag(MessageStatus.Sent).AddFlag(MessageStatus.Received);

            Assert.That(_status.HasFlag(MessageStatus.New), Is.True);
            Assert.That(_status.HasFlag(MessageStatus.Sent), Is.True);
            Assert.That(_status.HasFlag(MessageStatus.Received), Is.True);
        }

        [Test]
        public void RemoveFlag_ShouldRemoveSingleFlag()
        {
            _status = _status.RemoveFlag(MessageStatus.New);

            Assert.That(_status.HasFlag(MessageStatus.New), Is.False);
            Assert.That(_status.HasFlag(MessageStatus.Sent), Is.False);
            Assert.That(_status.HasFlag(MessageStatus.Received), Is.False);
        }

        [Test]
        public void RemoveFlag_ShouldChainMultipleFlags()
        {
            _status = _status.AddFlag(MessageStatus.Sent).AddFlag(MessageStatus.Received).RemoveFlag(MessageStatus.New);

            Assert.That(_status.HasFlag(MessageStatus.New), Is.False);
            Assert.That(_status.HasFlag(MessageStatus.Sent), Is.True);
            Assert.That(_status.HasFlag(MessageStatus.Received), Is.True);
        }
        
	}
}
