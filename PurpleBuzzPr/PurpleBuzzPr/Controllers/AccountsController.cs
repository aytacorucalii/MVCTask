using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PurpleBuzzPr.DAL;
using PurpleBuzzPr.DTOs.UserDTOs;
using PurpleBuzzPr.Models;

namespace PurpleBuzzPr.Controllers;

public class AccountsController : Controller
{
    private readonly AppDbContext _appDbContext;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;


    public AccountsController(UserManager<AppUser> userManager, AppDbContext appDbContext, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _appDbContext = appDbContext;
        _signInManager = signInManager;
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

        var result = await _userManager.CreateAsync(user, createUserDTO.Password);
        if (!result.Succeeded)
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);
            }
            return View(createUserDTO);
        }
        await _signInManager.SignInAsync(user, isPersistent: true);



        return RedirectToAction(nameof(Index), "Home");
    }
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUserDTOs loginUserDto)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        AppUser? user = await _userManager.FindByNameAsync(loginUserDto.EmailOrUsername);
        if (user == null)
        {
            user = await _userManager.FindByNameAsync(loginUserDto.EmailOrUsername);
        }
        if (user == null) 
        {
            ModelState.AddModelError(string.Empty, "Username or password is wrong");
            return View();
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginUserDto.Password, loginUserDto.IsPersistent = true);
        if (!result.Succeeded)
        {
            ModelState.AddModelError(string.Empty, "Username or password is wrong");
            return View();
        }

        return RedirectToAction(nameof(Index), "Home");

    }
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(Index), "home");
    }
}