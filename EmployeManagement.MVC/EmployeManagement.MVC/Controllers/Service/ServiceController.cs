using EmployeManagement.MVC.DAL;
using EmployeManagement.MVC.DTOs.ServiceDTOs;
using EmployeManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeManagement.MVC.Controllers;

public class ServiceController : Controller
{
        private readonly AppDBContext _context;

    public ServiceController(AppDBContext context)
    {
        _context = context;
    }
        public IActionResult Create(Service service)
        {
        if (!service.Image.ContentType.Contains("image"))
        {
            ModelState.AddModelError("Image", "Only image format accepted");
            return View(service);
        }

        string path = @"C:\Users\Hp\OneDrive\Desktop\MVCTask\EmployeManagement.MVC\EmployeManagement.MVC\wwwroot\Upload\ServiceImages";
        string fileName = service.Image.FileName; 
        string fullPath = path + fileName; 

       
        using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
        {
            service.Image.CopyTo(fileStream); 
        }

     
        if (!ModelState.IsValid)
        {
            return BadRequest("Something went wrong");
        }

        _context.Services.Add(service);
        _context.SaveChanges(); 
        return RedirectToAction("Index"); 
        }


    [HttpGet]
        public IActionResult Update(int id)
        {
            var service = _context.Services.Include(s => s.Photos).FirstOrDefault(s => s.Id == id);

            if (service == null)
            {
                return RedirectToAction(nameof(Index)); 
            }

            UpdateServiceDTO updateServiceDTO = new UpdateServiceDTO
            {
                Title = service.Title,
                Description = service.Description,
                MainImageUrl = service.MainImageUrl
               
            };

            return View(updateServiceDTO); 
        }

        [HttpPost]
        public IActionResult Update(int id, UpdateServiceDTO updateServiceDTO)
        {
        if (!ModelState.IsValid)
        {
            return View(updateServiceDTO);
        }
            var service = _context.Services.Include(s => s.Photos).FirstOrDefault(s => s.Id == id);

            if (service == null)
            {
                return RedirectToAction(nameof(Index)); 
            }
            service.Title = updateServiceDTO.Title;
            service.Description = updateServiceDTO.Description;
            service.MainImageUrl = updateServiceDTO.MainImage;

            _context.SaveChanges(); 

            return RedirectToAction(nameof(Index)); 
        }
    
}

