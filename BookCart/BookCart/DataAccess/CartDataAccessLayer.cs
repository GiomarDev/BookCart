using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCart.Interfaces;
using BookCart.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCart.DataAccess
{
    public class CartDataAccessLayer: ICartServices
    {
        readonly BookDBContext _dbContext;

        public CartDataAccessLayer(BookDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddBookToCart(int userId, int bookId)
        {
            string cartId = GetCartId(userId);
            int quantity = 1;

            CartItems existingCartItem = _dbContext.CartItems.FirstOrDefault(x => x.productID == bookId && x.cartID == cartId);

            if (existingCartItem != null)
            {
                existingCartItem.quantity += 1;
                _dbContext.Entry(existingCartItem).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            else
            {
                CartItems cartItems = new CartItems
                {
                    cartID = cartId,
                    productID = bookId,
                    quantity = quantity
                };
                _dbContext.CartItems.Add(cartItems);
                _dbContext.SaveChanges();
            }
        }

        public string GetCartId(int userId)
        {
            try
            {
                Cart cart = _dbContext.Cart.FirstOrDefault(x => x.userID == userId);

                if (cart != null)
                {
                    return cart.cartID;
                }
                else
                {
                    return CreateCart(userId);
                }

            }
            catch
            {
                throw;
            }
        }

        string CreateCart(int userId)
        {
            try
            {
                Cart shoppingCart = new Cart
                {
                    cartID = Guid.NewGuid().ToString(),
                    userID = userId,
                    createDate = DateTime.Now.Date
                };

                _dbContext.Cart.Add(shoppingCart);
                _dbContext.SaveChanges();

                return shoppingCart.cartID;
            }
            catch
            {
                throw;
            }
        }

        public void RemoveCartItem(int userId, int bookId)
        {
            try
            {
                string cartId = GetCartId(userId);
                CartItems cartItem = _dbContext.CartItems.FirstOrDefault(x => x.productID == bookId && x.cartID == cartId);

                _dbContext.CartItems.Remove(cartItem);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteOneCartItem(int userId, int bookId)
        {
            try
            {
                string cartId = GetCartId(userId);
                CartItems cartItem = _dbContext.CartItems.FirstOrDefault(x => x.productID == bookId && x.cartID == cartId);

                cartItem.quantity -= 1;
                _dbContext.Entry(cartItem).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public int GetCartItemCount(int userId)
        {
            string cartId = GetCartId(userId);

            if (!string.IsNullOrEmpty(cartId))
            {
                int cartItemCount = _dbContext.CartItems.Where(x => x.cartID == cartId).Sum(x => x.quantity);

                return cartItemCount;
            }
            else
            {
                return 0;
            }
        }

        public void MergeCart(int tempUserId, int permUserId)
        {
            try
            {
                if (tempUserId != permUserId && tempUserId > 0 && permUserId > 0)
                {
                    string tempCartId = GetCartId(tempUserId);
                    string permCartId = GetCartId(permUserId);

                    List<CartItems> tempCartItems = _dbContext.CartItems.Where(x => x.cartID == tempCartId).ToList();

                    foreach (CartItems item in tempCartItems)
                    {
                        CartItems cartItem = _dbContext.CartItems.FirstOrDefault(x => x.productID == item.productID && x.cartID == permCartId);

                        if (cartItem != null)
                        {
                            cartItem.quantity += item.quantity;
                            _dbContext.Entry(cartItem).State = EntityState.Modified;
                        }
                        else
                        {
                            CartItems newCartItem = new CartItems
                            {
                                cartID = permCartId,
                                productID = item.productID,
                                quantity = item.quantity
                            };
                            _dbContext.CartItems.Add(newCartItem);
                        }
                        _dbContext.CartItems.Remove(item);
                        _dbContext.SaveChanges();
                    }
                    DeleteCart(tempCartId);
                }
            }
            catch
            {
                throw;
            }
        }

        public int ClearCart(int userId)
        {
            try
            {
                string cartId = GetCartId(userId);
                List<CartItems> cartItem = _dbContext.CartItems.Where(x => x.cartID == cartId).ToList();

                if (!string.IsNullOrEmpty(cartId))
                {
                    foreach (CartItems item in cartItem)
                    {
                        _dbContext.CartItems.Remove(item);
                        _dbContext.SaveChanges();
                    }
                }
                return 0;
            }
            catch
            {
                throw;
            }
        }

        void DeleteCart(string cartId)
        {
            Cart cart = _dbContext.Cart.Find(cartId);
            _dbContext.Cart.Remove(cart);
            _dbContext.SaveChanges();
        }
    }
}
