using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookService.WebAPI.Repositories
{
    public class AuthorRepository
    {
        private BookServiceContext db;
        public AuthorRepository(BookServiceContext context)
        {
            db = context;
        }

        public List<Author> List()
        {
            // return a list of authors with all Author-properties
            return db.Authors.ToList();
        }

        public List<AuthorBasic> ListBasic()
        {
            // return a list of books with all Book-properties
            return db.Authors.Select(a => new AuthorBasic
            {
                Id = a.Id,
                Name = $"{a.LastName} {a.FirstName}"

            }).ToList();
        }

        public Author GetById(int id)
        {
            return db.Authors.FirstOrDefault(a => a.Id == id);
        }
    }
}