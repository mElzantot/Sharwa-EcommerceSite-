using EcommerceSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Entities
{
    public class CartItem
    {
        public string FK_CustomerId { get; set; }
        public int FK_ProductId { get; set; }
        public ApplicationUser Customer { get; set; }
        public Product Product { get; set; }
        public int ProductQty { get; set; }
    }
}
