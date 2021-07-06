using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCart.Models
{
    public class BookDBContext : DbContext
    {
        public BookDBContext()
        { 
        
        }

        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        { 
        
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartItems> CartItems { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CustomerOrderDetails> CustomerOrderDetails { get; set; }
        public virtual DbSet<CustomerOrders> CustomerOrders { get; set; }
        public virtual DbSet<UserMaster> UserMaster { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected internal virtual void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
        
        }
        protected internal virtual void OnModelCreating(ModelBuilder modelBuilder) {

            #region Validaciones para las entidades clase: "BOOK"
            
            modelBuilder.Entity<Book>(entity =>
            {

                //1.-
                entity.Property(e => e.bookID).HasColumnName("BookID");

                //2.-
                entity.Property(e => e.autor)
                .HasMaxLength(100)
                .IsUnicode(false);

                //3.-
                entity.Property(e => e.category)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

                //4.-
                entity.Property(e => e.coverFileName)
                .HasMaxLength(100)
                .IsUnicode(false);

                //5.-
                entity.Property(e => e.price).HasColumnName("decimal(10, 2)");

                //6.-
                entity.Property(e => e.title)
                .HasMaxLength(100)
                .IsUnicode(false);

            });

            #endregion

            #region Validaciones para las entidades clase: "CART"

            modelBuilder.Entity<Cart>(entity =>
            {
                //1.-
                entity.Property(e => e.cartID)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                //2.-
                entity.Property(e => e.createDate)
                .HasColumnName("datetime");

                //3.-
                entity.Property(e => e.userID).HasColumnName("UserID");
            });

            #endregion

            #region Validaciones para las entidades clase: "CARTITEMS"

            modelBuilder.Entity<CartItems>(entity =>
            {
                //1.-
                entity.Property(e => e.cartItemID)
                 .HasColumnName("PK__CartItem__488B0B000123332D1C");

                //2.-
                entity.Property(e => e.cartID)
                 .IsRequired()
                 .HasMaxLength(36)
                 .IsUnicode(false);

            });

            #endregion

        }
    }
}
