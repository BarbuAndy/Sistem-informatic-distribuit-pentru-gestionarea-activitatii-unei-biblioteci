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

namespace WebApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly BookService _bookService;

        public AdminController(BookService BookService)
        {
            _bookService = BookService;
        }

        public ActionResult AddBook() //Book Book
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddBook(Book Book) 
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
        public ActionResult RemoveBook(Book Book)
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

        public ActionResult EditBook(Book Book)
        {

            try
            {
                Book updated_book = _bookService.GetBooksByCondition(b => b.BookId == Book.BookId).FirstOrDefault();  //_db.Books.Find(Book.BookId);
                if (Book.Title != null)
                    updated_book.Title = Book.Title;
                if (Book.AuthorId != null)
                    updated_book.AuthorId = Book.AuthorId;
                // ViewData["Message"] = ViewData["Message"]+" "+ updated_book.BookId +" " + updated_book.Title + " " + updated_book.AuthorId;


                _bookService.UpdateBook(updated_book);
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
