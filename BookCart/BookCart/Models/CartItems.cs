using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCart.Models
{
    public class CartItems
    {

        public int cartItemID { get; set; }
        public String cartID { get; set; }
        public int productID { get; set; }
        public int quantity { get; set; }

    }
}
