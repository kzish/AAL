using AAL_API5.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AAL_API5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API",
                    Description = "API",
                    TermsOfService = new Uri("http://abc.xyz.com"),
                    Contact = new OpenApiContact() { Name = "Contact Name", Email = "support@abc.xyz", Url = new Uri("http://abc.xyz.com/") },
                });
                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    In = ParameterLocation.Header,
                //    Description = "Please insert JWT with Bearer into field",
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.ApiKey
                //});
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                //   {
                //     new OpenApiSecurityScheme
                //     {
                //       Reference = new OpenApiReference
                //       {
                //         Type = ReferenceType.SecurityScheme,
                //         Id = "Bearer"
                //       }
                //      },
                //      new string[] { }
                //    }
                //});
            });
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
                c.AddPolicy("AllowMethod", options => options.AllowAnyMethod());
                c.AddPolicy("AllowHeader", options => options.AllowAnyHeader());
            });
            /////////////////////
            services.AddScoped<Globals.MoodleRepository>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("db")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, opt =>
            {
                opt.LoginPath = "/Auth/Login";
            });
            //for tempdata
            services.Configure<CookieTempDataProviderOptions>(options =>
            {
                options.Cookie.IsEssential = true;
            });


            services.AddControllers().AddNewtonsoftJson(x =>
            x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllersWithViews();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "API V1");
                c.OAuthClientId("api");
                c.OAuthAppName("api");
            });
            app.UseStaticFiles();
            app.UseCors(x => x
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();//place befroe mvc
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
            //boostrap the app
            var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();
            var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            var signInManager = serviceScope.ServiceProvider.GetService<SignInManager<IdentityUser>>();
            Globals.AppSetup appSetup = new Globals.AppSetup(env, signInManager, userManager, roleManager);

            var app_name = env.ApplicationName;
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(app_name);
            });
        }
    }
}
