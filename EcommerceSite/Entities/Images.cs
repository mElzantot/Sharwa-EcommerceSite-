using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Entities
{
    [Table("Images")]
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public string ImgPath { get; set; }

        [ForeignKey(nameof(Product))]
        public int FK_ProductId { get; set; }

        public Product Product { get; set; }
    }
}
