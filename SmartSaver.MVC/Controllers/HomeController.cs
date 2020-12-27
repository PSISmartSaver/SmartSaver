﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SmartSaver.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(DashboardController.Index), nameof(DashboardController).Replace("Controller", ""));
            }

            return View();
        }
    }
}
