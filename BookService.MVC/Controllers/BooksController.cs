using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BookService.Lib.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookService.MVC.Controllers
{
    public class BooksController : Controller
    {
        string baseuri = "https://localhost:5001/api/books";
        public async Task<IActionResult> Index()
        {
            string bookUri = $"{baseuri}/basic";
            return Ok(await GetApiResult<List<BookBasic>>(bookUri)); //View();
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
    }
}