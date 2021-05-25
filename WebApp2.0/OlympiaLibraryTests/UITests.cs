using Microsoft.AspNetCore.Identity;
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

        [TestMethod]
        public void Test_Add_Book_Then_Delete_Book()
        {

            LoginAsAdmin();

            //Adding the book

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

            bookTitleTextBox.SendKeys(bookTitle);
            bookAuthorTextBox.SendKeys(bookAuthor);
            bookGenreTextBox.SendKeys(bookGenre);
            browseCoverInput.SendKeys("E:\\facultate\\Proiect Databases\\WebApp2.0\\WebApplication\\wwwroot\\images\\bookCovers\\unnamed.jpg");
            submitButton.Click();
            
            

            //Deleting the book

            driver.Navigate().GoToUrl("https://localhost:44365/");
            //clicking admin privileges
            driver.FindElement(By.XPath("/html/body/header/nav/div/div[2]/ul[2]/li[6]/a")).Click();
            //remove book
            driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/div[2]/input")).Click();
            //insert book title
            driver.FindElement(By.XPath("/html/body/div/main/div/div/div/form/div[1]/input")).SendKeys("Test");
            //submit
            driver.FindElement(By.XPath("/html/body/div/main/div/div/div/form/div[2]/input")).Click();
            
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
