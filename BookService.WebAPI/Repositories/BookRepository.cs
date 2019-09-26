using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class BookRepository: Repository<Book>
    {
        public BookRepository(BookServiceContext context):  base(context)
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
            return await db.Books.Select(
                b => new BookBasic
                {
                    Id = b.Id,
                    Title = b.Title
                }).ToListAsync();
        }

        public async Task<BookDetail> GetDetailById(int id)
        {
            return await db.Books.Where(b => b.Id == id)
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Select(b => new BookDetail
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    NumberOfPages = b.NumberOfPages,
                    Year = b.Year,
                    Price = b.Price,
                    AuthorId = b.Author.Id,
                    AuthorName = $"{b.Author.FirstName} {b.Author.LastName}",
                    PublisherId = b.Publisher.Id,
                    PublisherName = b.Publisher.Name,
                    FileName = b.FileName
                }).FirstOrDefaultAsync();
        }

    }
}
