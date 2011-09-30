using System.Web.UI;
using System.Web.UI.WebControls;
using NExtra.WebForms.Extensions;
using NUnit.Framework;

namespace NExtra.WebForms.Tests.Extensions
{
	[TestFixture]
	public class ControlExtensionsBehavior
	{
		[Test]
		public void Html_ShouldHandleNull()
		{
			Control control = null;

            Assert.That(control.Html(), Is.EqualTo(string.Empty));
		}

		[Test]
		public void Html_ShouldHandleCustomValues()
		{
			Control control = new Label {ID = "foo bar"};

			Assert.That(control.Html(), Is.EqualTo("<span id=\"foo bar\"></span>"));
		}
	}
}
