using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCart.Models;

namespace BookCart.Interfaces
{
    interface IUserServices
    {
        UserMaster AuthenticateUser(UserMaster loginCredentials);
        int RegisterUser(UserMaster userData);
        bool CheckUserAvailabity(string userName);
    }
}
