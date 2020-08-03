using EcommerceSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;


namespace EcommerceSite.Models.ViewModels
{
    public class CategoryViewModel:BaseViewModel
    {
        public CategoryViewModel(List<Category> categories,List<CartItem> cartItems):base(categories,cartItems)
        {

        }
        public CategoryViewModel()
        {

        }
        //public List<Product> Products { get; set; }
        public IPagedList<Product> ProductsPage { get; set; }
        public Category Category { get; set; }

    }
}
