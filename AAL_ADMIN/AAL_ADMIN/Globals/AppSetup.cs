using AAL_ADMIN.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAL_ADMIN.Globals
{
    public class AppSetup
    {
        /// <summary>
        /// bootstrap the application
        /// </summary>
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        dbContext db = new dbContext();
        public AppSetup(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;

            this.CreateRoles();
            this.CreateAdminUser();
        }

        private void CreateRoles()
        {
            //
            if (!roleManager.RoleExistsAsync("admin").Result)
                roleManager.CreateAsync(new IdentityRole("admin"));
            //
            if (!roleManager.RoleExistsAsync("tutor").Result)
                roleManager.CreateAsync(new IdentityRole("tutor"));
            //
            if (!roleManager.RoleExistsAsync("student").Result)
                roleManager.CreateAsync(new IdentityRole("student"));
        }


        private void CreateAdminUser()
        {
            string admin_email = "admin@rubiem.com";
            string admin_password = "Rubiem#99";
            //
            var exist = db.AspNetUsers.Where(i => i.Email == "admin@rubiem.com").Any();
            if (!exist)
            {
                var admin_user = new IdentityUser();
                admin_user.Email = admin_email;
                admin_user.UserName = admin_email;
                userManager.CreateAsync(admin_user, admin_password).Wait();
                userManager.AddToRoleAsync(admin_user, "admin");//add user to admin role
            }
        }
    }


}
