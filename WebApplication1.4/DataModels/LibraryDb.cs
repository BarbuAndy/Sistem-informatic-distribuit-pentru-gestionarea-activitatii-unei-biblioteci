using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.context
{
    public class LibraryDb : DbContext
    {
        public LibraryDb(DbContextOptions options) : base(options) { }

        public DbSet<Library> Libraries { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<WebApplication.Models.BookModel> BookModel { get; set; }


      
    }
}
