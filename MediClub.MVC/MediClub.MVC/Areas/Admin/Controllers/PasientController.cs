using Microsoft.AspNetCore.Mvc;

namespace MediClub.MVC.Area.Admin.Controllers
{
    [Area("Admin")]
    public class PasientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
