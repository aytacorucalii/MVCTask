using Microsoft.AspNetCore.Mvc;

namespace GameStorePr.MVC.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
