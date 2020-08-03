using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Entities
{
    [Table("Payments Type")]
    public class PaymentsType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<ProductsPayments> ProductsPayments { get; set; }
        [NotMapped]
        public bool IsChecked { get; set; }

    }
}
