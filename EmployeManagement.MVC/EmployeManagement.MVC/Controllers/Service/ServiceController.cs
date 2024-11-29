using Microsoft.AspNetCore.Mvc;

namespace EmployeManagement.MVC.Controllers.Service
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
