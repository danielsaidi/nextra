using System.Web.Mvc;
using NExtra.Demo.Models;
using NExtra.Mvc.ActionFilters;
using NExtra.Mvc.Extensions;

namespace NExtra.Demo.Controllers
{
    [HandleError]
    public class DemoController : ControllerBase
    {
        [OutputModel("value", "json")]
        public ActionResult Index(string id = "index")
        {
            var model = new DemoModel { ActionName = this.Action(), ControllerName = this.Name() };

            ViewData["Title"] = id == "index" ? "Demos" : id;

            return View(id, model);
        }
    }
}
