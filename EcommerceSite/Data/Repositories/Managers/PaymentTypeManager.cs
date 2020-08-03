using EcommerceSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Data.Repositories.Managers
{
    public class PaymentTypeManager:Reposiotry<ApplicationDbContext,PaymentsType>,IPaymentTypeManager
    {
        public PaymentTypeManager(ApplicationDbContext context):base(context)
        {

        }
    }
}
