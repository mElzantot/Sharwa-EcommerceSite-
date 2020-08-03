using EcommerceSite.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Entities
{
    public class SeedRoles
    {


        //public static void Initialize(IServiceProvider serviceProvider)
        //{
        //    var context = serviceProvider.GetService<ApplicationDbContext>();

        //    string[] roles = new string[] { "Owner", "Administrator", "Manager", "Editor", "Buyer", "Business", "Seller", "Subscriber" };

        //    foreach (string role in roles)
        //    {
        //        var roleStore = new RoleStore<IdentityRole>(context);

        //        if (!context.Roles.Any(r => r.Name == role))
        //        {
        //            roleStore.CreateAsync(new IdentityRole(role));
        //        }
        //    }




    }
}
