using System;
using System.Linq;
using System.Threading.Tasks;
using AAL_ADMIN.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


/// <summary>
/// allows the admin to manage the roles
/// </summary>
namespace SpeedLinkAdminPortal.Controllers
{
    [Route("Roles")]
    public class RolesController : Controller
    {
        public UserManager<IdentityUser> UserManager { get; }
        readonly RoleManager<IdentityRole> _roleManager;

        dbContext db = new dbContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }


        public RolesController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.UserManager = userManager;
            this._roleManager = roleManager;
        }


        /// <summary>
        /// fetch all roles
        /// </summary>
        /// <returns></returns>
        [HttpGet("All")]
        public IActionResult All()
        {
            ViewBag.title = "All Roles";
            var roles = _roleManager.Roles.ToList();
            ViewBag.roles = roles;
            return View();
        }


        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(string rolename)
        {
            ViewBag.title = "Create Role";
            try
            {
                bool x = await _roleManager.RoleExistsAsync("admin");
                if (!x)
                {
                    var role = new IdentityRole(rolename.ToLower());
                    await _roleManager.CreateAsync(role);
                    TempData["type"] = "success";
                    TempData["msg"] = "Role Created";
                }
                else
                {
                    TempData["type"] = "error";
                    TempData["msg"] = "Role exists";
                }

            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = ex.Message;
            }

            return RedirectToAction("All", "Roles");
        }

        [HttpGet("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            ViewBag.title = "Delete Role";
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role == null)
                {
                    TempData["type"] = "error";
                    TempData["msg"] = "Role does not exist";
                }
                else
                {
                    await _roleManager.DeleteAsync(role);
                    TempData["type"] = "success";
                    TempData["msg"] = "Deleted Role";
                }
            }
            catch (Exception ex)
            {
                TempData["type"] = "error";
                TempData["msg"] = ex.Message;
            }
            return RedirectToAction("All", "Roles");
        }




    }
}
