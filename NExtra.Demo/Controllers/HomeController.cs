using System.Web.Mvc;

namespace NExtra.Demo.Controllers
{
    [HandleError]
    public class HomeController : ControllerBase
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
