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
    public class AuthorService : BaseService
    {
        public AuthorService(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper) { }

        public void AddAuthor(AuthorModel author) //todo
        {
            Author new_author = new Author();
            new_author.Name = author.Name;
            repositoryWrapper.AuthorRepository.Create(new_author);
        }

        public void UpdateAuthor(Author author)
        {
            repositoryWrapper.AuthorRepository.Update(author);
        }

        public void DeleteAuthor(Author author)
        {
            repositoryWrapper.AuthorRepository.Delete(author);
        }

        public List<Author> GetAuthorByCondition(Expression<Func<Author, bool>> expression)
        {
            return repositoryWrapper.AuthorRepository.FindByCondition(expression).ToList();
        }

    }


}

