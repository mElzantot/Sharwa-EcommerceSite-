using EcommerceSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace EcommerceSite.Data.Repositories.Managers
{
    public class CartItemManager:Reposiotry<ApplicationDbContext,CartItem>,ICartItemManager
    {
        public CartItemManager(ApplicationDbContext context):base(context)
        {

        }

        public IEnumerable<CartItem> GetProductCartItems(int id)
        {
            return set.Where(item => item.FK_ProductId == id).Include(item => item.Product).ThenInclude(prod => prod.Images);
        }

        public IEnumerable<CartItem> GetUserCartItems(string id)
        {
            return set.Where(item => item.FK_CustomerId == id).Include(item=>item.Product).ThenInclude(prod=>prod.Images);
        }
    }
}
