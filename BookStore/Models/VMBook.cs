using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class VMBook
    {
        public List<Author> authors { set; get; }
        public List<Category> categories { set; get; }

         public  Book books { set; get; }
    }
}
