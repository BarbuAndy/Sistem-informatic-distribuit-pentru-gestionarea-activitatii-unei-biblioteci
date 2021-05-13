using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Olympia_Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Controllers;
using WebApplication.Models;
using WebApplication.Repositories;
using WebApplication.Services;

namespace OlympiaLibraryTests
{
    [TestClass]
    public class BookTests
    {
        AuthorService authorService;

        Mock<IRepositoryWrapper> moqIRepositoryWrapper;

        [TestInitialize]
        public void Initialize()
        {
            moqIRepositoryWrapper = new Mock<IRepositoryWrapper>() { CallBase = true };

            authorService = new AuthorService(moqIRepositoryWrapper.Object, null);
        }



        
        [TestMethod]
        public void AddAuthor_and_GetAuthorByCondition_Test()  

        {       //to search for an author, an author must be added into the database
                //to check if an author has been succesfully added, you must search for it
                //i thought that it would be better to mix the two functionalities together

            List<Author> database = new List<Author>();

            moqIRepositoryWrapper.Setup(x => x.AuthorRepository.Create(It.IsAny<Author>()))
                .Callback<Author>(author => database.Add(author));

            moqIRepositoryWrapper.Setup(x => x.AuthorRepository.FindByCondition(It.IsAny<System.Linq.Expressions.Expression<System.Func<Author, bool>>>()))
                .Returns(database.AsQueryable());


            AuthorModel author = new AuthorModel();
            author.Name = "UnitTestAuthor";
            author.Birth_year = 1970;
            author.Deceased = false;
            authorService.AddAuthor(author);


            Author author_found = authorService.GetAuthorByCondition(b => b.Name == "UnitTestAuthor").FirstOrDefault();
            Assert.AreEqual(author.Name, author_found.Name);
            Assert.AreEqual(author.Birth_year, author_found.Birth_year);
            Assert.AreEqual(author.Deceased, author_found.Deceased);


        }



        [TestMethod]
        public void AddAuthor_and_RemoveAuthor_Test()
            //ads author in database, checks that there is an author added
            //removes the author, checks that the database is empty
        {
            List<Author> database = new List<Author>();

            moqIRepositoryWrapper.Setup(x => x.AuthorRepository.Create(It.IsAny<Author>()))
                .Callback<Author>(author => database.Add(author));

            moqIRepositoryWrapper.Setup(x => x.AuthorRepository.FindByCondition(It.IsAny<System.Linq.Expressions.Expression<System.Func<Author, bool>>>()))
          .Returns(database.AsQueryable());


            moqIRepositoryWrapper.Setup(x => x.AuthorRepository.Delete(It.IsAny<Author>()))
           .Callback<Author>(author => database.Remove(database.First()));

      

            AuthorModel author = new AuthorModel();
            author.Name = "UnitTestAuthor";
            author.Birth_year = 1970;
            author.Deceased = false;
            authorService.AddAuthor(author);
            Assert.IsTrue(database.Count() == 1);


            authorService.DeleteAuthor(author); 

            Assert.IsTrue(database.Count() == 0);

        }

        [TestMethod]//adds author in database, edits authors deceased status, finds author and checks
        //status
        public void AddAuthor_and_EditAuthor_Test()

        {
            List<Author> database = new List<Author>();

            moqIRepositoryWrapper.Setup(x => x.AuthorRepository.Create(It.IsAny<Author>()))
                .Callback<Author>(author => database.Add(author));

            moqIRepositoryWrapper.Setup(x => x.AuthorRepository.FindByCondition(It.IsAny<System.Linq.Expressions.Expression<System.Func<Author, bool>>>()))
          .Returns(database.AsQueryable());


            moqIRepositoryWrapper.Setup(x => x.AuthorRepository.Update(It.IsAny<Author>()));

            AuthorModel author = new AuthorModel();
            author.Name = "UnitTestAuthor";
            author.Birth_year = 1970;
            author.Deceased = false;
            authorService.AddAuthor(author);
            Assert.IsFalse(author.Deceased);

            AuthorModel author_updated = new AuthorModel();
            author_updated.Name = "UnitTestAuthor";
            author_updated.Deceased = true;
            authorService.UpdateAuthor(author_updated);

            Assert.IsTrue(authorService.GetAuthorByCondition(b=>b.Name=="UnitTestAuthor").First().Deceased);

        }


    }
}
