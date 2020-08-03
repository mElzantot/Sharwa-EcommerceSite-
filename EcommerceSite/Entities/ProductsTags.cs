using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Entities
{
    public class ProductsTags
    {


        public int ProductID { get; set; }
        public int TagtID { get; set; }

        public Product Product { get; set; }

        public Tag Tag { get; set; }


    }
}
