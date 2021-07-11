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

                entity.Property(e => e.bookID).HasColumnName("BookID");

                entity.Property(e => e.autor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.category)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.coverFileName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.price).HasColumnType("decimal(10, 2)");

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
                entity.HasKey(e => e.cartItemID)
                    .HasName("PK__CartItem__488B0B0AA0297D1C");

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
                entity.HasKey(e => e.orderDetailsID)
                    .HasName("PK__Customer__9DD74DBD81D9221B");

                entity.Property(e => e.orderID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.price).HasColumnType("decimal(10, 2)");

            });

            #endregion

            #region Validaciones para las entidades clase: "CUSTOMERORDERS"

            modelBuilder.Entity<CustomerOrders>(entity =>
            {
                entity.HasKey(e => e.orderID)
                    .HasName("PK__Customer__C3905BCF96C8F1E7");

                entity.Property(e => e.orderID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.cartTotal).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.createDate).HasColumnType("datetime");

                entity.Property(e => e.userID).HasColumnName("UserID");

            });

            #endregion

            #region Validaciones para las entidades clase: "USERMASTER"

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.userID)
                    .HasName("PK__UserMast__1788CCAC2694A2ED");

                entity.Property(e => e.userID).HasColumnName("UserID");

                entity.Property(e => e.firstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.gender)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.lastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.password)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.userTypeID).HasColumnName("UserTypeID");

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
