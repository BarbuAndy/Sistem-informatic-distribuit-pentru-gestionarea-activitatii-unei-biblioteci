using Microsoft.AspNetCore.Mvc;
using WebApplication.Services;
using WebApplication.Models;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class AdminAuthorController : Controller
    {
        private readonly AuthorService _authorService;

        public AdminAuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult CreateAuthor()
        {
            var model = new AuthorModel { };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddAuthor(AuthorModel Author)
        {

            try
            {
                _authorService.AddAuthor(Author);
                _authorService.Save();
                ModelState.Clear();
                ViewData["Message"] = "1";
            }
            catch
            {
                ViewData["Message"] = "0";
            }
            return RedirectToAction("CreateAuthor", "AdminAuthor");

        }

        public IActionResult RemoveAuthorForm()
        {
            var model = new AuthorModel { };
            return View(model);
        }
        

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> RemoveAuthor(AuthorModel Author)
        {
            try
            {
                await _authorService.DeleteAuthor(Author);
                _authorService.Save();
                ModelState.Clear();
                ViewData["Message"] = "1";
            }
            catch
            {
                ViewData["Message"] = "0";
            }
            return View();

        }


        public IActionResult EditAuthorForm()
        {
            var model = new AuthorModel { };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]

        public ActionResult EditAuthor(AuthorModel Author)
        {
            try
            {
                _authorService.UpdateAuthor(Author);
                _authorService.Save();
                ModelState.Clear();
                ViewData["Message"] = ViewData["Message"] + "1";
            }
            catch
            {
                ViewData["Message"] = ViewData["Message"] + "0";
            }
            return View();
        }
    }
}
