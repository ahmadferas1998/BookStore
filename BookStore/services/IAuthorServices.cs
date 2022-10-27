using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public interface IAuthorServices
    {
        List<Author> InsertAuthor();
        void DeletAutor(int dep_id);
        void addauthor(Author aut);
        Author load(int id);
        void Ubdate(Author cat);



    }
}
