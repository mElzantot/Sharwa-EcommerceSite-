using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Entities
{
    public class OrderProducts
    {
        
        public Product Product { get; set; }
        public Order Order { get; set; }

        public int ProductQty { get; set; }

        public int ProductID { get; set; }
        public int OrderID { get; set; }

    }
}
