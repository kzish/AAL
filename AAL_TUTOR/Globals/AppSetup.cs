using AAL_TUTOR.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Globals
{
    public class AppSetup
    {
        /// <summary>
        /// bootstrap the application
        /// </summary>
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        dbContext db = new dbContext();
        public AppSetup(IConfiguration configuration, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;

            this.CreateRoles();
            this.CreateAdminUser();
            this.CreateFolders();
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

        private void CreateFolders()
        {
            var resources_folder = configuration.GetValue<string>("resources_folder");
            var profile_pictures_folder = configuration.GetValue<string>("profile_pictures_folder");

            Directory.CreateDirectory(resources_folder);
            Directory.CreateDirectory(profile_pictures_folder);
        }

    }


}
