using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCart.Models
{
    public partial class UserMaster
    {

        public int userID { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String userName { get; set; }
        public String password { get; set; }
        public String gender { get; set; }
        public int userTypeID { get; set; }

    }
}
