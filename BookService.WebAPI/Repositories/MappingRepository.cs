using AutoMapper;
using BookService.WebAPI.Models;

namespace BookService.WebAPI.Repositories
{
    public class MappingRepository<T>: Repository<T> where T: EntityBase
    {
        protected readonly IMapper mapper;
        public MappingRepository(BookServiceContext context, IMapper mapper): base (context)
        {
            this.mapper = mapper;
        }
    }
}
