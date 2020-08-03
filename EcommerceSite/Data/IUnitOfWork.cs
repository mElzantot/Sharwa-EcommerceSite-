using EcommerceSite.Data.Repositories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Data
{
    public interface IUnitOfWork
    {
        IProductManager Products { get; }
        ICategoryManager Categories { get;}
        IImageManager Images { get; }
        IOrderManager Orders { get; }
        IPaymentTypeManager Payments { get; }
        ITagManager Tags { get; }
        ICartItemManager CartItems { get; }
        IProductPaymentsManager ProductPayments { get; }
        IProductTagManager ProductTag { get;}
        IOrderProductManager OrderProduct { get;}
        int Complete();
    }
}
