using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class VMBookShope
    {
        public List<Category> categories { set; get; }

        public List <Book> books { set; get; }
        public Book book { set; get; }
    }
}
