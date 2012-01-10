using System;
using System.Linq;
using System.Web.Mvc;
using NExtra.Testing;

namespace NExtra.Mvc.Testing
{
    /// <summary>
    /// Test related extension methods for System.Web.Mvc.Controller.
    /// </summary>
    /// <remarks>
    /// Author:     Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:       http://www.dotnextra.com
    /// </remarks>
    public static class ControllerExtensions
    {
        /// <summary>
        /// Use this method to automatically apply model validation,
        /// when calling actions that require it. By default, model
        /// validation is not applied if actions are called outside
        /// the MVC context, e.g. in testing.
        /// </summary>
        public static ActionResult CallWithModelValidation<C, R, T>(this C controller, Func<C, R> action, T model)
            where C : Controller
            where R : ActionResult
            where T : class
        {
            //Perform model validation
            var validator = new MetadataValidator(model);

            //Add each model error to the model state
            foreach (var error in validator.ValidationErrors)
            {
                var defaultKey = "N/A" + new Random().Next();
                var memberName = error.MemberNames.FirstOrDefault() ?? defaultKey;
                controller.ModelState.AddModelError(memberName, error.ErrorMessage);
            }

            //Return the action
            return action(controller);
        }
    }
}
