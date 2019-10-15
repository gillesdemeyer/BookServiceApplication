using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BookService.Lib.DTO;
using BookService.Lib.Models;
using BookService.MVC.Helpers;
using BookService.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookService.MVC.Controllers
{
    public class PublishersController : Controller
    {
        string baseuri = "https://localhost:44338/api/publishers";
        public IActionResult Index()
        {
            string uri = $"{baseuri}/basic";
            return View(WebApiHelper.GetApiResult<List<PublisherBasic>>(uri));
        }

        public IActionResult Detail(int id)
        {
            string uri = $"{baseuri}/{id}";
            ViewBag.Mode = "Detail";
            return View(WebApiHelper.GetApiResult<Publisher>(uri));

        }

        public IActionResult Edit(int id) { 
            string uri = $"{baseuri}/{id}"; 
            ViewBag.Mode = "Edit"; 
            return View("Detail", WebApiHelper.GetApiResult<Publisher>(uri)); 
        }

        public IActionResult Insert()
        {
            ViewBag.Mode = "Edit";
            return View("Detail", new Publisher());
        }

        [HttpPost]
        public async Task<IActionResult> Save(Publisher publisher)
        {
            if (publisher.Id != 0)
            {
                // update
                string uri = $"{baseuri}/{publisher.Id}";
                publisher = await WebApiHelper.PutCallAPI<Publisher, Publisher>(uri, publisher);
            }
            else
            {
                // insert
                string uri = $"{baseuri}";
                publisher = await WebApiHelper.PostCallAPI<Publisher, Publisher>(uri, publisher);
            }

            ViewBag.Mode = "Detail";
            return View("Detail", publisher);
        }

        public async Task<IActionResult> Delete(int id)
        {
            string uri = $"{baseuri}/{id}";
            Publisher publisher = await WebApiHelper.DelCallAPI<Publisher>(uri);
            return RedirectToAction("Index");
        }
    }
}