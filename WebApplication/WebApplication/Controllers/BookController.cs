using Microsoft.AspNetCore.Mvc;
using Olympia_Library.Data;
using Olympia_Library.Models.BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication.Models;
using WebApplication.Repositories;
using WebApplication.Services;

namespace Olympia_Library.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly AuthorService _authorService;
        public BookController(BookService bookService, IRepositoryWrapper repositoryWrapper, AuthorService authorService)
        {
            _bookService = bookService;
            _repositoryWrapper = repositoryWrapper;
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAll();

            var bookListing = books.Select(b => new BookListingModel
            {
                Title = b.Title,
                Author = b.Author,
                ImageUrl = b.ImageUrl,
                Genre = b.Genre
            });

            
            var genres = _repositoryWrapper.GenreRepository.FindByCondition(g => g.Name != null);
       

            var model = new BookIndexModel
            {
                BookListing = bookListing,
                GenreList = genres
            };

            return View(model);
        }

        public IActionResult Create()
        {
            var model = new NewBookModel();
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddBook(NewBookModel book)
        {
            
            try
            {
                _bookService.AddBook(book);
                _bookService.Save();
                ModelState.Clear();
                ViewData["Message"] = "1";
            }
            catch
            {
                ViewData["Message"] = "0";
            }

            return RedirectToAction("Index", "Book");

        }


        

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RemoveBook(int id)
        {

            try
            {
                _bookService.DeleteBook(id);
                _bookService.Save();
                ModelState.Clear();
                ViewData["Message"] = "1";
            }
            catch
            {
                ViewData["Message"] = "0";
            }
            return RedirectToAction("Index", "Book");
        }



        

        [ValidateAntiForgeryToken]
        [HttpPost]

        public ActionResult EditBook(NewBookModel book)
        {
            try
            {
                _bookService.UpdateBook(book);
                _bookService.Save();
                ModelState.Clear();
                ViewData["Message"] = ViewData["Message"] + "1";
            }
            catch
            {
                ViewData["Message"] = ViewData["Message"] + "0";
            }
            return RedirectToAction("Detail", "Book", new {book.Id });
        }
    }
}
