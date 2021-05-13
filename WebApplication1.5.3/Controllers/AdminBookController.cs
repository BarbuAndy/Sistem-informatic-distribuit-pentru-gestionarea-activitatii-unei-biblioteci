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
        private string jsonStringAuthors = null;
        private string jsonStringBooks = null;

        public AdminBookController(BookService BookService, AuthorService AuthorService)
        {
            _bookService = BookService;
            _authorService = AuthorService;
        }

        public ActionResult AddBook()
        {
            if(jsonStringAuthors == null)
                ExtractAuthorName();
            SetAuthorName();
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
                ExtractAuthorName();
            }
            catch
            {
                ViewData["Message"] = "0";
            }
            SetAuthorName();
            return View();

        }


        public ActionResult RemoveBook()
        {
            if (jsonStringBooks == null)
                ExtractBookTitle();
            SetBookTitle();
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
                ExtractBookTitle();
            }
            catch
            {
                ViewData["Message"] = "0";
            }
            SetBookTitle();
            return View();

        }



        public ActionResult EditBook()
        {
            if (jsonStringBooks == null)
                ExtractBookTitle();
            SetBookTitle();
            if (jsonStringAuthors == null)
                ExtractAuthorName();
            SetAuthorName();


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
                ExtractAuthorName();
                ExtractBookTitle();
            }
            catch
            {
                ViewData["Message"] = ViewData["Message"] + "0";
            }
            return View();
        }



        private void ExtractAuthorName()
        {
            List<Author> authors = _authorService.GetAuthorByCondition(b => b.AuthorId != -1);
            List<string> AuthorNames = new List<string>();
            foreach (var author in authors)
            {
                AuthorNames.Add(author.Name);
            }
            jsonStringAuthors = new JavaScriptSerializer().Serialize(AuthorNames); 
        }

        private void SetAuthorName(){
            ViewData["authors"] = jsonStringAuthors;
        }


        private void ExtractBookTitle()
        {
            List<Book> books = _bookService.GetBooksByCondition(b => b.BookId != -1);
            List<string> BookNames = new List<string>();
            foreach (var book in books)
            {
                BookNames.Add(book.Title);
            }
            jsonStringBooks = new JavaScriptSerializer().Serialize(BookNames);
        }

        private void SetBookTitle()
        {
            ViewData["books"] = jsonStringBooks;
        }

    }
}
