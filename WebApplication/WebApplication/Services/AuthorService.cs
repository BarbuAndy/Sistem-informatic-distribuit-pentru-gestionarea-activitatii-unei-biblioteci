﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Services
{
    public class AuthorService : BaseService
    {
        private readonly ApplicationDbContext _context;

        public AuthorService(IRepositoryWrapper repositoryWrapper, ApplicationDbContext context) : base(repositoryWrapper) {
            _context = context;
        }

        public void AddAuthor(AuthorModel author) 
        {
            Author new_author = new Author();
            new_author.Name = author.Name;
            new_author.Birth_year = author.Birth_year;
            new_author.Deceased = author.Deceased;
            repositoryWrapper.AuthorRepository.Create(new_author);
        }

        public void UpdateAuthor(AuthorModel author)
        {

            Author updated_author = new Author();
            updated_author = GetAuthorByCondition(b => b.Name == author.Name).First();
            if(author.Birth_year!=0)
            {
                updated_author.Birth_year = author.Birth_year;
            }
            if(updated_author.Deceased == false)
            updated_author.Deceased = author.Deceased;

            repositoryWrapper.AuthorRepository.Update(updated_author);
        }

        public async Task DeleteAuthor(AuthorModel author)
        {
            repositoryWrapper.AuthorRepository.Delete(GetAuthorByCondition(b => b.Name == author.Name).First());
            await _context.SaveChangesAsync();
        }

        public List<Author> GetAuthorByCondition(Expression<Func<Author, bool>> expression)
        {
            return repositoryWrapper.AuthorRepository.FindByCondition(expression).ToList();
        }

    }


}

