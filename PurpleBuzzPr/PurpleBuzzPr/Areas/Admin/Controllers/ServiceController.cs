﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzPr.DAL;
using PurpleBuzzPr.Models;

namespace PurpleBuzzPr.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;
        public ServiceController(AppDbContext context)
        { 
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
           IEnumerable<Service> services = await _context.Services.ToListAsync();

           return View(services);
        }

       
        public IActionResult Delete(int Id)
        {
            Service? deletedService = _context.Services.Find(Id);
            if (deletedService == null) { return NotFound(); }
            else { 
                _context.Services.Remove(deletedService); 
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }

            service.CreateAt = DateTime.Now;
            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            Service? service = _context.Services.Find(id);

            if (service is null)
            {
                return NotFound("No such service");
            }

            return View(service);
        }
        [HttpPost]
        public IActionResult Update(Service service)
        {
            Service? updatedService = _context.Services.AsNoTracking().FirstOrDefault(s => s.Id == service.Id);

            if (updatedService is null)
            {
                return NotFound("No such service");
            }
            _context.Services.Update(updatedService);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


    }
}
