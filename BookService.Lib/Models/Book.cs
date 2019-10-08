using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Lib.Models
{
    public class Book: EntityBase
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        [Display(Name="#")]
        public int NumberOfPages { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public string FileName { get; set; }

        public decimal Price { get; set; }
        public int Year { get; set; }

        [JsonIgnore]
        public ICollection<Rating> Ratings { get; set; }
    }
}
