using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookService.Lib.DTO;
using BookService.Lib.Models;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class PublisherRepository: MappingRepository<Publisher>
    {

        public PublisherRepository(BookServiceContext context, IMapper mapper): base(context, mapper)
        {
        }

        public async Task<List<PublisherBasic>> ListBasic()
        {
            // return a list of BookBasic DTO-items (Id and Title only) using AutoMapper
            return await db.Publishers
                .ProjectTo<PublisherBasic>(mapper.ConfigurationProvider)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

    }
}
