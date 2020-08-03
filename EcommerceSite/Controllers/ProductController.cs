using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EcommerceSite.Data;
using EcommerceSite.Entities;
using EcommerceSite.Models;
using EcommerceSite.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceSite.Presentation.Controllers
{
    public class ProductController : Controller
    {


        private readonly IHostingEnvironment hostingEnvironment;
        private IUnitOfWork unitOfWork;
        private UserManager<ApplicationUser> userManager;
        private List<Category> categories;
        private List<CartItem> cartItems;

        public ProductController(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment, UserManager<ApplicationUser> userManager)
        {
            //this.AppDbcontext = AppDbContext;

            this.hostingEnvironment = hostingEnvironment;
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            categories = unitOfWork.Categories.GetAll().ToList();
        }

        [HttpGet]
        [Authorize(Roles = "Seller")]
        public IActionResult Add()
        {
            if (User.Identity.IsAuthenticated)
            {
                cartItems = unitOfWork.CartItems.GetUserCartItems(User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList();
            }

            ProductViewModel productVM = new ProductViewModel(categories, cartItems)
            {
                //Categories = unitOfWork.Categories.GetAll().ToList(),
                PaymentMethods = unitOfWork.Payments.GetAll().ToList()

            };

            return View(productVM);
        }


        [HttpPost]
        [Authorize(Roles = "Seller")]
        public IActionResult Add(ProductViewModel model, List<string> tags)
        {
            if (User.Identity.IsAuthenticated)
            {
                cartItems = unitOfWork.CartItems.GetUserCartItems(User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList();
            }
            if (ModelState.IsValid)
            {

                //------Create New Product to add to DataBase
                Product product = new Product
                {
                    Name = model.Product.Name,
                    Price = model.Product.Price,
                    Discount = model.Product.Discount,
                    LongDisc = model.Product.LongDisc,
                    ShortDisc = model.Product.ShortDisc,
                    Stock = model.Product.Stock,
                    FK_CategoryId = model.Product.FK_CategoryId,
                    FK_SellerId = userManager.GetUserId(HttpContext.User)

                };
                //------Add product to DataBase
                //-------Get Product ID in DB
                int productId = unitOfWork.Products.Add(product).Id;

                //------Check Which items in checkBox is selected
                foreach (var item in model.PaymentMethods)
                {
                    if (item.IsChecked == true)
                    {
                        //--------Add Record inn DB for Products and the Available Payment methods
                        unitOfWork.ProductPayments
                            .Add(new ProductsPayments { PaymentID = item.Id, ProductID = productId });
                    }
                }

                string uniqeFileName = null;
                if (model.photo != null)
                {
                    //-------Get images Folder path in Server
                    string uploaderFolder = Path.Combine(hostingEnvironment.WebRootPath, "imgs");

                    foreach (var item in model.photo)
                    {
                        //-------Create New Guid fo each image
                        uniqeFileName = Guid.NewGuid().ToString() + "_" + item.FileName;
                        //---------The full path for image
                        string filePath = Path.Combine(uploaderFolder, uniqeFileName);
                        //----------Copy image to server
                        item.CopyTo(new FileStream(filePath, FileMode.Create));

                        //------Creat instance of image
                        Image img = new Image
                        {
                            ImgPath = uniqeFileName,
                            FK_ProductId = productId
                        };

                        //-----Add image To DB
                        unitOfWork.Images.Add(img);
                    }
                    

                    if (tags.Count > 0)
                    {
                        foreach (var item in tags)
                        {
                            //------------Check if The Tag is already stored in DataBase
                            Tag tag = unitOfWork.Tags.GetAll().Where(e => e.Name == item).FirstOrDefault();
                            //------if Tag isn`t stored in DB
                            if (tag == null)
                            {
                                //------Create a new Tag
                                tag = new Tag
                                {
                                    Name = item
                                };
                                //-------Store it in DB
                                unitOfWork.Tags.Add(tag);
                            }
                            //------Create new instance of Product and Tag
                            ProductsTags productTag = new ProductsTags
                            {
                                ProductID = productId,
                                TagtID = tag.Id
                            };
                            //----------Add the new Relation in DB
                            ProductsTags productsTags = unitOfWork.ProductTag.Add(productTag);
                        }
                    }

                }

                return RedirectToAction("SellerProducts","ProductsPage",new {id = product.FK_SellerId });
            }
            else
            {
                ProductViewModel productVM = new ProductViewModel(categories, cartItems)
                {
                    //Categories = unitOfWork.Categories.GetAll().ToList(),
                    PaymentMethods = unitOfWork.Payments.GetAll().ToList()
                };
                return View(productVM);
            }
        }


        public IActionResult Details(int id)
        {
            Product product = unitOfWork.Products.GetById(id);
            if (product == null)
            {
                ErrorViewModel errorVM = new ErrorViewModel
                {
                    RequestId = "Product Not Found"
                };
                return View("Error", errorVM);
            }

            if (User.Identity.IsAuthenticated)
            {
                cartItems = unitOfWork.CartItems.GetUserCartItems(User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList();
            }

            ProductDetailsViewModel productVM = new ProductDetailsViewModel(categories, cartItems)
            {
                //Categories = unitOfWork.Categories.GetAll().ToList(),
                Product = unitOfWork.Products.GetProductWithImgs(id)
            };

            return View(productVM);

        }

        [HttpGet]
        [Authorize(Roles = "Seller")]
        public IActionResult Edit(int id)
        {

            Product product = unitOfWork.Products.GetById(id);
            if (product == null)
            {
                ErrorViewModel errorVM = new ErrorViewModel
                {
                    RequestId = "Product Not Found"
                };
                return View("Error", errorVM);
            }

            if (User.Identity.IsAuthenticated)
            {
                cartItems = unitOfWork.CartItems.GetUserCartItems(User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList();
            }


            EditProductViewModel productVM = new EditProductViewModel(categories, cartItems)
            {
                Product = unitOfWork.Products.GetProductWithRelatives(id),
                PaymentMethods = unitOfWork.Payments.GetAll().ToList(),
                tags = new List<Tag>()
            };

            //ProductsTags[] productTags = productVM.Product.ProductsTags.ToArray();

            ProductsTags[] productTags = unitOfWork.ProductTag.GetAll().Where(pt => pt.ProductID == id).Include(p => p.Tag).ToArray();
            for (int i = 0; i < productTags.Count(); i++)
            {
                productVM.tags.Append(productTags[i].Tag);
            }
            return View(productVM);
        }


        [HttpPost]
        [Authorize(Roles = "Seller")]
        public IActionResult Edit([FromRoute] int id, EditProductViewModel model, List<string> tags)
        {
            if (User.Identity.IsAuthenticated)
            {
                cartItems = unitOfWork.CartItems.GetUserCartItems(User.FindFirst(ClaimTypes.NameIdentifier).Value).ToList();
            }

            if (ModelState.IsValid)
            {

                //------Edit product in DataBase
                unitOfWork.Products.Edit(model.Product);

                //------Remove Old Proudct Payments and Product Tags
                unitOfWork.ProductPayments.RemovePaymentsForProduct(id);
                unitOfWork.ProductTag.RemoveTagsForProduct(id);
                unitOfWork.Complete();

                //------Check Which items in checkBox is selected
                foreach (var item in model.PaymentMethods)
                {
                    if (item.IsChecked == true)
                    {
                        //--------Add Record inn DB for Products and the Available Payment methods
                        unitOfWork.ProductPayments
                            .Add(new ProductsPayments { PaymentID = item.Id, ProductID = model.Product.Id });
                    }
                }

                string uniqeFileName = null;
                if (model.photo != null)
                {
                    //-------Get images Folder path in Server
                    string uploaderFolder = Path.Combine(hostingEnvironment.WebRootPath, "imgs");

                    foreach (var item in model.photo)
                    {
                        //-------Create New Guid fo each image
                        uniqeFileName = Guid.NewGuid().ToString() + "_" + item.FileName;
                        //---------The full path for image
                        string filePath = Path.Combine(uploaderFolder, uniqeFileName);
                        //----------Copy image to server
                        item.CopyTo(new FileStream(filePath, FileMode.Create));

                        //------Creat instance of image
                        Image img = new Image
                        {
                            ImgPath = uniqeFileName,
                            FK_ProductId = model.Product.Id
                        };

                        //-----Add image To DB
                        unitOfWork.Images.Add(img);

                    }

                    if (tags.Count > 0)
                    {
                        foreach (var item in tags)
                        {
                            //------------Check if The Tag is already stored in DataBase
                            Tag tag = unitOfWork.Tags.GetAll().Where(e => e.Name == item).FirstOrDefault();
                            //------if Tag isn`t stored in DB
                            if (tag == null)
                            {
                                //------Create a new Tag
                                tag = new Tag
                                {
                                    Name = item
                                };
                                //-------Store it in DB
                                unitOfWork.Tags.Add(tag);
                            }
                            //------Create new instance of Product and Tag
                            ProductsTags productTag = new ProductsTags
                            {
                                ProductID = model.Product.Id,
                                TagtID = tag.Id
                            };
                            //----------Add the new Relation in DB
                            ProductsTags productsTags = unitOfWork.ProductTag.Add(productTag);
                        }
                    }

                }

                return RedirectToAction("SellerProducts", "ProductsPage", new { id = model.Product.FK_SellerId });
            }
            else
            {
                ProductViewModel productVM = new ProductViewModel(categories, cartItems)
                {
                    //Categories = unitOfWork.Categories.GetAll().ToList(),
                    PaymentMethods = unitOfWork.Payments.GetAll().ToList()
                };
                return View(productVM);
            }
        }



    }
}