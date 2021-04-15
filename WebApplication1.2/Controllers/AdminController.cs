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

namespace WebApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly LibraryDb _db;

        public AdminController(LibraryDb db)
        {
            _db = db;
        }

        public ActionResult AddBook() //Book Book
        {
            return View("../index/addbook");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddBook(Book Book) 
        {
            
            try
            {
                _db.Add(Book);
                _db.SaveChanges();
                ModelState.Clear();
                ViewData["Message"] = "1";
            }
            catch
            {
                ViewData["Message"] = "0";
            }
            return View("../index/addbook");
            
        }


        public ActionResult RemoveBook()
        {
            return View("../index/removebook");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RemoveBook(Book Book)
        {

            try
            {
                _db.Remove(Book);
                _db.SaveChanges();
                ModelState.Clear();
                ViewData["Message"] = "1";
            }
            catch
            {
                ViewData["Message"] = "0";
            }
            return View("../index/removebook");

        }



        public ActionResult EditBook()
        {
            return View("../index/editbook");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]

        public ActionResult EditBook(Book Book)
        {

            try
            {
                Book updated_book = _db.Books.Find(Book.BookId);
                if (Book.Title != null)
                    updated_book.Title = Book.Title;
                if (Book.AuthorId != null)
                    updated_book.AuthorId = Book.AuthorId;
                // ViewData["Message"] = ViewData["Message"]+" "+ updated_book.BookId +" " + updated_book.Title + " " + updated_book.AuthorId;


                _db.Update(updated_book);
                _db.SaveChanges();
                ModelState.Clear();
               ViewData["Message"] = ViewData["Message"] + "1";
            }
            catch
            {
                ViewData["Message"] = ViewData["Message"] + "0";
            }
            return View("../index/editbook"); 

        }

    }
}
