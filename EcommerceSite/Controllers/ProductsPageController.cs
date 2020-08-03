using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceSite.Data;
using EcommerceSite.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EcommerceSite.Models.ViewModels;
using System.Security.Claims;
using X.PagedList;

namespace EcommerceSite.Controllers
{
    public class ProductsPageController : Controller
    {
        private IUnitOfWork unitOfWork;
        private List<Category> categories;
        private List<CartItem> cartItems;
        public ProductsPageController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            categories = unitOfWork.Categories.GetAll().ToList();
        }
        public IActionResult Category(int? page, int id,string name)
        {
            if (User.Identity.IsAuthenticated)
            {
                cartItems = unitOfWork.CartItems.GetUserCartItems(User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList();
            }
            var model = new ProductsPageViewModel(categories, cartItems);
            model.Id = id;
            List<Product> products = unitOfWork.Categories.GetProductsWImg(id).ToList();
            model.ProductsPage = products.ToPagedList(page ?? 1, 12);
            model.Title = name;
            return View("ProductsPage", model);
        }
        [Authorize(Roles =("Seller"))]
        public IActionResult SellerProducts(string id,int? page)
        {
            if (User.Identity.IsAuthenticated)
            {
                cartItems = unitOfWork.CartItems.GetUserCartItems(User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList();
            }

            var model = new ProductsPageViewModel(categories, cartItems);
            model.Id = id;
            model.Title = "Listed Items";
            model.ProductsPage = unitOfWork.Products.GetSellerProducts(id).ToPagedList(page ?? 1, 12);
            return View("ProductsPage", model);
        }
        public IActionResult SaleProducts(int? page)
        {
            if (User.Identity.IsAuthenticated)
            {
                cartItems = unitOfWork.CartItems.GetUserCartItems(User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList();
            }
            var model = new ProductsPageViewModel(categories, cartItems);
            model.Title = "ON SALE";
            model.ProductsPage = unitOfWork.Products.GetOnSale().ToPagedList(page ?? 1, 12);
            return View("ProductsPage", model);
        }
        public IActionResult SearchProducts(int? page,string SearchString)
        {
            if (User.Identity.IsAuthenticated)
            {
                cartItems = unitOfWork.CartItems.GetUserCartItems(User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList();
            }
            var model = new ProductsPageViewModel(categories, cartItems);
            model.Title = "Search Results";
            model.ProductsPage = unitOfWork.Products.GetSearchName(SearchString).ToPagedList(page ?? 1, 12);
            var productTags = unitOfWork.Tags.GetProductsTags(SearchString);
            if (productTags!=null)
            {
                foreach (var item in productTags)
                {
                    model.ProductsPage.Append(item.Product);
                }

            }
            return View("ProductsPage", model);
        }



    }
}