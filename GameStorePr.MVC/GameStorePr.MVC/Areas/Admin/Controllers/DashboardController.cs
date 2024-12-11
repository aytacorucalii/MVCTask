using Microsoft.AspNetCore.Mvc;

namespace GameStorePr.MVC.Areas.Admin.Controllers;
[Area("Admin")]

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
