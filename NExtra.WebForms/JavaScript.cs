using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NExtra.WebForms
{
	/// <summary>
	/// The JavaScript class defines certain scripts that can be used
	/// server-side. The Scripts are properly registered and can thus 
	/// be used in asynchronous postbacks.
	/// 
	/// The class randomizes the script IDs, which means that scripts
	/// can be added several times without overwriting eachother.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.saidi.se/nextra
	/// </remarks>
	public static class JavaScript
	{
		/// <summary>
		/// Get the currently executing page, if any.
		/// </summary>
		/// <returns>The currently executing page.</returns>
		private static Page CurrentPage
		{
			get
			{
				return (Page)HttpContext.Current.Handler;
			}
		}


		/// <summary>
		/// Alert a message in an alert box.
		/// </summary>
		/// <param name="message">The message to alert.</param>
		public static void Alert(string message)
		{
			CurrentPage.ClientScript.RegisterStartupScript(typeof(Literal), "alert_" + (new Random()).Next(100000), "alert('" + message.Replace("'", "\'") + "');", true);
		}

		/// <summary>
		/// Redirect the client to a certain page.
		/// </summary>
		/// <param name="url">The url to redirect the client to.</param>
		public static void Redirect(String url)
		{
			CurrentPage.ClientScript.RegisterStartupScript(typeof(Literal), "redirect_" + (new Random()).Next(100000), "location.href = '" + CurrentPage.ResolveClientUrl(url) + "';", true);
		}
	}
}
