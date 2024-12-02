using Microsoft.AspNetCore.Mvc;
using Uniqlo.MVC.DAL;
using Uniqlo.MVC.Models;

namespace Uniqlo.MVC.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        readonly AppDbContext _context;
        public CategoryController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            Category? Category = _context.Categories.Find(id);

            if (Category is null)
            {
                return NotFound("No such category");
            }

            return View(Category);
        }
        [HttpPost]
        public IActionResult Update(Category Category)
        {
            Category? updatedCategory = _context.Categories.Find(Category.Id);

            if (updatedCategory is null)
            {
                return NotFound("No such category");
            }
            _context.Categories.Update(updatedCategory);
            return RedirectToAction(nameof(Index));
        }
    }
}
