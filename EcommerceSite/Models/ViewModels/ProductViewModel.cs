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
    public class ProductViewModel:BaseViewModel

    {
        public ProductViewModel(List<Category> categories, List<CartItem> cartItems) : base(categories, cartItems)
        {

        }
        public ProductViewModel()
        {

        }
        public Product Product { get; set; }
        [Required]
        public List<IFormFile> photo { get; set; }

        public List<PaymentsType> PaymentMethods { get; set; }

    }
}
