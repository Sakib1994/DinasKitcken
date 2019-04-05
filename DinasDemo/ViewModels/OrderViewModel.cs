using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinasDemo.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string Division { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public decimal OrderTotal { get; set; }

        public DateTime OrderPlaced { get; set; }

        public IEnumerable<ProductOrder> Products { get; set; }
    }
}
