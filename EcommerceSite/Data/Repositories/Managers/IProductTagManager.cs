using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceSite.Entities;
namespace EcommerceSite.Data.Repositories.Managers
{
    public interface IProductTagManager:IRepository<ProductsTags>
    {
        void RemoveTagsForProduct(int productId);

    }
}
