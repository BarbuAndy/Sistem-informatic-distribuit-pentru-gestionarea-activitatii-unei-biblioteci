﻿using Olympia_Library.Models.BookModel;
using Olympia_Library.Models.HomeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Repositories;
using WebApplication.Services;

namespace Olympia_Library.Services
{
    public class HomeService : BaseService
    {
        private readonly BookService _bookService;

        public HomeService(IRepositoryWrapper repositoryWrapper, BookService bookService) : base(repositoryWrapper)
        {
            _bookService = bookService;
        }

        public HomeIndexModel BuildHomeIndexModel()
        {
            var books = _bookService.GetAll();

            var bookListing = books.Select(b => new BookListingModel
            {
                Title = b.Title,
                AuthorId = b.AuthorId,
                ImageUrl = b.ImageUrl,
                GenreId = b.GenreId
            });

            var genres = repositoryWrapper.GenreRepository.FindByCondition(g => string.IsNullOrEmpty(g.Name));
            return new HomeIndexModel {
                BookListing = bookListing,
                Genres = genres
            };

        }

    }
}
