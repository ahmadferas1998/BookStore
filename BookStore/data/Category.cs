using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    public class Category
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
          public List<Book> books { get; set; }
    }
}
