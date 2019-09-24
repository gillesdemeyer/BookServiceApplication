using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{
    public class PublisherRepository
    {

        private BookServiceContext db;
        public PublisherRepository(BookServiceContext context)
        {
            db = context;
        }

        public List<Publisher> List()
        {
            // return a list of books with all Book-properties
            return db.Publishers.ToList();
        }


        public Publisher GetById(int id)
        {
            return db.Publishers.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Publisher> Update(Publisher publisher)
        {
            try
            {
                db.Entry(publisher).State = EntityState.Modified;
                await db.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExists(publisher.Id))
                {
                    return null;
                } else
                {
                    throw;
                }
            }

            return publisher;
        }


        public async Task<Publisher> Add(Publisher publisher)
        {
            db.Publishers.Add(publisher);
            await db.SaveChangesAsync();
            return publisher;
        }

        private bool PublisherExists(int id)
        {
            return db.Publishers.Any(e => e.Id == id);
        }
    }
}
