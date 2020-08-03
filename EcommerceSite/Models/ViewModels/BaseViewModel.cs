using EcommerceSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Models.ViewModels
{
    abstract public class BaseViewModel
    {
        public List<Category> Categories { get; set; }
        public List<CartItem> CartItems { get; set; }
        public string SearchString { get; set; }
        public BaseViewModel(List<Category> categories, List<CartItem> cartItems)
        {
            Categories = categories;
            CartItems = cartItems;
        }
        public BaseViewModel()
        {
            Categories = null;
            CartItems = null;
        }
    }
}
