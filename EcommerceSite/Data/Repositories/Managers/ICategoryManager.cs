using EcommerceSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Data.Repositories.Managers
{
    public interface ICategoryManager:IRepository<Category>
    {
        IEnumerable<Product> GetProductsWImg(int id);
    }
}
