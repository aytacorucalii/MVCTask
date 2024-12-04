using MediClub.MVC.DAL;
using MediClub.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MediClub.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HospitalController : Controller
	{
		private readonly AppDbContext appDbContext;
		public IActionResult Index()
		{
			return View();
		}
	
		public IActionResult Create()
		{
			ViewBag.Doctors = new SelectList(appDbContext.Doctors.ToList(), "Id", "Name");
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Hospital hospital, List<int> doctorIds)
		{
			if (ModelState.IsValid)
			{
				appDbContext.Hospitals.Add(hospital);
				await appDbContext.SaveChangesAsync();

				foreach (var doctorId in doctorIds)
				{
					var hospitalDoctor = new HospitalDoctor
					{
						HospitalId = hospital.Id,
						DoctorId = doctorId
					};
					appDbContext.HospitalDoctors.Add(hospitalDoctor);
				}

				await appDbContext.SaveChangesAsync();
				return RedirectToAction("Index");
			}

			ViewBag.Doctors = new SelectList(appDbContext.Doctors.ToList(), "Id", "Name");
			return View(hospital);
		}
		
		public async Task<IActionResult> Detail(int id)
		{
			var hospital = await appDbContext.Hospitals
				.Include(h => h.HospitalDoctors)
				.ThenInclude(hd => hd.Doctor)
				.FirstOrDefaultAsync(h => h.Id == id);

			if (hospital == null)
			{
				return NotFound();
			}

			return View(hospital);
		}

	}
}
