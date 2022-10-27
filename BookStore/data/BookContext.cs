
using BookStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    public class BookContext:IdentityDbContext<ApplicationUsser>
    {
        IConfiguration config;

        public BookContext (IConfiguration _config)
        {
  
            config = _config;

        }

        public DbSet<Book> books { set; get; }
        public DbSet<Author> Authors { set; get; }
        public DbSet<Category> Categorys { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


      
            optionsBuilder.UseSqlServer(config.GetConnectionString("xyz"));
            base.OnConfiguring(optionsBuilder);
        }




    }
}
