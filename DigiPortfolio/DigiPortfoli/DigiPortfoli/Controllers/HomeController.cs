﻿using DigiPortfoli.Models;
using DigiPortfoli.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace DigiPortfoli.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBConfiguration _context;
        HomeManager _homeManager = new HomeManager();

        public HomeController(ILogger<HomeController> logger, DBConfiguration context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Resume()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        //-----------------------Funcationalities for Home Page'-----------------------------
        [HttpGet]
        public async Task<string> GetHomePageData()
        {
            return JsonSerializer.Serialize(await _homeManager.GetPersonalInfoList(_context));
        }
        
    }
}