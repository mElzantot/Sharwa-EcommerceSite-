using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EcommerceSite.Data;
using EcommerceSite.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceSite.Controllers
{
    public class CartItemController : Controller
    {
        private IUnitOfWork unitOfWork;
        public CartItemController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index(string FK_CustomerId, int FK_ProductId)
        {
            unitOfWork.CartItems.Delete(FK_ProductId, FK_CustomerId);
            unitOfWork.Complete();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        [Authorize]
        public IActionResult AddToCart(int id,int ProductQty=1)
        {
            IEnumerable<CartItem> UserItems = unitOfWork.CartItems.GetUserCartItems(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (UserItems !=null )
            {
                CartItem UserItem = UserItems.FirstOrDefault(item=>item.FK_ProductId == id);
                if (UserItem != null)
                {
                    UserItem.ProductQty += ProductQty;
                    unitOfWork.CartItems.Edit(UserItem);
                    unitOfWork.Complete();
                    return Redirect(Request.Headers["Referer"].ToString());
                }
            }
            unitOfWork.CartItems.Add(new CartItem
            {
                FK_CustomerId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                FK_ProductId = id,
                ProductQty =ProductQty
            });
            unitOfWork.Complete();
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult ModifyCart(int id, int ProductQty)
        {
            CartItem UserItem = unitOfWork.CartItems.GetById(id, User.FindFirst(ClaimTypes.NameIdentifier).Value);
            UserItem.ProductQty = ProductQty;
            unitOfWork.CartItems.Edit(UserItem);
            unitOfWork.Complete();
            return Redirect(Request.Headers["Referer"].ToString());
        }


    }
}