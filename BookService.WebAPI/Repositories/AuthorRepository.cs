using BookService.Lib.DTO;
using BookService.Lib.Models;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class AuthorRepository : Repository<Author>
    {

        public AuthorRepository(BookServiceContext context): base(context)
        {
        }

        public async Task<List<AuthorBasic>> ListBasic()
        {
            // return a list of books with all Book-properties
            return await db.Authors.Select(a => new AuthorBasic
            {
                Id = a.Id,
                Name = $"{a.LastName} {a.FirstName}"

            }).ToListAsync();
        }

    }
}