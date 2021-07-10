using Microsoft.EntityFrameworkCore;

namespace BookCart.Models
{
    public partial class BookDBContext : DbContext
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

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

            #region Validaciones para las entidades clase: "CATEGORY"

            modelBuilder.Entity<Category>(entity =>
            {
                //1.-
                entity.Property(e => e.categoryID)
                 .HasColumnName("PK__Categori__1924578692DVBR23");

                //2.-
                entity.Property(e => e.categoryID).HasColumnName("CategoryID");

                //3.-
                entity.Property(e => e.categoryName)
                 .IsRequired()
                 .HasMaxLength(20)
                 .IsUnicode(false);

            });

            #endregion

            #region Validaciones para las entidades clase: "CUSTOMERORDERDETAIL"

            modelBuilder.Entity<CustomerOrderDetails>(entity =>
            {
                //1.-
                entity.Property(e => e.orderDetailsID)
                 .HasColumnName("PK__Customer_9DD74DBD221B");

                //2.-
                entity.Property(e => e.orderID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                //3.-
                entity.Property(e => e.price).HasColumnType("decimal(10, 2)");

            });

            #endregion

            #region Validaciones para las entidades clase: "CUSTOMERORDERS"

            modelBuilder.Entity<CustomerOrders>(entity =>
            {
                //1.-
                entity.Property(e => e.orderID)
                 .HasColumnName("PK__Customer_C359FJDLKSE2");

                //2.-
                entity.Property(e => e.orderID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                //3.-
                entity.Property(e => e.cartTotal).HasColumnType("decimal(10, 2)");

                //4.-
                entity.Property(e => e.createDate).HasColumnType("datetime");

                //5.-
                entity.Property(e => e.userID).HasColumnName("UserID");

            });

            #endregion

            #region Validaciones para las entidades clase: "USERMASTER"

            modelBuilder.Entity<UserMaster>(entity =>
            {
                //1.-
                entity.Property(e => e.userID)
                 .HasColumnName("PK__UserMast__174820DGN89F");

                //2.-
                entity.Property(e => e.userID).HasColumnName("UserID");

                //3.-
                entity.Property(e => e.firstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                //4.-
                entity.Property(e => e.gender)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                //5.-
                entity.Property(e => e.lastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                //6.-
                entity.Property(e => e.password)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                //7.-
                entity.Property(e => e.userTypeID).HasColumnName("UserType");

                //8.-
                entity.Property(e => e.userName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

            });

            #endregion

            #region Validaciones para las entidades clase: "USERTYPE"

            modelBuilder.Entity<UserType>(entity =>
            {
                //1.-
                entity.Property(e => e.userTypeID)
                 .HasColumnName("UserTypeID");

                //2.-
                entity.Property(e => e.userTypeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

            });

            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
