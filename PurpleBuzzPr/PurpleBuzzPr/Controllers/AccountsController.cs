using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurpleBuzzPr.DAL;
using PurpleBuzzPr.DTOs.UserDTOs;
using PurpleBuzzPr.Models;

namespace PurpleBuzzPr.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        public AccountsController(UserManager<AppUser> userManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(CreateUserDTO createUserDTO)
        {
            if (!ModelState.IsValid) 
            { 
                return View(createUserDTO);
            }
            AppUser user = new AppUser();
            user.FirstName = createUserDTO.FirstName;
            user.LastName = createUserDTO.LastName;
            user.Email = createUserDTO.Email;
            user.UserName = createUserDTO.Username;

            var result=await _userManager.CreateAsync(user, createUserDTO.Password);
            if(!result.Succeeded)
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }return View(createUserDTO);
            }
            return RedirectToAction(nameof(Index),"Home");
        }
    }
}
