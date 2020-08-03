using EcommerceSite.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Data.Repositories.Managers
{
    public class CategoryManager:Reposiotry<ApplicationDbContext,Category>,ICategoryManager
    {
        public CategoryManager(ApplicationDbContext context):base(context)
        {
            
        }

        public IEnumerable<Product> GetProductsWImg(int id)
        {
            return set.Include(cat => cat.Products).ThenInclude(prod => prod.Images).FirstOrDefault(cat => cat.Id == id).Products;
        }
    }
}
