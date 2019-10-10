using BookService.Lib.DTO;
using BookService.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BookService.MVC.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookService.MVC.Controllers
{
    public class BooksController : Controller
    {
        string baseuri = "https://localhost:44338/api/books";
        public async Task<IActionResult> Index()
        {
            string bookUri = $"{baseuri}/basic";
            return View(WebApiHelper.GetApiResult<List<BookBasic>>(bookUri)); 
        }


        public async Task<IActionResult> Detail(int id)
        {
            string geekJokesUri = "https://geek-jokes.sameerkumar.website/api";
            string ipsumUri = "https://baconipsum.com/api/?type=meat-and-filler&paras=2&format=text";
            string bookUri = $"{baseuri}/detail/{id}";
            return View(new BookDetailExtraViewModel
            {
                BookDetail = WebApiHelper.GetApiResult<BookDetail>(bookUri),
                AuthorJoke = "", //GetApiResult<string>(geekJokesUri),
                BookSummary = "" //new HttpClient().GetStringAsync(ipsumUri).Result //pure string response, no json 
            }) ;
        }
    }
}