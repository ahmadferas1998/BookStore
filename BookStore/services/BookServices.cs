using BookStore.data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public class BookServices : IBookServices
    {

        BookContext BookContext;
        public BookServices(BookContext _BookContext)
        {

            BookContext = _BookContext;

        }

        public List<Author> insertAuthor()
        {



            List<Author> li = BookContext.Authors.ToList();

            return (li);
        }

        public List<Category> insertCategory()
        {

            List<Category> li = BookContext.Categorys.ToList();

            return (li);


        }



        public void LiBook (Book vm2)
        {

            BookContext.books.Add(vm2);
            BookContext.SaveChanges();
        }

        public List<Book> insertBook()
        {

            List<Book> li = BookContext.books.Include("Auther").Include("Category").ToList();

            return (li);


        }

        public void DeletBook(int dept_Id)
        {
            Book book = BookContext.books.Find(dept_Id);
            BookContext.books.Remove(book);
           BookContext .SaveChanges();



        }
        public Book load(int dept_Id)
        {

            return BookContext.books.Find(dept_Id);


        }
        public void Ubdate(Book book)
        {
            BookContext.books.Attach(book);
            BookContext.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            BookContext.SaveChanges();

        }

        public List<Book> loadbook(int category_id)
        {

            return BookContext.books.Where(e => e.Category_id ==category_id ).ToList();

        }


        public Book insertBookTogle(int id)
        {


           Book book = BookContext.books.Find(id);

            return book;

        }
        public List<Book>  loadbyid(int id)
        {


            List<Book> li = BookContext.books.Include("Auther").Include("Category").Where(e => e.Category_id == id).ToList();

            return li;

        }


        public List<Book> search(string name)
        {

            List<Book> li = BookContext.books.Where(e => e.name == name).ToList();


            return li;
        }


    }



}
