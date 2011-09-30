using System.Web.Mvc;
using NExtra.Demo.Models;

namespace NExtra.Demo.Controllers
{
    public class ControllerBase : Controller
    {
        public ControllerBase()
        {
            ViewData["Title"] = ".NET Extensions - Demo Application";
            ViewData["DemoAssemblies"] = new AssemblyRepository().DemoAssemblies;   //Cannot be serialized, so added here instead of in the model
            ViewData["MenuItems"] = new AssemblyRepository().DemoTypes;             //Used in the master page, so added here instead of in the model
        }
    }
}
