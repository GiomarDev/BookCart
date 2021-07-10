using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCart.Models
{
    public partial class CustomerOrderDetails
    {
    
        public int orderDetailsID { get; set; }
        public String orderID { get; set; }
        public int productoID { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
    
    }
}
