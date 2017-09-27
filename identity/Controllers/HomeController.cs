using identity.Models;
using Microsoft.AspNetCore.Mvc;

namespace identity.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var name = this.User?.Identity.Name ?? "<Unknown>";

            var model = new HomePageModel(name);
            
            return View(model);
        }
    }
}