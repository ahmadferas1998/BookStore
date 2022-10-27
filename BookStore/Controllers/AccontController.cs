using BookStore.Models;
using BookStore.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Study_3092022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AccontController : Controller
    {

 IAccountService IAccountService;
        UserManager<ApplicationUsser> userm;
        RoleManager<IdentityRole> rolemanger;
        SignInManager<ApplicationUsser> signInM;
        public AccontController(IAccountService _IAccountService, UserManager<ApplicationUsser> _userManager, SignInManager<ApplicationUsser> _signInManager, RoleManager<IdentityRole> _rolemanger)
        {

            rolemanger = _rolemanger;
            userm = _userManager;
            signInM = _signInManager;
            IAccountService = _IAccountService;
        }
       
        
 
        public IActionResult Index()
        {
            return View("NewAccount");
        }


        public async Task<IActionResult>  AddNewClint(SignupModel signup)
        
        {
            await IAccountService.AddNewUser(signup);

            return View("NewAccount");
        }

        public IActionResult Login()
        {
            return View("Login");
        }
      
        public async Task<IActionResult> LoginSucces(LoginModel login)
        {

          var result=  await IAccountService.Loginsucces(login);

            if (result.Succeeded == true)
            {
         
               return RedirectToAction("Index", "Book");

            }
            else
             
            {
                ViewData["a"] = "Invalid login";
                return View("NewAccount");

            }


           




        }
        [Authorize]
        public IActionResult NewRole()
            {


                return View("NewRole");
            }
        public async Task<IActionResult> AddRow(RoleModel rolemodel)
        {
            var result = await IAccountService.ADDRole(rolemodel);



            return View("NewRole");
        }
        [Authorize]
        public IActionResult USerList()
        {

            List<ApplicationUsser> li = IAccountService.Userlist();


            return View("USerList", li);
        }

        public async Task<IActionResult> CheackUser(string userid)
        {
            List<UserRole> LI = await IAccountService.RoleList(userid);


            return View("CheackUser", LI);
        }



        public async Task<IActionResult> ubdaterole(List<UserRole> lrole)
        {

            await IAccountService.ubdaterole(lrole);

            List<UserRole> lrolee = await IAccountService.RoleList(lrole[0].userid);

            return View("CheackUser", lrolee);
        }

        public IActionResult signout()
        {

            IAccountService.logout();
            return View("loginpage");

        }


    }
}
