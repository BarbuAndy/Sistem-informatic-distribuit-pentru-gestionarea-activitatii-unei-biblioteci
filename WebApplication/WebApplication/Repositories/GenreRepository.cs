using Olympia_Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;

namespace WebApplication.Repositories
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
