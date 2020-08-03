using EcommerceSite.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSite.Data
{
    public class ApplicationUser : IdentityUser
    {

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }


        [Required]
        [Display(Name = "Phone Number : ") ]
        public override string PhoneNumber { get; set; }
        public ICollection<CartItem> CartItems { get; set; }


    }
}
