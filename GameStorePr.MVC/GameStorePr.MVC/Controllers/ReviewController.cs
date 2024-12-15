using GameStorePr.MVC.DAL;
using GameStorePr.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStorePr.MVC.Controllers
{
    public class ReviewController : Controller
    {

        private readonly AppDbContext _context;

        public ReviewController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                
                var review = new Review
                {
                    Message = message,
                    CreatedAt = DateTime.Now 
                };

                _context.Reviews.Add(review);
                _context.SaveChanges();

              
                return RedirectToAction("Success");
            }
            ModelState.AddModelError("", "Message cannot be empty.");
            return RedirectToAction("Home");
        }
    }
}
