using Microsoft.AspNetCore.Mvc;

namespace Uniqlo.MVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
