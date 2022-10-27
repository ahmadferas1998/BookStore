using BookStore.data;
using BookStore.Models;
using BookStore.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {

        IConfiguration IConfiguration;
        IBookServices IBookServices;
        public BookController(IBookServices _IBookServices , IConfiguration _IConfiguration)
        {
            IConfiguration = _IConfiguration;
            IBookServices = _IBookServices;


        }
        [Authorize]


        public IActionResult Index()
        {
            
            VMBook vm = new VMBook();
            vm.authors = IBookServices.insertAuthor();
            vm.categories = IBookServices.insertCategory();
            ViewData["isset"] = false;
            ViewData["search"] = false;
            return View("ADDNEWBOOK",vm);
        }
        [Authorize]
        public IActionResult SaveBook(VMBook vm2)
        {

            ViewData["search"] = false;
            string name = Guid.NewGuid().ToString() + "." + vm2.books.Image.FileName.Split('.')[1];
                string path1 = Path.Combine(Directory.GetCurrentDirectory(), IConfiguration["UploadFile"], name);
                vm2.books.Image.CopyTo(new FileStream(path1, FileMode.Create));
                vm2.books.path = name;


                RedirectToAction("ListOfBook", "Book");

         
                VMBook vm = new VMBook();
                vm.authors = IBookServices.insertAuthor();
                vm.categories = IBookServices.insertCategory();
            ViewData["search"] = false;

            IBookServices.LiBook(vm2.books);
            List<Book> li = IBookServices.insertBook();
            return View("ListOfBook", li);


        }
        [Authorize]
        public IActionResult DeletBook(int dept_Id)



        {
            ViewData["search"] = false;
            IBookServices.DeletBook(dept_Id);
            List<Book> li = IBookServices.insertBook();

           
            return View("ListOfBook", li);
        }


       
        public IActionResult BookShope()
        {

            VMBookShope vm = new VMBookShope();

           vm.books=IBookServices.insertBook();
            vm.categories = IBookServices.insertCategory();
            ViewData["is"] = true;

            return View("BookShope" ,vm);
        }


        [Authorize]
        public IActionResult edit(int dept_Id)
        {
            VMBook vm = new VMBook();
            Book book = IBookServices.load(dept_Id);
            vm.authors = IBookServices.insertAuthor();
            vm.categories = IBookServices.insertCategory();
            vm.books = book;
            ViewData["search"] = true;
            ViewData["isset"] = true; 
            return View("ADDNEWBOOK", vm);
        }
        [Authorize]
        public IActionResult UbdateBook(VMBook vm)
        {
            ViewData["search"] = false;
            ViewData["isset"] = true;
            IBookServices.Ubdate(vm.books);
            vm.authors = IBookServices.insertAuthor();
            vm.categories = IBookServices.insertCategory();
            return View("ADDNEWBOOK", vm);
        }
        [Authorize]
        public IActionResult openList()
        {
            ViewData["search"] = true;
            List<Book> li = IBookServices.insertBook();
            return View("ListOfBook", li);
        }
       

        public IActionResult loadbook(int Id)
        {

            ViewData["search"] = false;
            List<Book> li = IBookServices.loadbook(Id);

            return Json (li);
        }
      
        public IActionResult toogle(int Id)
        {
            ViewData["search"] = false;

            ViewData["is"] = false;
            VMBookShope vm = new VMBookShope();
       Book book=  IBookServices.insertBookTogle(Id);

            vm.books = IBookServices.insertBook();
            vm.categories = IBookServices.insertCategory();
            vm.book = book;

            return View("Deyails", vm);
        }
        public IActionResult loadbyid(int id)
        {

            ViewData["search"] = false;
            ViewData["is"] = true;
            VMBookShope vm = new VMBookShope();
       

            vm.books = IBookServices.loadbyid(id);
            vm.categories = IBookServices.insertCategory();
        
            return View("BookShope", vm);
        }
        public IActionResult search()
        
        
        
        
        
        {
        string name = Request.Form["searche"];
            ViewData["search"] = true;
            List<Book> li = IBookServices.search(name);


            return View("ListOfBook", li);
        }


        





    }
}
