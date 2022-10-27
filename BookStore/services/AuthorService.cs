using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public class AuthorService: IAuthorServices
    {

        BookContext BookContext;
        public AuthorService(BookContext _BookContext)
        {
            BookContext = _BookContext;



        }






        public List<Author> InsertAuthor()
        {



            List<Author> li = BookContext.Authors.ToList();

            return (li);
        }


        public void DeletAutor(int dep_id)
        {
           Author a= BookContext.Authors.Find(dep_id);
            BookContext.Authors.Remove(a);
            BookContext.SaveChanges();

        }

        public void addauthor(Author aut)
        {
           BookContext.Add(aut);
            BookContext.SaveChanges();
        }
        public Author load(int id)
        {

            Author Author = BookContext.Authors.Find(id);

            return Author;
        }
        public void Ubdate(Author cat)
        {
            BookContext.Authors.Attach(cat);
            BookContext.Entry(cat).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            BookContext.SaveChanges();

        }


    }
}
