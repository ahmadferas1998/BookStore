using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Study_3092022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
   public interface IAccountService
    {
        Task<IdentityResult> AddNewUser(SignupModel signup);
        Task<SignInResult> Loginsucces(LoginModel login);
        Task<IdentityResult> ADDRole(RoleModel rolemodel);
        List<ApplicationUsser> Userlist();
        Task ubdaterole(List<UserRole> lirole);
        Task<List<UserRole>> RoleList(string userID);
        Task logout();


    }
}
