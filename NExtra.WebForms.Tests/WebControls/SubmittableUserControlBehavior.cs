using System;
using NExtra.WebForms.WebControls;
using NUnit.Framework;

namespace NExtra.WebForms.Tests.WebControls
{
	[TestFixture]
	public class SubmittableUserControlBehavior
	{
		private SubmittableUserControl control;
		private int cancelEventCount;
		private int submitEventCount;


		[SetUp]
		public void SetUp()
		{
			control = new SubmittableUserControl();

			cancelEventCount = 0;
			submitEventCount = 0;
		}


		[Test]
		public void Cancel_ShouldHandleNullEventHandler()
		{
		    control.Cancel += null;
			control.OnCancel(null);

			Assert.That(cancelEventCount, Is.EqualTo(0));
		}

		[Test]
		public void Cancel_ShouldApplyEventHandler()
		{
			control.Cancel += SubmittableUserControl_Cancel;

			control.OnCancel(null);
			control.OnCancel(null);
			control.OnCancel(null);

			Assert.That(cancelEventCount, Is.EqualTo(3));
		}

        [Test]
        public void Cancel_ShouldSetProperty()
        {
            control.Cancel += null;
            control.OnCancel(null);

            Assert.That(control.Cancelled, Is.True);
            Assert.That(control.Submitted, Is.False);
        }

        [Test]
		public void Submit_ShouldHandleNullEventHandler()
		{
			control.Submit += null;

			control.OnCancel(null);

			Assert.That(submitEventCount, Is.EqualTo(0));
		}

		[Test]
		public void Submit_ShouldApplyEventHandler()
		{
			control.Submit += SubmittableUserControl_Submit;

			control.OnSubmit(null);
			control.OnSubmit(null);
			control.OnSubmit(null);

			Assert.That(submitEventCount, Is.EqualTo(3));
		}

        [Test]
        public void Submit_ShouldSetProperty()
        {
            control.Submit += null;

            control.OnSubmit(null);

            Assert.That(control.Cancelled, Is.False);
            Assert.That(control.Submitted, Is.True);
        }


		public void SubmittableUserControl_Cancel(object sender, EventArgs e)
        {
            cancelEventCount++;
        }

        public void SubmittableUserControl_Submit(object sender, EventArgs e)
        {
            submitEventCount++;
        }
	}
}
