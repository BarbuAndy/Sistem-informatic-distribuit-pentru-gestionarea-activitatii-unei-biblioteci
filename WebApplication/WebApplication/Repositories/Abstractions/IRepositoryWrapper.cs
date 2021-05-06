using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Repositories.Abstractions;
using WebApplication.Repositories.Reps;

namespace WebApplication.Repositories
{
    public interface IRepositoryWrapper
    {
        IBookRepository BookRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IGenreRepository GenreRepository { get; }
        IBranchRepository BranchRepository { get; }
        IStockRepository StockRepository { get; }
        void Save();
    }
}
