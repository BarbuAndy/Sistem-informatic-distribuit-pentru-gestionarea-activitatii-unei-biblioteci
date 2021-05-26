﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Olympia_Library.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebApplication.Repositories;
using WebApplication.Services;

namespace OlympiaLibraryTests
{
    [TestClass]
    public class UITests 
    {
        Mock<IRepositoryWrapper> moqIRepositoryWrapper;
        private IWebDriver driver;
        private UserManager<ApplicationUser> _userManager;
        
        private  IHostEnvironment _hostEnvironment;



        public UITests()
        {
        }

        [TestInitialize]
        public void Initialize()
        {
            moqIRepositoryWrapper = new Mock<IRepositoryWrapper>() { CallBase = true };
            
            driver = new ChromeDriver();           
            
        }
        //ATENTIE!! Pentru acest test este nevoie ca cel ce il apeleaza sa nu fie logat in avans pe site, pentru 
        //ca metoda LoginAsAdmin() sa functioneze
        [TestMethod]
        public void Test_Add_Book_Edit_Then_Delete_Book()
        {

            LoginAsAdmin();

            //ADDING THE BOOK

            driver.Navigate().GoToUrl("https://localhost:44365/");
            var adminPrivilegesLink = driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul[2]/li[6]/a"));
            
            adminPrivilegesLink.Click();
            //click add book
            driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/div[1]/input")).Click();
            var bookTitleTextBox = driver.FindElement(By.XPath("/html/body/div/main/div/div/div/form/div[1]/input"));
            var bookAuthorTextBox = driver.FindElement(By.XPath("/html/body/div/main/div/div/div/form/div[2]/input"));
            var bookGenreTextBox = driver.FindElement(By.XPath("/html/body/div/main/div/div/div/form/div[3]/input"));
            var browseCoverInput = driver.FindElement(By.XPath("/html/body/div/main/div/div/div/form/div[4]/div/input"));
            var submitButton = driver.FindElement(By.XPath("/html/body/div/main/div/div/div/form/div[5]/div/input"));

            var bookTitle = "Test";
            var bookAuthor = "Mihai Eminescu";
            var bookGenre = "Romance";

            /* - - - - - - - */

            //ATENTIE!! Modifica pathurile cu orice alte imagini de test pe care vrei sa le folosesti
            
            var imagePath = "E:\\facultate\\Proiect Databases\\WebApp2.0\\WebApplication\\wwwroot\\images\\bookCovers\\unnamed.jpg";
            var newImagePath = "E:\\facultate\\Proiect Databases\\WebApp2.0\\WebApplication\\wwwroot\\images\\bookCovers\\Mihai_Eminescu_-_Poesii.jpg";

            /* - - - - - - - */
            bookTitleTextBox.SendKeys(bookTitle);
            bookAuthorTextBox.SendKeys(bookAuthor);
            bookGenreTextBox.SendKeys(bookGenre);
            
            browseCoverInput.SendKeys(imagePath);

            submitButton.Click();

            driver.Navigate().GoToUrl("https://localhost:44365/Book");
            //testing if the page title appears in the book Index page
            Assert.IsTrue(driver.PageSource.Contains(bookTitle));

            //EDITING THE BOOK

            driver.Navigate().GoToUrl("https://localhost:44365/Book/EditBook");
            var newBookTitle = "Test1";
            var newBookAuthor = "Otilia Cazimir";
            var newGenre = "Action";
            //old title
            driver.FindElement(By.XPath("/html/body/div/main/div/div/div/form/div[1]/input")).SendKeys(bookTitle);
            //new book title
            driver.FindElement(By.XPath("/html/body/div/main/div/div/div/form/div[2]/input")).SendKeys(newBookTitle);
            //new author
            driver.FindElement(By.XPath("/html/body/div/main/div/div/div/form/div[3]/input")).SendKeys(newBookAuthor);
            //new genre
            driver.FindElement(By.XPath("/html/body/div/main/div/div/div/form/div[4]/input")).SendKeys(newGenre);
            //new book cover
            driver.FindElement(By.XPath("/html/body/div/main/div/div/div/form/div[5]/input")).SendKeys(newImagePath);
            //submit
            driver.FindElement(By.XPath("/html/body/div/main/div/div/div/form/div[6]/input")).Click();

            driver.Navigate().GoToUrl("https://localhost:44365/Book");
            //testing if the page title appears in the book Index page
            Assert.IsTrue(driver.PageSource.Contains(newBookTitle));


            //DELETING THE BOOK

            driver.Navigate().GoToUrl("https://localhost:44365/");
            //clicking admin privileges
            driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul[2]/li[6]/a")).Click();
            //remove book
            driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/div[2]/input")).Click();
            //insert book title
            driver.FindElement(By.XPath("/html/body/div/main/div/div/div/form/div[1]/input")).SendKeys(newBookTitle);
            //submit
            driver.FindElement(By.XPath("/html/body/div/main/div/div/div/form/div[2]/input")).Click();

            driver.Navigate().GoToUrl("https://localhost:44365/Book");
            //testing if the page title has been deleted from the Index page
            Assert.IsTrue(!driver.PageSource.Contains(newBookTitle));
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Close();
        }


        
        private void LoginAsAdmin()
        {
            driver.Navigate().GoToUrl("https://localhost:44365/");
            IWebElement loginPageLink = driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul[1]/li[2]/a"));
            loginPageLink.Click();
            string userName = "admin@admin.com";
            string password = "AdminAdmin12#";
            var inputUserName = driver.FindElement(By.XPath("/html/body/div/main/div/div/div/div[2]/div/div/div/section/form/div[2]/input"));
            var inputPassword = driver.FindElement(By.XPath("/html/body/div/main/div/div/div/div[2]/div/div/div/section/form/div[3]/input"));
            inputUserName.Clear();
            inputPassword.Clear();
            inputUserName.SendKeys(userName);
            inputPassword.SendKeys(password);

            var loginButton = driver.FindElement(By.XPath("/html/body/div/main/div/div/div/div[2]/div/div/div/section/form/div[5]/b/button"));
            loginButton.Click();
            
        }

    }
}
