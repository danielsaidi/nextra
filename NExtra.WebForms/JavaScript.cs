using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NExtra.WebForms
{
	/// <summary>
	/// This class contains javascripts that can be used
	/// server-side. The scripts are properly registered,
	/// and can be used in asynchronous requests as well.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://danielsaidi.github.com/nextra
    /// 
    /// The class randomizes script IDs, which means that
    /// scripts can be added several times, without being
    /// overwritten by the previous script.
	/// </remarks>
	public static class JavaScript
	{
		private static Page CurrentPage
		{
			get { return (Page)HttpContext.Current.Handler; }
		}


		public static void Alert(string message)
		{
			CurrentPage.ClientScript.RegisterStartupScript(typeof(Literal), "alert_" + (new Random()).Next(100000), "alert('" + message.Replace("'", "\'") + "');", true);
		}

		public static void Redirect(String url)
		{
			CurrentPage.ClientScript.RegisterStartupScript(typeof(Literal), "redirect_" + (new Random()).Next(100000), "location.href = '" + CurrentPage.ResolveClientUrl(url) + "';", true);
		}
	}
}
