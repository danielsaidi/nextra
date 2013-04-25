using System.Web.Mvc;

namespace NExtra.Mvc.Extensions
{
	/// <summary>
	/// Extension methods for System.Web.Mvc.Controller.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://danielsaidi.github.com/nextra
	/// </remarks>
	public static class Controller_Extensions
    {
        public static string Action(this Controller controller)
        {
            return controller.ValueProvider.GetValue("action").RawValue.ToString();
        }

        public static string Name(this Controller controller)
        {
            return controller.ValueProvider.GetValue("controller").RawValue.ToString();
        }
	}
}
