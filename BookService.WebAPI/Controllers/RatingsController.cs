using BookService.Lib.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerCrudBase<Rating, RatingRepository>
    {
        public RatingsController(RatingRepository ratingRepository) : base(ratingRepository)
        {
            // commentaar
        }
        // GET: api/Ratings
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await repository.GetAllInclusive());
        }
    }
}
