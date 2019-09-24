using BookService.WebAPI.Models;
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
    }
}
