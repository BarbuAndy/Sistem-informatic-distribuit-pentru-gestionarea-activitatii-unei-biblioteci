using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Olympia_Library.Data;
using WebApplication.Repositories.Abstractions;
using WebApplication.Repositories.Reps;

namespace WebApplication.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationDbContext _db;
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;
        private IGenreRepository _genreRepository;
        private IBranchRepository _branchRepository;
        private IStockRepository _stockRepository;

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
        public IGenreRepository GenreRepository
        {
            get
            {
                if (_genreRepository == null)
                {
                    _genreRepository = new GenreRepository(_db);
                }
                return _genreRepository;
            }
        }
        public IBranchRepository BranchRepository
        {
            get
            {
                if (_branchRepository == null)
                {
                    _branchRepository = new BranchRepository(_db);
                }
                return _branchRepository;
            }
        }

        public IStockRepository StockRepository
        {
            get
            {
                if (_stockRepository == null)
                {
                    _stockRepository = new StockRepository(_db);
                }
                return _stockRepository;
            }
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
