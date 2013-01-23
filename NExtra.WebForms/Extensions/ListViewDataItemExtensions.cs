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
	public static class ListViewDataItemExtensions
	{
		/// <summary>
		/// Get the css class for a ListViewDataItem instance.
		/// Specify one class to use for odd rows and one for
		/// even rows and the method return the correct class
		/// depending on if the display index is even or odd.
		/// </summary>
		public static string RowCssClass(this ListViewDataItem item, string oddCssClass, string evenCssClass)
		{
			return item.DisplayIndex.IsEven() ? evenCssClass : oddCssClass;
		}
	}
}
