using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Olympia_Library.Data;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Services
{
    public class BookService : BaseService
    {

        private readonly AuthorService _authorService;
        public BookService(IRepositoryWrapper repositoryWrapper, AuthorService authorService) : base(repositoryWrapper) {
            _authorService = authorService;              
        }

        public IEnumerable<Book> GetAll()
        {
            return repositoryWrapper.BookRepository.FindByCondition(b => b.BookId != 0);
        }

        public void AddBook(NewBookModel book)
        {
            Book new_book = new Book
            {
                Title = book.Title,
                GenreId = repositoryWrapper.GenreRepository.FindByCondition(g => g.Name == book.GenreName).FirstOrDefault().Id,               
            };

            var book_author = _authorService.GetAuthorByCondition(b => b.Name == book.AuthorName).FirstOrDefault().AuthorId;

            new_book.AuthorId = book_author;
            repositoryWrapper.BookRepository.Create(new_book);
        }

        public void UpdateBook(NewBookModel book)
        {
            Book updated_book = new Book();
            updated_book = GetBooksByCondition(b => b.Title == book.Title).First();

            if(book.AuthorName!=null)
                updated_book.AuthorId = (_authorService
                    .GetAuthorByCondition(b => b.Name == book.AuthorName)
                    .FirstOrDefault()).AuthorId;

            if (book.GenreName != null)
                updated_book.GenreId = repositoryWrapper.GenreRepository
                    .FindByCondition(g => g.Name == book.GenreName)
                    .FirstOrDefault().Id;

            if (book.GenreId != 0)
            {
                updated_book.GenreId = book.GenreId;
            }

            repositoryWrapper.BookRepository.Update(updated_book);
        }

        public List<Book> GetBooksByCondition(Expression<Func<Book, bool>> expression)
        {
            return repositoryWrapper.BookRepository.FindByCondition(expression).ToList();
        }

        public void DeleteBook(NewBookModel book)
        {
         
            var deleted_book = GetBooksByCondition(b => b.Title == book.Title).First();
            if(deleted_book != null)
            {
                repositoryWrapper.BookRepository.Delete(deleted_book);                
            }         
        }

        public List<string> ExtractBookTitles()
        {
            List<Book> books = GetBooksByCondition(b => b.BookId != -1);
            List<string> BookNames = new List<string>();
            foreach (var book in books)
            {
                BookNames.Add(book.Title);
            }
            return BookNames;
        }

        public NewBookModel BuildBookDetailModel(int id)
        {
            var book = repositoryWrapper.BookRepository.FindByCondition(b => b.BookId == id).FirstOrDefault();
            var bookModel = new NewBookModel
            {
                Title = book.Title,
                AuthorName = _authorService.GetAuthorByCondition(a => a.AuthorId == book.AuthorId).FirstOrDefault().Name,
                GenreId = book.GenreId,
                GenreName = repositoryWrapper.GenreRepository.FindByCondition(g => g.Id == book.GenreId).FirstOrDefault().Name,
                Id = id,
                ImageUrl = book.ImageUrl
            };
            return bookModel;
        }

        public string GetGenreName(int bookId)
        {
            var genreId = repositoryWrapper.BookRepository.FindByCondition(b => b.BookId == bookId).FirstOrDefault().GenreId;
            var genreName = repositoryWrapper.GenreRepository.FindByCondition(g => g.Id == genreId).FirstOrDefault().Name;

            return genreName;
        }

        public IEnumerable<Book> GetLatestAdditions(int number)
        {
            return GetAll().OrderByDescending(b => b.BookId).Take(number);     
        }

        
    }
}
