using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    public class Book
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string  descreption { get; set; }
              [ForeignKey("Auther")]
        public int Auther_id { set; get; }
        public Author Auther { get; set; }
        
        [ForeignKey("Category")]
        public int Category_id { set; get; }
        public Category Category { get; set; }

        public string path { set; get; }
        public string price { get; set; }

        [NotMapped]
        public IFormFile Image { set; get; }
    }
}
