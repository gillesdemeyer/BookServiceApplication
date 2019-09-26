using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Models
{
    public class EntityBase
    {

        private DateTime? created;

        public int Id { get; set; }

        public DateTime? Created
        {
            get { return created ?? DateTime.Now; }
            set {
                if (value != null)
                    created = value;
                else created = DateTime.Now;
            }
        }

    }
}
