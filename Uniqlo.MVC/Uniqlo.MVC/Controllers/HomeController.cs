using Microsoft.AspNetCore.Mvc;
using Uniqlo.MVC.DAL;
using Uniqlo.MVC.Models;

namespace Uniqlo.MVC.Controllers
{
    public class HomeController : Controller
    {
        readonly AppDbContext _context;
        public HomeController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<SliderItem> sliderItems = _context.SliderItems.ToList();
            return View(sliderItems);
        }
    }
}
