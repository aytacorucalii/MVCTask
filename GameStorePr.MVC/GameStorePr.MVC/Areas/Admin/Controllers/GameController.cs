using Microsoft.AspNetCore.Mvc;

namespace GameStorePr.MVC.Areas.Admin.Controllers;
[Area("Admin")]
public class GameController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

}
