using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication.context;
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
        public void AddBook(BookModel book)
        {
            Book new_book = new Book();
            new_book.Title = book.Title;
            new_book.Genre = book.Genre;

            Author book_author = new Author();
            book_author = _authorService.GetAuthorByCondition(b => b.Name == book.AuthorName).FirstOrDefault();

            new_book.AuthorId = book_author.AuthorId;
            repositoryWrapper.BookRepository.Create(new_book);
        }

        public void UpdateBook(BookModel book)
        {
            Book updated_book = new Book();
            updated_book = GetBooksByCondition(b => b.Title == book.Title).First();
            if(book.AuthorName!=null)
            updated_book.AuthorId = (_authorService.GetAuthorByCondition(b => b.Name == book.AuthorName).FirstOrDefault()).AuthorId;
            if (book.Genre != null)
            {
                updated_book.Genre = book.Genre;
            }

            repositoryWrapper.BookRepository.Update(updated_book);
        }

        public List<Book> GetBooksByCondition(Expression<Func<Book, bool>> expression)
        {
            return repositoryWrapper.BookRepository.FindByCondition(expression).ToList();
        }

        public void DeleteBook(BookModel book)
        {
            Book deleted_book = new Book();
            deleted_book = GetBooksByCondition(b => b.Title == book.Title).First();
            repositoryWrapper.BookRepository.Delete(deleted_book);
        }
    }
}
