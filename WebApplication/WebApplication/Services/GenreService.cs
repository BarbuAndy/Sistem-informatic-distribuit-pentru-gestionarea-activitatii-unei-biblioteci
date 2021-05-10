using Olympia_Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Services
{
    public class GenreService : BaseService
    {
        public GenreService(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper) { }

        public List<Genre> FindGenreByCondition(Expression<Func<Genre, bool>> expression)
        {
            return repositoryWrapper.GenreRepository.FindByCondition(expression).ToList();
        }

        public List<string> ExtractGenres()
        {
            List<Genre> genres = FindGenreByCondition(b => b.Id != -1);
            List<string> genres_names = new List<string>();
            foreach (var genre in genres)
            {
                genres_names.Add(genre.Name);
            }
            return genres_names;
        }
    }

}