using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;

namespace WebApplication.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _db;
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;


        public RepositoryWrapper(ApplicationDbContext db)
        {
            _db = db;
        }

        public IBookRepository BookRepository
        {
            get
            {
                if (_bookRepository == null)
                {
                    _bookRepository = new BookRepository(_db);
                }
                return _bookRepository;
            }
        }

        public IAuthorRepository AuthorRepository
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(_db);
                }
                return _authorRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
