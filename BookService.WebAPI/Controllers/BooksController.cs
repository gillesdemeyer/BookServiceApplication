using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerCrudBase<Book, BookRepository>
    {
        public BooksController(BookRepository bookRepository): base(bookRepository)
        {
        }

        // GET: api/Books
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await repository.GetAllInclusive());
        }

        // GET: api/Books/Basic
        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetBookBasic()
        {
            return Ok(await repository.ListBasic());
        }


        [HttpGet]
        [Route("ImageByName/{filename}")]
        public  IActionResult ImageByFileName(string filename)
        {
            var image = Path.Combine(Directory.GetCurrentDirectory(),
                             "wwwroot", "images", filename);
            return  PhysicalFile(image, "image/jpeg");
        }

        [HttpGet]
        [Route("ImageById/{bookId}")]
        public async Task<IActionResult> ImageById(int bookId)
        {
            return ImageByFileName((await repository.GetDetailById(bookId)).FileName);
        }
    }
}