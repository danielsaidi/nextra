using System.Web.UI.WebControls;
using NExtra.WebForms.Extensions;
using NUnit.Framework;

namespace NExtra.WebForms.Tests.Extensions
{
	[TestFixture]
	public class ListViewDataItem_ExtensionsBehavior
	{
		[Test]
		public void RowCssClass_ShouldReturnCorrectDefaultValues()
		{
			Assert.That(new ListViewDataItem(0, 1).RowCssClass("odd", "even"), Is.EqualTo("odd"));
			Assert.That(new ListViewDataItem(0, 2).RowCssClass("odd", "even"), Is.EqualTo("even"));
			Assert.That(new ListViewDataItem(0, 99).RowCssClass("odd", "even"), Is.EqualTo("odd"));
			Assert.That(new ListViewDataItem(0, 100).RowCssClass("odd", "even"), Is.EqualTo("even"));
		}

		[Test]
		public void RowCssClass_ShouldReturnCorrectCustomValues()
		{
			Assert.That(new ListViewDataItem(0, 1).RowCssClass("", "alternating"), Is.EqualTo(""));
			Assert.That(new ListViewDataItem(0, 2).RowCssClass("", "alternating"), Is.EqualTo("alternating"));
			Assert.That(new ListViewDataItem(0, 99).RowCssClass("", "alternating"), Is.EqualTo(""));
			Assert.That(new ListViewDataItem(0, 100).RowCssClass("", "alternating"), Is.EqualTo("alternating"));
		}
	}
}
