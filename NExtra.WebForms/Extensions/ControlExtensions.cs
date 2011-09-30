using System.IO;
using System.Web.UI;

namespace NExtra.WebForms.Extensions
{
	/// <summary>
	/// Extension methods for System.Web.UI.Control.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public static class ControlExtensions
	{
		/// <summary>
		/// Retrieve the HTML code for a certain control.
		/// </summary>
		/// <param name="control">The control of interest.</param>
		/// <returns>The HTML for the control.</returns>
		public static string Html(this Control control)
		{
			if (control == null)
				return "";

			var stringWriter = new StringWriter();
			var htmlTextWriter = new HtmlTextWriter(stringWriter);
            
			control.DataBind();
			control.RenderControl(htmlTextWriter);

			return stringWriter.GetStringBuilder().ToString();
		}
		
	}
}
