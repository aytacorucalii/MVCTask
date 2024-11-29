using Microsoft.AspNetCore.Mvc;

namespace EmployeManagement.MVC.Controllers.Home
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
