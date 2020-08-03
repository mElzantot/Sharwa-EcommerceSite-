using EcommerceSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Models.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {
        public HomeViewModel(List<Category> categories,List<CartItem> cartItems):base(categories,cartItems)
        {

        }
    }
}
