using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Study_3092022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public class AcccontService : IAccountService
    {

        UserManager<ApplicationUsser> userm;
        RoleManager<IdentityRole> rolemanger;
        SignInManager<ApplicationUsser> signInM;
        public AcccontService(UserManager<ApplicationUsser> _userManager, SignInManager<ApplicationUsser> _signInManager, RoleManager<IdentityRole> _rolemanger)
        {

            rolemanger = _rolemanger;
            userm = _userManager;
            signInM = _signInManager;

        }

        public async Task<IdentityResult> AddNewUser(SignupModel signup)
        {

            ApplicationUsser user = new ApplicationUsser();
            user.UserName = signup.name;
            user.Email = signup.email;
            user.bdate= signup.bdate;
            user.PasswordHash = signup.passwotrd;

          return await userm.CreateAsync(user, signup.passwotrd);

        

     

        }
        public async Task<SignInResult> Loginsucces(LoginModel login)
        {

            return await signInM.PasswordSignInAsync(login.name, login.password, false, false);




        }
        public async Task<IdentityResult> ADDRole(RoleModel rolemodel)
        {
            IdentityRole role = new IdentityRole();
            role.Name = rolemodel.name;

            var result = await rolemanger.CreateAsync(role);


            return result;
        }
        public List<ApplicationUsser> Userlist()
        {

            return userm.Users.ToList();


        }

        public async Task<List<UserRole>> RoleList(string userID)
        {
            List<IdentityRole> rolls = rolemanger.Roles.ToList();
            List<UserRole> lirole = new List<UserRole>();
            foreach (IdentityRole item in rolls)
            {
                UserRole uroll = new UserRole();
                uroll.roleid = item.Id;
                uroll.name = item.Name;
                uroll.userid = userID;
                uroll.ISSET = false;
                lirole.Add(uroll);

            }
            foreach (UserRole item in lirole)
            {
                var user = await userm.FindByIdAsync(item.userid);
                var ruls = await userm.GetRolesAsync(user);
                foreach (string r in ruls)
                {
                    if (r == item.name)
                    {

                        item.ISSET = true;

                    }
                }

            }

            return lirole;

        }

        public async Task ubdaterole(List<UserRole> lirole)
        {
            foreach (UserRole item in lirole)


            {
                var user = await userm.FindByIdAsync(item.userid);

                if (item.ISSET == true)
                {
                    if (await userm.IsInRoleAsync(user, item.name) == false)
                    {
                        await userm.AddToRoleAsync(user, item.name);
                    }

                }
                else
                {
                    if (await userm.IsInRoleAsync(user, item.name) == true)
                    {
                        await userm.RemoveFromRoleAsync(user, item.name);
                    }


                }




            }




        }
        public async Task logout()
        {

            await signInM.SignOutAsync();


        }

    }
}
