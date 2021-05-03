using Microsoft.AspNetCore.Mvc;
using WebApplication.Services;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AdminBookController : Controller
    {
        private readonly BookService _bookService;

        public AdminBookController(BookService BookService)
        {
            _bookService = BookService;
        }

        public ActionResult AddBook() 
        {
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
