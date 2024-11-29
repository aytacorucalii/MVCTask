using Microsoft.AspNetCore.Mvc;

namespace MediClub.MVC.Controllers
{
	public class DoctosController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
