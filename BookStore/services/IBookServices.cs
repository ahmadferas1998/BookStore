using BookStore.data;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
 public   interface IBookServices
    { 
        
        void LiBook(Book vm2);
        List<Author> insertAuthor();
        List<Category> insertCategory();
        List<Book> insertBook();
        void DeletBook(int dept_Id);
        Book load(int dept_Id);
        void Ubdate(Book book);
        List<Book> loadbook(int Author_id);
        Book insertBookTogle(int id);
        List<Book> loadbyid(int id);
        List<Book> search(string name);



    }
}
