using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        AuthorRepository repository;

        public AuthorsController(AuthorRepository authorRepository)
        {
            repository = authorRepository;
        }

        // GET: api/Authors
        [HttpGet]
        public IActionResult GetAuthors()
        {
            return Ok(repository.List());
        }

        // GET: api/Authors/Basic
        [HttpGet]
        [Route("Basic")]
        public IActionResult GetAuthorBasic()
        {
            return Ok(repository.ListBasic());
        }

        // GET: api/Authors/2
        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            return Ok(repository.GetById(id));
        }
    }
}