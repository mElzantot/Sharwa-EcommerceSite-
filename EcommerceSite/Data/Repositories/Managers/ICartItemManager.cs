using EcommerceSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Data.Repositories.Managers
{
    public interface ICartItemManager:IRepository<CartItem>
    {
        IEnumerable<CartItem> GetUserCartItems(string id);
        IEnumerable<CartItem> GetProductCartItems(int id);
    }
}
