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
    public class BookRepository: MappingRepository<Book>
    {
        public BookRepository(BookServiceContext context, IMapper mapper):  base(context, mapper)
        {
        }

        public async Task<List<Book>> GetAllInclusive()
        {
            return await db.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToListAsync();
        }

        public async Task<List<BookBasic>> ListBasic()
        {
            return await db.Books
                .ProjectTo<BookBasic>(mapper.ConfigurationProvider)
                .OrderBy(b => b.Title)
                .ToListAsync();
        }

        public async Task<List<BookStatistic>> ListBookStatistics()
        {
            return await db.Books
                .Where(b => b.Ratings.Count > 0)
                .ProjectTo<BookStatistic>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<BookDetail> GetDetailById(int id)
        {
            return mapper.Map<BookDetail>( await db.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(b => b.Id == id));
        }

    }
}
