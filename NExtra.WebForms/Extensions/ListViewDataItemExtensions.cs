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
		/// </summary>
		/// <param name="item">The item instance.</param>
		/// <param name="oddCssClass">The class to apply to odd rows; default "odd".</param>
		/// <param name="evenCssClass">The class to apply to even rows; default "even".</param>
		/// <returns>A string with the correct css class applied.</returns>
		public static string RowCssClass(this ListViewDataItem item, string oddCssClass = "odd", string evenCssClass = "even")
		{
			return item.DisplayIndex.IsEven() ? evenCssClass : oddCssClass;
		}
	}
}
