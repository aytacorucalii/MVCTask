﻿using Microsoft.AspNetCore.Mvc;

namespace MediClub.MVC.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
