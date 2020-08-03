using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Entities
{
    public class ProductsPayments
    {

        public Product Product { get; set; }
        public PaymentsType payyment { get; set; }

        public int ProductID { get; set; }
        public int PaymentID { get; set; }


    }
}
