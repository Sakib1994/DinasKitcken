using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DinasDemo.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public ICollection<OrderDetail> OrderLines { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        [StringLength(150)]
        [Display(Name = "Address")]
        public string AddressLine1 { get; set; }

        [StringLength(10)]
        public string Division { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        public decimal OrderTotal { get; set; }

        public DateTime OrderPlaced { get; set; }
    }
}
