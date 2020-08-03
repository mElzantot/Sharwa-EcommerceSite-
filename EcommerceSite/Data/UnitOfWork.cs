using EcommerceSite.Data.Repositories.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Data
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            Products = new ProductManager(context);
            Categories = new CategoryManager(context);
            Images = new ImageManager(context);
            Orders = new OrderManager(context);
            Payments = new PaymentTypeManager(context);
            Tags = new TagManager(context);
            CartItems = new CartItemManager(context);
            ProductPayments = new ProductPaymentsManager(context);
            ProductTag = new ProductTagsManager(context);
            OrderProduct = new OrderProductManager(context);
        }

        public IProductManager Products { get; }

        public ICategoryManager Categories { get; }

        public IImageManager Images { get; }

        public IOrderManager Orders { get; }

        public IPaymentTypeManager Payments { get; }

        public ITagManager Tags { get; }

        public ICartItemManager CartItems { get; }

        public IProductPaymentsManager ProductPayments { get; }

        public IProductTagManager ProductTag { get; }

        public IOrderProductManager OrderProduct { get; }

        public int Complete()
        {
            return context.SaveChanges();
        }

    }
}

