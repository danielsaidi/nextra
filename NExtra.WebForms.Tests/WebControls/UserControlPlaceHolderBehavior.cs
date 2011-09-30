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
		private UserControlLoaderTestClass control;


		[SetUp]
		public void SetUp()
		{
			control = new UserControlLoaderTestClass();
		}


		[Test]
		public void LoadedControls_ShouldReturnEmptyListByDefault()
		{
			Assert.That(control.TestLoadedControls(), Is.EqualTo(new List<string>()));
		}

		[Test]
		public void GetControl_ShouldReturnNullForNonexistingId()
		{
			Assert.That(control.GetControl("foo"), Is.Null);
		}
	}
}
