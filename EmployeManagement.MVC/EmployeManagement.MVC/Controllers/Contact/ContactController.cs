using Microsoft.AspNetCore.Mvc;

namespace EmployeManagement.MVC.Controllers.Contact
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
