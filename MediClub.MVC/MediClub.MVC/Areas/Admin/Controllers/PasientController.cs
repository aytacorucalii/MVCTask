using Microsoft.AspNetCore.Mvc;

namespace MediClub.MVC.Area.Admin.Controllers
{
    public class PasientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
