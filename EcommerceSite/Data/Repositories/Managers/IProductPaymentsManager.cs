﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceSite.Entities;
namespace EcommerceSite.Data.Repositories.Managers
{
    public interface IProductPaymentsManager:IRepository<ProductsPayments>
    {
        void RemovePaymentsForProduct(int productId);




    }



}
