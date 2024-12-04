using MediClub.MVC.DAL;
using MediClub.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MediClub.MVC.Controllers
{
	public class AccountController : Controller
	{
		private readonly AppDbContext appDbContext;
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AccountController(AppDbContext appDbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			this.appDbContext = appDbContext;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async Task<IActionResult> CreateAdmin()
		{

			AppUser user = new AppUser
			{
				UserName = "SuperAdmin",
				Email = "admin@purplebuzz.com",
				FirstName = "Nermin",
				LastName = "Shivakhan"
			};

			var result = await _userManager.CreateAsync(user, "Admin123!");
			if (!result.Succeeded)
			{
				return Json(result);
			}

			//await _userManager.AddToRoleAsync(user, RoleEnums.Admin.ToString());

			return Json("Success");
		}
	}

}
