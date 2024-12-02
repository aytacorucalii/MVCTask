using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uniqlo.MVC.DAL;
using Uniqlo.MVC.Models;

namespace Uniqlo.MVC.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;

        public ProductController(AppDbContext appDbContext)
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
        public IActionResult Create(Product Product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }

            _context.Products.Add(Product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            Product? Product = _context.Products.Find(id);

            if (Product is null)
            {
                return NotFound("No such Product");
            }

            return View(Product);
        }
        [HttpPost]
        public IActionResult Update(Product Product)
        {
            Product? updatedProduct = _context.Products.Find(Product.Id);

            if (updatedProduct is null)
            {
                return NotFound("No such Product");
            }
            _context.Products.Update(updatedProduct);
            return RedirectToAction(nameof(Index));
        }

    }
}
