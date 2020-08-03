using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EcommerceSite.Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EcommerceSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        //------------Initialze Roles and Admin in DB
        private async Task createRoles(IServiceProvider serviceProvider)
        {
            //adding custom roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "Customer", "Seller" };
            IdentityResult roleResult;

            foreach (var item in roleNames)
            {
                //creating the roles and seeding them to the database
                bool roleExist = await RoleManager.RoleExistsAsync(item);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(item));
                }
            }

            //creating a super user who could maintain the web app
            var _Email = Configuration.GetSection("UserSettings")["UserEmail"];
            var _user = await UserManager.FindByEmailAsync(_Email);
            if (_user != null)
            {
                if (!(await UserManager.IsInRoleAsync(_user, "Admin")))
                    await UserManager.AddToRoleAsync(_user, "Admin");
            }
            if (_user == null)
            {
                var adminUser = new ApplicationUser
                {
                    Email = _Email,
                    FirstName = "Omar",
                    LastName = "Shaker",
                    PhoneNumber = "01110636961",
                    Address = "ITI - Giza",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = Configuration.GetSection("UserSettings")["UserName"]
                };
                string passWord = Configuration.GetSection("UserSettings")["UserPassword"];
                var createAdminUser = await UserManager.CreateAsync(adminUser, passWord);
                if (createAdminUser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")),ServiceLifetime.Scoped);
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.User.AllowedUserNameCharacters = string.Empty;
                options.User.RequireUniqueEmail = true;
            })
                .AddRoles<IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            //Unit of Work Service
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {

                routes.MapRoute(
                     name: "areas",
                    template: "{area}/{controller}/{action}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            createRoles(serviceProvider).Wait();

        }
    }

}
