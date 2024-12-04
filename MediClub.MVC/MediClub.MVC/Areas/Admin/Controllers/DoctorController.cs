using MediClub.MVC.Areas.Admin.DTOs;
using MediClub.MVC.DAL;
using MediClub.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediClub.MVC.Area.Admin.Controllers;


[Area("Admin")]
public class DoctorController : Controller
{
    private readonly AppDbContext _context;

    public DoctorController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        IEnumerable<Doctor> doctors = await _context.Doctors.ToListAsync();
        return View(doctors);
    }
    public IActionResult Create()
    {
        return View();
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    public IActionResult Create(Doctor doctor)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "Something went wrong");
            return View(doctor);
        }
        //doctor.Username = doctor.Name + doctor.Finkod;
        //_context.Doctors.Add(doctor);

        Doctor newdoctor = new Doctor();
        newdoctor.Name = doctor.Name;
        newdoctor.Surname = doctor.Surname;
        newdoctor.PhoneNumber = doctor.PhoneNumber;
        newdoctor.IsActive = doctor.IsActive;
        newdoctor.Finkod = doctor.Finkod;

        foreach (int hospitalId in doctor.HospitalIds)
        {
            _context.HospitalDoctors.Add(new HospitalDoctor
            {
                HospitalId=hospitalId,
                Doctor = newdoctor,

            });
        }


            _context.SaveChanges();
        return RedirectToAction("Index");
        
    }
    


    public IActionResult Delete(int id)
    {
        Doctor? deleteddoctor = _context.Doctors.Find(id);
        if (deleteddoctor == null)
        {
            return NotFound();
        }
        else
        {
            _context.Doctors.Remove(deleteddoctor);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    #region Update
    public IActionResult Update(int id)
    {
        Doctor? doctor = _context.Doctors.Find(id);
        if (doctor == null)
        {
            return NotFound();
        }
        return View(nameof(Create), doctor);
    }
    [HttpPost]
    public IActionResult Update(Doctor doctor)
    {//AsNoTracking().
        Doctor? updateddoctor = _context.Doctors.FirstOrDefault(x => x.Id == doctor.Id);
        if (doctor == null)
        {
            return NotFound();
        }
        _context.Doctors.Update(doctor);
        _context.SaveChanges();
        return View(Index);
    }
    #endregion

}

