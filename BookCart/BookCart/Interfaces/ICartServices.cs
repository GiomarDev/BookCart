using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCart.Interfaces
{
    interface ICartServices
    {
        void AddBookToCart(int userId, int bookId);
        void RemoveCartItem(int userId, int bookId);
        void DeleteOneCartItem(int userId, int bookId);
        int GetCartItemCount(int userId);
        void MergeCart(int tempUserId, int permUserId);
        int ClearCart(int userId);
        string GetCartId(int userId);
    }
}
