using System;
using System.Collections.Generic;
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
    }
}