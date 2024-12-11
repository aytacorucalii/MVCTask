using Microsoft.AspNetCore.Mvc;

namespace GameStorePr.MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
