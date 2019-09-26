using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAuthors()
        {
            return Ok(await repository.ListAll());
        }

        // GET: api/Authors/Basic
        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetAuthorBasic()
        {
            return Ok(await repository.ListBasic());
        }

        // GET: api/Authors/2
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            return Ok(await repository.GetById(id));
        }
    }
}