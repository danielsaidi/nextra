using System.Collections.Generic;
using NExtra.WebForms.WebControls;
using NUnit.Framework;

namespace NExtra.WebForms.Tests.WebControls
{
	class UserControlLoaderTestClass : UserControlPlaceHolder
	{
		public List<string> TestLoadedControls() { return LoadedControls; }
	}

	[TestFixture]
	public class UserControlPlaceHolderBehavior
	{
		private UserControlLoaderTestClass _control;


		[SetUp]
		public void SetUp()
		{
			_control = new UserControlLoaderTestClass();
		}


		[Test]
		public void LoadedControls_ShouldReturnEmptyListByDefault()
		{
			Assert.That(_control.TestLoadedControls(), Is.EqualTo(new List<string>()));
		}

		[Test]
		public void GetControl_ShouldReturnNullForNonexistingId()
		{
			Assert.That(_control.GetControl("foo"), Is.Null);
		}
	}
}
