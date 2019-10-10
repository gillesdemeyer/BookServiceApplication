using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BookService.Lib.DTO;
using BookService.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookService.MVC.Controllers
{
    public class BooksController : Controller
    {
        string baseuri = "https://localhost:44338/api/books";
        public async Task<IActionResult> Index()
        {
            string bookUri = $"{baseuri}/basic";
            return View(await GetApiResult<List<BookBasic>>(bookUri)); 
        }

        public static async Task<T> GetApiResult<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string response = await httpClient.GetStringAsync(uri);
                return await Task.Factory.StartNew
                            (
                                () => JsonConvert
                                      .DeserializeObject<T>(response)
                            );
            }
        }

        public async Task<IActionResult> Detail(int id)
        {
            string geekJokesUri = "https://geek-jokes.sameerkumar.website/api";
            string ipsumUri = "https://baconipsum.com/api/?type=meat-and-filler&paras=2&format=text";
            string bookUri = $"{baseuri}/detail/{id}";
            return View(new BookDetailExtraViewModel
            {
                BookDetail = await GetApiResult<BookDetail>(bookUri),
                AuthorJoke = "", //GetApiResult<string>(geekJokesUri),
                BookSummary = "" //new HttpClient().GetStringAsync(ipsumUri).Result //pure string response, no json 
            }) ;
        }
    }
}