using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCart.Models
{
    public class Book
    {
    
        public int bookID { get; set; }
        public String title { get; set; }
        public String autor { get; set; }
        public String category { get; set; }
        public decimal price { get; set; }
        public String coverFileName { get; set; }
    
    }
}
