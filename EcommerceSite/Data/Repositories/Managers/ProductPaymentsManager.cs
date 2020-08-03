using EcommerceSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Data.Repositories.Managers
{
    public class ProductPaymentsManager:Reposiotry<ApplicationDbContext,ProductsPayments>,IProductPaymentsManager
    {
        public ProductPaymentsManager(ApplicationDbContext context) : base(context)
        {
        }

        public void  RemovePaymentsForProduct(int productId)
        {
            set.RemoveRange(set.Where(e => e.ProductID == productId));
        }
    }
}
