using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.context;
using System.Runtime.InteropServices;
using WebApplication.Services;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AdminAuthorController : Controller
    {
        private readonly AuthorService _authorService;

        public AdminAuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        public ActionResult AddAuthor()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddAuthor(AuthorModel Author)
        {

            try
            {
                _authorService.AddAuthor(Author);
                _authorService.Save();
                ModelState.Clear();
                ViewData["Message"] = "1";
            }
            catch
            {
                ViewData["Message"] = "0";
            }
            return View();

        }


        public ActionResult RemoveAuthor()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RemoveAuthor(AuthorModel Author)
        {
            try
            {
                _authorService.DeleteAuthor(Author);
                _authorService.Save();
                ModelState.Clear();
                ViewData["Message"] = "1";
            }
            catch
            {
                ViewData["Message"] = "0";
            }
            return View();

        }



        public ActionResult EditAuthor()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]

        public ActionResult EditAuthor(AuthorModel Author)
        {
            try
            {
                _authorService.UpdateAuthor(Author);
                _authorService.Save();
                ModelState.Clear();
                ViewData["Message"] = ViewData["Message"] + "1";
            }
            catch
            {
                ViewData["Message"] = ViewData["Message"] + "0";
            }
            return View();
        }
    }
}
