using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCart.Interfaces;
using BookCart.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCart.DataAccess
{
    public class UserDataAccessLayer : IUserServices
    {
        readonly BookDBContext _dbContext;
        public UserDataAccessLayer(BookDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public UserMaster AuthenticateUser(UserMaster loginCredentials)
        {
            UserMaster user = new UserMaster();

            var userDetails = _dbContext.UserMaster.FirstOrDefault(
                u => u.userName == loginCredentials.userName && u.password == loginCredentials.password
                );

            if (userDetails != null)
            {

                user = new UserMaster
                {
                    userName = userDetails.userName,
                    userID = userDetails.userID,
                    userTypeID = userDetails.userTypeID
                };
                return user;
            }
            else
            {
                return userDetails;
            }
        }

        public bool CheckUserAvailabity(string userName)
        {
            string user = _dbContext.UserMaster.FirstOrDefault(x => x.userName == userName)?.ToString();

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int RegisterUser(UserMaster userData)
        {
            try
            {
                userData.userTypeID = 2;
                _dbContext.UserMaster.Add(userData);
                _dbContext.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
