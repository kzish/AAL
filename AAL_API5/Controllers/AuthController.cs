using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SharedModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AAL_API5.Controllers
{
    //access/refresh tokens //https://code-maze.com/using-refresh-tokens-in-asp-net-core-authentication/
    //https://jasonwatmore.com/post/2022/01/24/net-6-jwt-authentication-with-refresh-tokens-tutorial-with-example-api
    //[Route("[controller]")]
    [Route("Auth")]
    public class AuthController : Controller
    {
        private IConfiguration _config;
        private dbContext db;

        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

        public AuthController(IConfiguration config, dbContext db, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            _config = config;
            this.db = db;
        }

        /// <summary>
        /// refresh token
        /// </summary>
        /// <returns></returns>
        private string CreateRT()
        {
            var randomNumber = new byte[32];
            using (var generator = new RNGCryptoServiceProvider())
            {
                generator.GetBytes(randomNumber);
                string token = Convert.ToBase64String(randomNumber);
                return token;
            }
        }

        /// <summary>
        /// refresh token is stored in a cookie
        /// </summary>
        /// <param name="refreshToken"></param>
        private void SetRTCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7), // one week expiry time
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] LoginModel login)
        {
            IActionResult response = Unauthorized();
            var aspnet_user = db.Aspnetusers
            .Where(i => i.Email == login.Email)
            .FirstOrDefault();

            var user = userManager.FindByEmailAsync(login.Email).Result;
            var result = await userManager.CheckPasswordAsync(user, login.Password);

            if (result)
            {
                var tokenString = BuildToken(aspnet_user);
                response = Ok(new
                {
                    res = "ok",
                    token = tokenString,
                    email = aspnet_user.Email,
                });
            }
            else
            {
               response = Ok(new
                {
                    res = "err",
                    msg = "Invalid credentials",
                });
            }

            return response;
        }

        private string BuildToken(Aspnetuser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            claims.Add(new Claim("email", user.Email));
            //
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims: claims,
              expires: DateTime.Now.AddMinutes(30),
              //expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public class LoginModel
        {
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
        }

    }
}
