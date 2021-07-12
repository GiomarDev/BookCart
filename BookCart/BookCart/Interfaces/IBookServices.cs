using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCart.Models;

namespace BookCart.Interfaces
{
    public interface IBookServices
    {
        List<Book> GetAllBooks();
        
        int addBook(Book book);
        
        int updateBook(Book book);

        Book GetBookData(int bookID);

        string DeleteBook(int bookID);

        List<Category> GetCategories();

        List<Book> GetSimilarBooks(int bookID);
    }
}
