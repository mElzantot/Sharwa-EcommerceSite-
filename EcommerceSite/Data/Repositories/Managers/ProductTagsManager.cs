using EcommerceSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Data.Repositories.Managers
{
    public class ProductTagsManager:Reposiotry<ApplicationDbContext,ProductsTags>,IProductTagManager
    {
        public ProductTagsManager(ApplicationDbContext context) : base(context)
        {
        }

        public void RemoveTagsForProduct(int productId)
        {
            set.RemoveRange(set.Where(e => e.ProductID == productId));
        }

    }
}
