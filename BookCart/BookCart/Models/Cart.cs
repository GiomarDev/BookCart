using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCart.Models
{
    public partial class Cart
    {

        public String cartID { get; set; }
        public int userID { get; set; }
        public DateTime createDate { get; set; }

    }
}
