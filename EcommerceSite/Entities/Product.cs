using EcommerceSite.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Entities
{
    public class Product
    {

        public Product()
        {
            this.Images = new HashSet<Image>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(25)]
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float Price { get; set; }

        [Range(0,100)]
        [Display(Name="Discount %")]
        public float Discount { get; set; }

        [Required]
        [Range(1,1000)]
        public int Stock { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(25)]
        [Required]
        [Display(Name ="Short Description")]
        public string ShortDisc { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        [MaxLength(1000)]
        public string LongDisc { get; set; }

        [MaxLength(100)]
        public string Thumb { get; set; }


        [ForeignKey(nameof(Seller))]
        public string FK_SellerId { get; set; }
        public ApplicationUser Seller { get; set; }

        [ForeignKey(nameof(Category))]
        [Display(Name="Category")]
        public int FK_CategoryId { get; set; }
        public Category Category { get; set; }


        public ICollection<Image> Images { get; set; }

        [Display(Name = "available Payment Methods")]

        public ICollection<ProductsPayments> ProductsPayments { get; set; }
        public ICollection<OrderProducts> OrderProducts { get; set; }
        public ICollection<ProductsTags> ProductsTags { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
