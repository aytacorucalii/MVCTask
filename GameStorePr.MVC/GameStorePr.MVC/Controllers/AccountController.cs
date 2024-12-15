using GameStorePr.MVC.DAL;
using GameStorePr.MVC.DTOs.UserDTOs;
using GameStorePr.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameStorePr.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _UserManager;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context; _UserManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createUserDto);
            }

            AppUser user = new AppUser
            {
                FirstName = createUserDto.Name,
                LastName = createUserDto.Surname,
                Email = createUserDto.Email,
                UserName = createUserDto.Username
            };

            var result = await _UserManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return View(createUserDto);
            }

            return RedirectToAction(nameof(Index), "Home");
        }

    }
}
