using Microsoft.AspNetCore.Mvc;
using Olympia_Library.Models.BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Repositories;
using WebApplication.Services;

namespace Olympia_Library.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        private readonly IRepositoryWrapper _repositoryWrapper;
        public BookController(BookService bookService, IRepositoryWrapper repositoryWrapper)
        {
            _bookService = bookService;
            _repositoryWrapper = repositoryWrapper;
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

            //TODO: if _repositoryWrapper.GenreRepository.Any()
            var genres = _repositoryWrapper.GenreRepository.FindByCondition(g => g.Name != null);

            var orderedBookListing = bookListing.OrderBy(b => b.Genre);
            var model = new BookIndexModel
            {
                BookListing = orderedBookListing,
                GenreList = genres
            };
            return View(model);
        }

    }
}
