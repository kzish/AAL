using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using SharedModels;
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
        public IHostingEnvironment env;

        dbContext db = new dbContext();
        public AppSetup(IWebHostEnvironment env, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.env = (IHostingEnvironment)env;

            this.InitAppSettings();
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
            Directory.CreateDirectory(AppSettings.resources_folder);
            Directory.CreateDirectory(AppSettings.profile_pictures_folder);
        }

        private void InitAppSettings()
        {
            if (env.IsDevelopment())
            {
                AppSettings.resources_folder = @"C:\AAL_RESOURCES";
                AppSettings.moodle_ws_token = "402faee3445fee742d7edadb76780439";
                AppSettings.profile_pictures_folder = $@"{AppSettings.resources_folder}\profile_pictures";
                AppSettings.moodle_api_endpoint = $"http://moodle.test/webservice/rest/server.php?wstoken={AppSettings.moodle_ws_token}&moodlewsrestformat=json";
            }
            else
            {
                AppSettings.resources_folder = @"C:\AAL_RESOURCES";
                AppSettings.moodle_ws_token = "402faee3445fee742d7edadb76780439";
                AppSettings.profile_pictures_folder = $@"{AppSettings.resources_folder}\profile_pictures";
                AppSettings.moodle_api_endpoint = $"http://moodle.test/webservice/rest/server.php?wstoken={AppSettings.moodle_ws_token}&moodlewsrestformat=json";
            }

        }
    }


}
