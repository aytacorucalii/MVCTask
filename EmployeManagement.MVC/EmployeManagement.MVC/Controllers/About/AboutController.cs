using Microsoft.AspNetCore.Mvc;

namespace EmployeManagement.MVC.Controllers.About
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
