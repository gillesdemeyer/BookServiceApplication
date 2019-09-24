using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        PublisherRepository repository;

        public PublishersController(PublisherRepository publisherRepository)
        {
            repository = publisherRepository;
        }

        // GET: api/Publishers
        [HttpGet]
        public IActionResult GetPublishers()
        {
            return Ok(repository.List());
        }


        // GET: api/Publishers/2
        [HttpGet("{id}")]
        public IActionResult GetPublisher(int id)
        {
            return Ok(repository.GetById(id));
        }
    }
}