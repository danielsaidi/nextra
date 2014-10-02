using System;
using NExtra.WebForms.WebControls;
using NUnit.Framework;

namespace NExtra.WebForms.Tests.WebControls
{
    [TestFixture]
    public class SubmittableUserControlBehavior
    {
        private SubmittableUserControl _control;
        private int _cancelEventCount;
        private int _submitEventCount;


        [SetUp]
        public void SetUp()
        {
            _control = new SubmittableUserControl();

            _cancelEventCount = 0;
            _submitEventCount = 0;
        }


        [Test]
        public void Cancel_ShouldHandleNullEventHandler()
        {
            _control.Cancel += null;
            _control.OnCancel(null);

            Assert.That(_cancelEventCount, Is.EqualTo(0));
        }

        [Test]
        public void Cancel_ShouldApplyEventHandler()
        {
            _control.Cancel += SubmittableUserControl_Cancel;

            _control.OnCancel(null);
            _control.OnCancel(null);
            _control.OnCancel(null);

            Assert.That(_cancelEventCount, Is.EqualTo(3));
        }

        [Test]
        public void Cancel_ShouldSetProperty()
        {
            _control.Cancel += null;
            _control.OnCancel(null);

            Assert.That(_control.Cancelled, Is.True);
            Assert.That(_control.Submitted, Is.False);
        }

        [Test]
        public void Submit_ShouldHandleNullEventHandler()
        {
            _control.Submit += null;

            _control.OnCancel(null);

            Assert.That(_submitEventCount, Is.EqualTo(0));
        }

        [Test]
        public void Submit_ShouldApplyEventHandler()
        {
            _control.Submit += SubmittableUserControl_Submit;

            _control.OnSubmit(null);
            _control.OnSubmit(null);
            _control.OnSubmit(null);

            Assert.That(_submitEventCount, Is.EqualTo(3));
        }

        [Test]
        public void Submit_ShouldSetProperty()
        {
            _control.Submit += null;

            _control.OnSubmit(null);

            Assert.That(_control.Cancelled, Is.False);
            Assert.That(_control.Submitted, Is.True);
        }


        public void SubmittableUserControl_Cancel(object sender, EventArgs e)
        {
            _cancelEventCount++;
        }

        public void SubmittableUserControl_Submit(object sender, EventArgs e)
        {
            _submitEventCount++;
        }
    }
}
