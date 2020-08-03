using EcommerceSite.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EcommerceSite.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<PaymentsType> PaymentsMethods { get; set; }
        public virtual DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ProductsTags>()
                .HasKey(PT => new { PT.ProductID, PT.TagtID });

            builder.Entity<ProductsTags>()
                .HasOne<Product>(pt => pt.Product)
                .WithMany(p => p.ProductsTags)
                .HasForeignKey(pt => pt.ProductID);

            builder.Entity<ProductsTags>()
             .HasOne<Tag>(pt => pt.Tag)
             .WithMany(t => t.ProductsTags)
             .HasForeignKey(pt => pt.TagtID);


            builder.Entity<OrderProducts>()
                .HasKey(OP => new { OP.OrderID, OP.ProductID })
                .HasName("Order_Products");

            builder.Entity<OrderProducts>()
                .Property(OP => OP.ProductQty)
                .IsRequired();

            builder.Entity<OrderProducts>()
                .HasOne<Order>(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderID);

            builder.Entity<OrderProducts>()
                .HasOne<Product>(op => op.Product)
                .WithMany(p => p.OrderProducts)
                 .HasForeignKey(op => op.ProductID);


            builder.Entity<ProductsPayments>()
                .HasKey(PP => new { PP.ProductID, PP.PaymentID });

            builder.Entity<ProductsPayments>()
                .HasOne<PaymentsType>(pp => pp.payyment)
                .WithMany(p => p.ProductsPayments)
                .HasForeignKey(pp => pp.PaymentID);

            builder.Entity<ProductsPayments>()
                .HasOne<Product>(pp => pp.Product)
                .WithMany(p => p.ProductsPayments)
                 .HasForeignKey(pp => pp.ProductID);

            builder.Entity<CartItem>()
            .HasKey(PP => new { PP.FK_ProductId, PP.FK_CustomerId });


            builder.Entity<CartItem>()
                .HasOne<ApplicationUser>(pp => pp.Customer)
                .WithMany(p => p.CartItems)
                .HasForeignKey(pp => pp.FK_CustomerId);

            builder.Entity<CartItem>()
                .HasOne<Product>(pp => pp.Product)
                .WithMany(p => p.CartItems)
                 .HasForeignKey(pp => pp.FK_ProductId);

            builder.Entity<CartItem>()
            .Property(OP => OP.ProductQty)
            .IsRequired();


            //-----------------------------------------------//
              //----------Seeding Main Tables---------//


            //---------Seeding Roles-----------//








            builder.Entity<PaymentsType>()
         .HasData(
       new PaymentsType { Id = 1, Name = "Direct Bank Transfer" },
       new PaymentsType { Id = 2, Name = "Paypal" },
       new PaymentsType { Id = 3, Name = "MasterCard" },
       new PaymentsType { Id = 4, Name = "Visa" },
       new PaymentsType { Id = 5, Name = "On Delivery" }
   );


            builder.Entity<Category>()
                 .HasData(
        new Category { Id = 1, Name = "Men" },
        new Category { Id = 2, Name = "Women" },
        new Category { Id = 3, Name = "Kids" },
        new Category { Id = 4, Name = "Mobile & Tablet" },
        new Category { Id = 5, Name = "Electronics" },
        new Category { Id = 6, Name = "Home & Kitchen" }
    );



            //Seeding Test Data-------------------------------------------------------------------------------------//

            //--------------------------------------------------------------------------------------------------------
            //NOTE: GET Seller ID first then Uncomment and Add the test migration to push intial data
            //--------------------------------------------------------------------------------------------------------


            #region Seeding Products

//            for (int i = 1; i < 10; i++)
//            {
//                builder.Entity<Product>()
//     .HasData(
//                new Product
//                {
//                    Id = i,
//                    Name = "GalaxsyS9",
//                    LongDisc = "The camera, reimagined. Galaxy S9 and S9+ introduced the revolutionary Dual Aperture phone camera that adapts to light like the human eye.",
//                    ShortDisc = "Samsung FlagShip",
//                    Price = 15000,
//                    Discount = 12,
//                    FK_CategoryId = 4,
//                    Stock = 12,
//                    FK_SellerId = "b8e2598f-fb76-4658-88aa-a9fa0be23189"
//                }
//);
//            }
//            for (int i = 10; i < 20; i++)
//            {
//                builder.Entity<Product>()
//     .HasData(
//                new Product
//                {
//                    Id = i,
//                    Name = "IPhone X",
//                    LongDisc = "The iPhone X was Apple's flagship 10th anniversary iPhone featuring a 5.8-inch OLED display," +
//                    " facial recognition and 3D camera functionality, a glass body, and an A11 Bionic processor. Launched November 3," +
//                    " 2017, discontinued with the launch of the iPhone XR, XS, and XS Max.",
//                    ShortDisc = "Iphone FlagShip",
//                    Price = 20000,
//                    FK_CategoryId = 4,
//                    Stock = 20,
//                    FK_SellerId = "b8e2598f-fb76-4658-88aa-a9fa0be23189"
//                }
//            );
//            }

            #endregion


            //--------------------------------------------------------------------------------------------------------
            //After pushing the products uncomment the following migration and run it to add images to the initial data
            //--------------------------------------------------------------------------------------------------------

            #region Seeding Images

            //for (int i = 1; i < 10; i++)
            //{
            //    builder.Entity<Image>()
            //.HasData(
            //new Image { Id = i, ImgPath = "Galaxy2.jpg", FK_ProductId = i },
            //new Image { Id = i + 9, ImgPath = "Galaxy S9.jpg", FK_ProductId = i }
            //);
            //}
            //for (int i = 10; i < 20; i++)
            //{
            //    builder.Entity<Image>()
            // .HasData(
            // new Image { Id = i + 18, ImgPath = "iphonex.jpg", FK_ProductId = i }
            // );
            //}

            #endregion

            base.OnModelCreating(builder);

        }


    }
}
