using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EcommerceSite.Data;
using EcommerceSite.Entities;
using EcommerceSite.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceSite.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork unitOfWork;
        private List<Category> categories;
        private List<CartItem> cartItems;
        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            categories = unitOfWork.Categories.GetAll().ToList();
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                cartItems = unitOfWork.CartItems.GetUserCartItems(User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList();
            }
            var model = new HomeViewModel(categories,cartItems);
            return View(model);
        }
    }
}