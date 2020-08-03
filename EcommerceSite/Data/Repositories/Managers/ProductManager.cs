using EcommerceSite.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Data.Repositories.Managers
{
    public class ProductManager : Reposiotry<ApplicationDbContext, Product>,IProductManager
    {
        public ProductManager(ApplicationDbContext context) : base(context)
        {

        }

       

        public IEnumerable<Product> GetOnSale()
        {
            return set.Where(prod=>prod.Discount >0).Include(prod => prod.Images);
        }

        public IEnumerable<Product> GetSellerProducts(string id)
        {
            return set.Where(prod => prod.FK_SellerId ==id).Include(prod=>prod.Images);
        }

        public IEnumerable<Product> GetAllWithImages()
        {
            return set.Include("Images");
        }
        public Product GetProductWithImgs(int id)
        {
            return set.Where(e => e.Id == id).Include(pr => pr.Images).FirstOrDefault();
        }
        public IEnumerable<Product> GetSearchName(string name)
        {
            var x = set.Where(prod => prod.Name.Contains(name));
            return set.Where(prod => prod.Name.Contains(name)).Include(pr => pr.Images);
        }

        public Product GetProductWithRelatives(int id)
        {
            return set.Where(e => e.Id == id).Include(pr => pr.Images).Include(pr=>pr.ProductsPayments)
                .Include(pr=>pr.ProductsTags).FirstOrDefault();
        }


    }
}
