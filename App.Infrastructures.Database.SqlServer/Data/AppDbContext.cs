using App.Domain.Core.Entities;
using MarketPlace.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Database;

public partial class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApplicationUser> Users { get; set; }

    public virtual DbSet<Auction> Auctions { get; set; }

    public virtual DbSet<Bid> Bids { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Commission> Commissions { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductCategoryPhoto> ProductCategoryPhotos { get; set; }

    public virtual DbSet<ProductComment> ProductComments { get; set; }

    public virtual DbSet<ProductPhoto> ProductPhotos { get; set; }

    public virtual DbSet<ProductTag> ProductTags { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<StoreAddress> StoreAddresses { get; set; }

    public virtual DbSet<StoreComment> StoreComments { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TagCategory> TagCategories { get; set; }

    public virtual DbSet<Medal> Medals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(
            "Data Source=.;Initial Catalog=MarketPlace_DB;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Auction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Auction");

            entity.HasIndex(e => e.ProductId, "IX_Auctions_ProductId");

            entity.HasIndex(e => e.SellerId, "IX_Auctions_SellerId");

            entity.HasIndex(e => e.StoreId, "IX_Auctions_StoreId");

            entity.HasOne(d => d.Product).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Auctions_Products");

            entity.HasOne(d => d.Seller).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Auctions_AspNetUsers");

            entity.HasOne(d => d.Store).WithMany(p => p.Auctions)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Auctions_Stores");
        });

        modelBuilder.Entity<Bid>(entity =>
        {
            entity.HasIndex(e => e.AuctionId, "IX_Bids_AuctionId");

            entity.HasIndex(e => e.BuyerId, "IX_Bids_BuyerId");

            entity.HasOne(d => d.Auction).WithMany(p => p.Bids)
                .HasForeignKey(d => d.AuctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bids_Auctions");

            entity.HasOne(d => d.Buyer).WithMany(p => p.Bids)
                .HasForeignKey(d => d.BuyerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bids_AspNetUsers");
        });

        modelBuilder.Entity<Brand>(entity => { entity.Property(e => e.Name).HasMaxLength(150); });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Addresses");

            entity.Property(e => e.FullAddress).HasMaxLength(300);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomerAddresses_AspNetUsers");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasIndex(e => e.BrandId, "IX_Models_BrandId");

            entity.Property(e => e.Name).HasMaxLength(150);

            entity.HasOne(d => d.Brand).WithMany(p => p.Models)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Models_Brands");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_Orders_CustomerId");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderCustomers)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_AspNetUsers1");

            entity.HasOne(d => d.Commission).WithOne(p => p.Order)
                .HasForeignKey<Order>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Commissions");

            entity.HasOne(d => d.Seller).WithMany(p => p.OrderSellers)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_AspNetUsers");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasIndex(e => e.OrderId, "IX_OrderItems_OrderId");

            entity.HasIndex(e => e.ProductId, "IX_OrderItems_ProductId");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.BrandId, "IX_Products_BrandId");

            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

            entity.HasIndex(e => e.StoreId, "IX_Products_StoreId");

            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Brands");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Store).WithMany(p => p.Products)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Stores");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Categories");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<ProductCategoryPhoto>(entity =>
        {
            entity.HasOne(d => d.ProductCategory).WithMany(p => p.ProductCategoryPhotos)
                .HasForeignKey(d => d.ProductCategoryId).OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCategoryPhotos_ProductCategories");
            entity.Property(e => e.FileName).HasMaxLength(50);
        });

        modelBuilder.Entity<ProductComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Comments");

            entity.HasIndex(e => e.ProductId, "IX_ProductComments_ProductId");

            entity.HasIndex(e => e.UserId, "IX_ProductComments_UserId");

            entity.Property(e => e.CommentBody).HasMaxLength(1500);
            entity.Property(e => e.Title).HasMaxLength(300);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductComments)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductComments_Products1");

            entity.HasOne(d => d.User).WithMany(p => p.ProductComments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ProductComments_AspNetUsers");
        });

        modelBuilder.Entity<ProductPhoto>(entity =>
        {
            entity.HasIndex(e => e.ProductId, "IX_ProductPhotos_ProductId");

            entity.Property(e => e.FileName).HasMaxLength(50);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPhotos)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductPhotos_Products");
        });

        modelBuilder.Entity<ProductTag>(entity =>
        {
            entity.HasIndex(e => e.ProductId, "IX_ProductTags_ProductId");

            entity.HasIndex(e => e.TagId, "IX_ProductTags_TagId");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductTags)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductTags_Products");

            entity.HasOne(d => d.Tag).WithMany(p => p.ProductTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductTags_Tags");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasIndex(e => e.SellerId, "IX_Stores_SellerId");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(150);

            entity.HasOne(d => d.Seller).WithMany(p => p.Stores)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stores_AspNetUsers");
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Addresses");

            entity.Property(e => e.FullAddress).HasMaxLength(300);

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomerAddresses_AspNetUsers");
        });

        modelBuilder.Entity<StoreAddress>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(d => d.Store).WithMany(p => p.StoreAddresses)
                .HasForeignKey(d => d.StoreId)
                .HasConstraintName("FK_StoreAddresses_Stores1");

            entity.Property(e => e.FullAddress).HasMaxLength(300);
        });

        modelBuilder.Entity<StoreComment>(entity =>
        {
            entity.HasIndex(e => e.StoreId, "IX_StoreComments_StoreId");

            entity.HasIndex(e => e.UserId, "IX_StoreComments_UserId");

            entity.Property(e => e.CommentBody).HasMaxLength(1500);
            entity.Property(e => e.Title).HasMaxLength(300);

            entity.HasOne(d => d.Store).WithMany(p => p.StoreComments)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreComments_Stores");

            entity.HasOne(d => d.User).WithMany(p => p.StoreComments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreComments_AspNetUsers");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasIndex(e => e.TagCategoryId, "IX_Tags_TagCategoryId");

            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.TagCategory).WithMany(p => p.Tags)
                .HasForeignKey(d => d.TagCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tags_TagCategories");
        });

        modelBuilder.Entity<TagCategory>(entity => { entity.Property(e => e.Name).HasMaxLength(200); });

        modelBuilder.Entity<Medal>(entity =>
        {
            entity.HasKey(m => m.Id);

            entity.HasOne(m => m.Seller)
                .WithOne(s => s.Medal)
                .HasForeignKey<Medal>(m => m.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            //entity.HasOne(d => d.IdNavigation).WithOne(p => p.Medal)
            //    .HasForeignKey<Medal>(d => d.Id)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Medals_AspNetUsers1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}