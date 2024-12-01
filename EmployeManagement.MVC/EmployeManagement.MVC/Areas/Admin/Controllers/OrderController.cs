using EmployeManagement.MVC.DAL;
using EmployeManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeManagement.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly AppDBContext appDBContext;
        public OrderController(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public async Task< IActionResult> Index()
        {
            IEnumerable<Order>orders = await appDBContext.Orders.ToListAsync();
            return View(orders);
        }
        public IActionResult Delete(int Id)
        {
            Order? deletedOrder = appDBContext.Orders.Find(Id);
            if (deletedOrder == null) { return NotFound(); }
            else
            {
                appDBContext.Orders.Remove(deletedOrder);
                appDBContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order Order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }

            appDBContext.Orders.Add(Order);
            appDBContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            Order? Order = appDBContext.Orders.Find(id);

            if (Order is null)
            {
                return NotFound("No such Order");
            }

            return View(Order);
        }
        [HttpPost]
        public IActionResult Update(Order Order)
        {
            Order? updatedOrder = appDBContext.Orders.AsNoTracking().FirstOrDefault(s => s.Id == Order.Id);

            if (updatedOrder is null)
            {
                return NotFound("No such Order");
            }
            appDBContext.Orders.Update(updatedOrder);

            appDBContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
