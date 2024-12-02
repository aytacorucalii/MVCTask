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

        public IActionResult Create(int serviceId)
        {
            var service = appDBContext.Services.Include(s => s.Masters).FirstOrDefault(s => s.Id == serviceId && s.IsActive);
            if (service == null)
            {
                return NotFound();
            }

            ViewBag.Service = service;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            var service = appDBContext.Services.Include(s => s.Masters).FirstOrDefault(s => s.Id == order.ServiceId && s.IsActive);
            if (service == null)
            {
                return NotFound();
            }


            var masters = service.Masters.Where(m => m.IsActive).OrderByDescending(m => m.ExperienceYear).ToList();

            if (masters.Any())
            {
                order.MasterId = masters.First().Id;
            }

            order.CreatedAt = DateTime.Now;
            order.UpdatedAt = DateTime.Now;
            order.IsActive = true;

            appDBContext.Orders.Add(order);
            appDBContext.SaveChanges();

            return RedirectToAction("Index", "Order");
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
