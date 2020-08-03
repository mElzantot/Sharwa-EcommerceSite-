using EcommerceSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace EcommerceSite.Models.ViewModels
{
    public class ProductsPageViewModel:BaseViewModel
    {
        public ProductsPageViewModel(List<Category> categories,List<CartItem> cartItems):base(categories,cartItems)
        {

        }
        public ProductsPageViewModel()
        {

        }
        public IPagedList<Product> ProductsPage { get; set; }
        public object Id { get; set; }
        public string Title { get; set; }
    }
}
