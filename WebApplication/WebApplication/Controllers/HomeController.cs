using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Olympia_Library.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Repositories;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookService _bookService;
        private readonly HomeService _homeService;

        public HomeController(ILogger<HomeController> logger, BookService bookService, HomeService homeService)
        {
            _logger = logger;
            _bookService = bookService;
            _homeService = homeService;
        }

        public IActionResult Index()
        {         
            return View(_homeService.BuildHomeIndexModel());
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
    }
}
