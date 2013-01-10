using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NExtra.WebForms
{
	/// <summary>
	/// This class defines certain scripts that can be used server-
	/// side. The scripts are properly registered, and can thus be
	/// used in asynchronous postbacks as well.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// The class randomizes script IDs, which means that a script
    /// can be added several times without overwriting itself.
	/// </remarks>
	public static class JavaScript
	{
		/// <summary>
		/// Get the currently executing page, if any.
		/// </summary>
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
		public static void Alert(string message)
		{
			CurrentPage.ClientScript.RegisterStartupScript(typeof(Literal), "alert_" + (new Random()).Next(100000), "alert('" + message.Replace("'", "\'") + "');", true);
		}

		/// <summary>
		/// Redirect the client to a certain page.
		/// </summary>
		public static void Redirect(String url)
		{
			CurrentPage.ClientScript.RegisterStartupScript(typeof(Literal), "redirect_" + (new Random()).Next(100000), "location.href = '" + CurrentPage.ResolveClientUrl(url) + "';", true);
		}
	}
}
