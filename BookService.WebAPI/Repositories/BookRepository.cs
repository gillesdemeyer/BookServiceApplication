using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class BookRepository
    {
        private BookServiceContext db;
        public BookRepository(BookServiceContext context)
        {
            db = context;
        }

        public List<Book> List()
        {
            return db.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToList();
        }

        public List<BookBasic> ListBasic()
        {
            return db.Books.Select(
                b => new BookBasic
                {
                    Id = b.Id,
                    Title = b.Title
                }).ToList();
        }

        public BookDetail GetById(int id)
        {
            return db.Books.Where(b => b.Id == id)
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
                    PublisherName = b.Publisher.Name
                }).FirstOrDefault();
        }

    }
}
