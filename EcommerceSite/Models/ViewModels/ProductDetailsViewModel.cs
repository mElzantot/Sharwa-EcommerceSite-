using EcommerceSite.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Models.ViewModels
{
    public class ProductDetailsViewModel:BaseViewModel

    {
        public ProductDetailsViewModel(List<Category> categories, List<CartItem> cartItems) : base(categories, cartItems)
        {

        }
        public ProductDetailsViewModel()
        {

        }

        public Product Product { get; set; }

    }
}
