using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        BookRepository repository;
        public BooksController(BookRepository bookRepository)
        {
            repository = bookRepository;
        }

        // GET: api/Books
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(repository.List());
        }

        // GET: api/Books/Basic
        [HttpGet]
        [Route("Basic")]
        public IActionResult GetBooksBasic()
        {
            return Ok(repository.ListBasic());
        }

        // GET: api/Books/1
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBook(int id)
        {
            return Ok(repository.GetById(id));
        }

        [HttpGet]
        [Route("ImageByName/{filename}")]
        public IActionResult ImageByFileName(string filename)
        {
            var image = Path.Combine(Directory.GetCurrentDirectory(),
                             "wwwroot", "images", filename);
            return PhysicalFile(image, "image/jpeg");
        }

        [HttpGet]
        [Route("ImageById/{bookId}")]
        public IActionResult ImageById(int bookId)
        {
            return ImageByFileName(repository.GetById(bookId).FileName);
        }
    }
}