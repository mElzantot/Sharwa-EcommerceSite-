using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceSite.Data;
using EcommerceSite.Entities;
using EcommerceSite.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList.Mvc.Core;
using X.PagedList;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace EcommerceSite.Controllers
{
    public class CategoryController : Controller
    {
        private IUnitOfWork unitOfWork;
        private List<Category> categories;
        private List<CartItem> cartItems;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            categories = unitOfWork.Categories.GetAll().ToList();
        }
        public IActionResult Index(int? page, int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                cartItems = unitOfWork.CartItems.GetUserCartItems(User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList();
            }
            var model = new ProductsViewModel(categories,cartItems);
            model.Id = id;
            List<Product> products = unitOfWork.Categories.GetProductsWImg(id).ToList();
            //for (int i = 0; i < 20; i++)
            //{
            //    products.Add(unitOfWork.Categories.GetProductsWImg(id).FirstOrDefault());
            //}
            model.ProductsPage = products.ToPagedList(page ?? 1, 12);
           
            return View("Index",model);
        }
        [Authorize]
        public IActionResult AddToCart(int id,int catId, int? pageId)
        {
            unitOfWork.CartItems.Add(new CartItem
            {
                FK_CustomerId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                FK_ProductId = id
            });
            unitOfWork.Complete();
            return Redirect(string.Format("~/Category/Index/{0}?page={1}", catId, pageId));
            return RedirectToAction("Index","Category", new { page = pageId, id = catId });
        }
    }
}