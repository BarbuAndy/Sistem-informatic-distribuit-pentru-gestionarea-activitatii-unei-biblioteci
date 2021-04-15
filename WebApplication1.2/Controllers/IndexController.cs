using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controlers
{
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Books()
        {
            return View();
        }

        public IActionResult BookSpecial()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult testaddbook()  //to be removed
        {
            return View();
        }
    }
}
