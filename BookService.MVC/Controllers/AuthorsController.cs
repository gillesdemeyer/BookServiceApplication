using System.Collections.Generic;
using BookService.Lib.DTO;
using BookService.MVC.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BookService.MVC.Controllers
{
    public class AuthorsController : Controller
    {
        string baseuri = "https://localhost:44338/api/authors";
        public IActionResult Index()
        {
            string uri = $"{baseuri}/basic";
            return View(WebApiHelper.GetApiResult<List<AuthorBasic>>(uri));
        }
    }
}