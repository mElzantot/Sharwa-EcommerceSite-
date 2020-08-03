using EcommerceSite.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Entities
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int Id { get; set; }


        [DataType(DataType.DateTime)]
        [Column("Order Date")]
        public DateTime? OrderDate { get; set; }


        [ForeignKey(nameof(Customer))]
        public string FK_CustomerId { get; set; }
        public ApplicationUser Customer { get; set; }



        [ForeignKey(nameof(PaymentMethod))]
        public int FK_PaymentMethod { get; set; }

        public PaymentsType PaymentMethod { get; set; }

        public ICollection<OrderProducts> OrderProducts { get; set; }



    }
}
