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
    /// Author:         Daniel Saidi [daniel.saidi@gmail.com]
    /// Link:           http://www.saidi.se/nextra
    /// </remarks>
    public static class ControllerExtensions
    {
        /// <summary>
        /// Use this method to automatically apply model validation,
        /// when calling actions that require it. By default, model
        /// validation will not apply, which causes model errors to
        /// be ignored by unit tests.
        /// </summary>
        /// <typeparam name="C">System.Web.Mvc.Controller</typeparam>
        /// <typeparam name="R">System.Web.Mvc.ActionResult</typeparam>
        /// <typeparam name="T">class</typeparam>
        /// <param name="controller">The controller to test.</param>
        /// <param name="action">The action to execute.</param>
        /// <param name="model">The model that should be validated.</param>
        /// <returns>The action result.</returns>
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
