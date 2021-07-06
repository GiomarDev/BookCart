using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCart.Models
{
    public class CustomerOrders
    {

        public string orderID { get; set; }
        public int userID { get; set; }
        public DateTime createDate { get; set; }
        public decimal cartTotal { get; set; }
    
    }
}
