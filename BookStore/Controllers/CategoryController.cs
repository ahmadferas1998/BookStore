using BookStore.data;
using BookStore.services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {

        ICategoryServices CategoryServices;
        public CategoryController(ICategoryServices _CategoryServices)
        {

            CategoryServices = _CategoryServices;


        }


        public IActionResult Index()
        {
            ViewData["search"] = true;

            List<Category> li= CategoryServices.insertcategories();
            return View("NewCategorys",li);
        }


        public IActionResult deletcategory(int dept_Id)
        {
            ViewData["search"] = true;
            CategoryServices.deletcategory(dept_Id);
            List<Category> li = CategoryServices.insertcategories();



            return View("NewCategorys", li);
        }



        public IActionResult open()
        {
            ViewData["search"] = false;
            ViewData["isset"] = true;

            return View("AddCategory");
        }

        public IActionResult AddCategory(Category cat)
        {
            ViewData["search"] = false;
            CategoryServices.addCategore(cat);

            ViewData["isset"] =true;


            return View("AddCategory");
        }


        public IActionResult edit(int id )
        {
            ViewData["search"] = false;

            ViewData["isset"] = false;



            return View("AddCategory", CategoryServices.load(id));
        }


        public IActionResult UbdateBook(Category cat)
        {
            ViewData["search"] = false;
            CategoryServices.Ubdate(cat);
            ViewData["isset"] = true;

            return View("AddCategory");
        }

    }
}
