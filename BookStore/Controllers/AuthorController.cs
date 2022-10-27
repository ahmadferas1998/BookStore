using BookStore.data;
using BookStore.services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        IAuthorServices AuthorServices;
        public AuthorController(IAuthorServices _AuthorServices)
        {

            AuthorServices =_AuthorServices;


        }
        public IActionResult Index()
        {
            ViewData["search"] = true;

            List<Author>  li= AuthorServices.InsertAuthor();
        
            return View("NewAuther",li);
        }

        public IActionResult deletAuthor(int dept_Id)
        {
            ViewData["search"] =true
                ;
            AuthorServices.DeletAutor(dept_Id);
            List<Author> li = AuthorServices.InsertAuthor();
               


            return View("NewAuther",li);
        }

        public IActionResult addauthor(Author aut)
        {
            ViewData["search"] = false;

            AuthorServices.addauthor(aut);
            ViewData["isset"] = true;

            return View("AddAuthor");
        }
        public IActionResult open()
        {
            ViewData["search"] = false;

            ViewData["isset"] = true;

            return View("AddAuthor");
        }

        public IActionResult edit(int id)
        {
            ViewData["search"] = false;
            ViewData["isset"] = false;



            return View("AddAuthor", AuthorServices.load(id));
        }


        public IActionResult UbdateBook(Author cat)
        {


            ViewData["search"] = false;
            AuthorServices.Ubdate(cat);
            ViewData["isset"] = true;

            return View("AddAuthor");
        }
    }
}
