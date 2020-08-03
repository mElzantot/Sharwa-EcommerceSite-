using EcommerceSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Data.Repositories.Managers
{
    public interface IProductManager:IRepository<Product>
    {
        IEnumerable<Product> GetSellerProducts(string id);
        IEnumerable<Product> GetOnSale();
        IEnumerable<Product> GetAllWithImages();
        Product GetProductWithImgs(int id);
        Product GetProductWithRelatives(int id);
        IEnumerable<Product> GetSearchName(string name);

    }
}
