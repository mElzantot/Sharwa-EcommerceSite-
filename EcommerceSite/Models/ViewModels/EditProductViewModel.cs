using EcommerceSite.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Models.ViewModels
{
    public class EditProductViewModel:BaseViewModel
    {
        public EditProductViewModel(List<Category> categories, List<CartItem> cartItems) : base(categories, cartItems)
        {

        }
        public EditProductViewModel()
        {

        }
        public Product Product { get; set; }
        public List<IFormFile> photo { get; set; }
        public List<PaymentsType> PaymentMethods { get; set; }
        public List<Tag> tags { get; set; }


    }
}
