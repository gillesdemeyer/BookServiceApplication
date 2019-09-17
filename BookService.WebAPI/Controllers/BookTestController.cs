using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTestController : ControllerBase
    {
        BookServiceContext _db;
        public BookTestController(BookServiceContext db)
        {
            _db = db;
        }

        public IActionResult GetBooks()
        {
            return Ok(_db.Books.Select(
                b => new BookBasic
                {
                    Id = b.Id,
                    Title = b.Title
                }).ToList());
        }

    }
}