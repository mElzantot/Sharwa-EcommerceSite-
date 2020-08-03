using EcommerceSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Data.Repositories.Managers
{
    public class OrderProductManager:Reposiotry<ApplicationDbContext,OrderProducts>,IOrderProductManager
    {
        public OrderProductManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
