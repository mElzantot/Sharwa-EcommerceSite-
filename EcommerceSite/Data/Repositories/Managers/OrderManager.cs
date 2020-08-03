using EcommerceSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Data.Repositories.Managers
{
    public class OrderManager:Reposiotry<ApplicationDbContext,Order>,IOrderManager
    {
        public OrderManager(ApplicationDbContext context):base(context)
        {

        }
    }
}
