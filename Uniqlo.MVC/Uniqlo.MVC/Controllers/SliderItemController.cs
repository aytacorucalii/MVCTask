using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uniqlo.MVC.DAL;
using Uniqlo.MVC.Models;

namespace Uniqlo.MVC.Controllers
{
    public class SliderItemController : Controller
    {
        readonly AppDbContext _context;
        public SliderItemController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IActionResult Index()
        {
           
            IEnumerable<SliderItem> sliderItems = _context.SliderItems.ToList();
            return View();
        }
    }
}
