using Microsoft.AspNetCore.Mvc;

namespace MediClub.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
