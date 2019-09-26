using BookService.WebAPI.Models;

namespace BookService.WebAPI.Repositories
{
    public class PublisherRepository: Repository<Publisher>
    {

        public PublisherRepository(BookServiceContext context): base(context)
        {
        }
       
    }
}
