using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication.Services;
using WebApplication.Models;
using javax.jws;
using WebApplication.context;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nancy.Json;

namespace WebApplication.Controllers
{
    public class AdminBookController : Controller
    {
        private readonly BookService _bookService;
        private readonly AuthorService _authorService;

        public AdminBookController(BookService BookService,AuthorService AuthorService)
        {
            _bookService = BookService;
            _authorService = AuthorService;
        }

        public ActionResult AddBook()
        {
            
            List<Author> authors = _authorService.GetAuthorByCondition(b => b.AuthorId > 0);
            List<string> AuthorNames = new List<string>();
            foreach (var author in authors)
            {
                AuthorNames.Add(author.Name);
            }
            var jsonString = new JavaScriptSerializer().Serialize(AuthorNames);
            System.IO.File.WriteAllText(@"D:\test.json", jsonString);
            ViewData["authors"] = jsonString;
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddBook(BookModel Book)
        {

            try
            {
                _bookService.AddBook(Book);
                _bookService.Save();
                ModelState.Clear();
                ViewData["Message"] = "1";
            }
            catch
            {
                ViewData["Message"] = "0";
            }
            return View();

        }


        public ActionResult RemoveBook()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RemoveBook(BookModel Book)
        {
            try
            {
                _bookService.DeleteBook(Book);
                _bookService.Save();
                ModelState.Clear();
                ViewData["Message"] = "1";
            }
            catch
            {
                ViewData["Message"] = "0";
            }
            return View();

        }



        public ActionResult EditBook()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]

        public ActionResult EditBook(BookModel Book)
        {
            try
            {
                _bookService.UpdateBook(Book);
                _bookService.Save();
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
