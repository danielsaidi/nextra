using System.Web.UI.WebControls;
using NExtra.Extensions;

namespace NExtra.WebForms.Extensions
{
	/// <summary>
	/// Extension methods for System.Web.UI.WebControls.ListViewDataItem.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
	public static class ListViewDataItem_Extensions
	{
		public static string RowCssClass(this ListViewDataItem item, string oddCssClass, string evenCssClass)
		{
			return item.DisplayIndex.IsEven() ? evenCssClass : oddCssClass;
		}
	}
}
