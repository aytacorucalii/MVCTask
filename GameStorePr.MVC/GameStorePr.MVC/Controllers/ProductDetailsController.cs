using Microsoft.AspNetCore.Mvc;

namespace GameStorePr.MVC.Controllers;

public class ProductDetailsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
