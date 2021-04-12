using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.context;

namespace WebApplication.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private LibraryDb _db;
        private IBookRepository _bookRepository;


        public RepositoryWrapper(LibraryDb db)
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

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
