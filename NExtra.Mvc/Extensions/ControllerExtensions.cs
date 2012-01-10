using System.Web.Mvc;

namespace NExtra.Mvc.Extensions
{
	/// <summary>
	/// Extension methods for System.Web.Mvc.Controller.
	/// </summary>
	/// <remarks>
	/// Author:     Daniel Saidi [daniel.saidi@gmail.com]
	/// Link:       http://www.dotnextra.com
	/// </remarks>
	public static class ControllerExtensions
    {
        /// <summary>
        /// Get the name of the current action for a certain controller.
        /// </summary>
        public static string Action(this Controller controller)
        {
            return controller.ValueProvider.GetValue("action").RawValue.ToString();
        }

        /// <summary>
        /// Get the name of a certain controller.
        /// </summary>
        public static string Name(this Controller controller)
        {
            return controller.ValueProvider.GetValue("controller").RawValue.ToString();
        }
	}
}
