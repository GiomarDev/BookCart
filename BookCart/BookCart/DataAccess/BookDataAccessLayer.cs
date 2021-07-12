using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCart.Interfaces;
using BookCart.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCart.DataAccess
{
    public class BookDataAccessLayer : IBookServices
    {
        //Inyectado
        readonly BookDBContext _dbContext;
        public BookDataAccessLayer(BookDBContext dBContext)
        {
            _dbContext = dBContext;
        }


        //Finish
        public int addBook(Book book)
        {
            try
            {
                _dbContext.Book.Add(book);
                _dbContext.SaveChanges();

                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Finish
        public string DeleteBook(int bookID)
        {
            try
            {
                Book book = _dbContext.Book.Find(bookID);
                _dbContext.Book.Remove(book);
                _dbContext.SaveChanges();

                return (book.coverFileName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Finish
        public List<Book> GetAllBooks()
        {
            try
            {
                return _dbContext.Book.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Finish
        public Book GetBookData(int bookID)
        {
            try
            {
                Book book = _dbContext.Book.FirstOrDefault(x => x.bookID == bookID);
                if (book != null)
                {
                    _dbContext.Entry(book).State = EntityState.Detached;
                    return book;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Finish
        public List<Category> GetCategories()
        {
            try
            {
                List<Category> lstCategories = new List<Category>();
                lstCategories = (from CategoriesList in _dbContext.Category select CategoriesList).ToList();
                return lstCategories;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Finish
        public List<Book> GetSimilarBooks(int bookID)
        {
            try
            {
                List<Book> lstBook = new List<Book>();
                Book book = GetBookData(bookID);

                lstBook = _dbContext.Book.Where(x => x.category == book.category && x.bookID != book.bookID)
                    .OrderBy(u => Guid.NewGuid())
                    .Take(5)
                    .ToList();

                return lstBook;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Finish
        public int updateBook(Book book)
        {
            try
            {
                Book oldBookData = GetBookData(book.bookID);

                if (oldBookData.coverFileName != null)
                {
                    if (book.coverFileName == null)
                    {
                        book.coverFileName = oldBookData.coverFileName;
                    }
                }

                _dbContext.Entry(book).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
