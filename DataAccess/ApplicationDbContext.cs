using DataAccess.Entities;
using DataAccess.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagValue> TagValues { get; set; }
        public DbSet<ProductTag> ProductsTags { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // both shop and user can have an address
            modelBuilder.Entity<Shop>()
                .HasOne(s => s.Address)
                .WithMany()
                .HasForeignKey(s => s.AddressId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithMany()
                .HasForeignKey(u => u.AddressId);

            modelBuilder.Entity<ProductTag>()
                .HasKey(pt => new { pt.ProductId, pt.TagId, pt.TagValueId });

            modelBuilder.Entity<ProductTag>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductsTags)
                .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.ProductTags)
                .HasForeignKey(pt => pt.TagId);

            modelBuilder.Entity<ProductTag>()
                .HasOne(pt => pt.TagValue)
                .WithMany(tv => tv.ProductTags)
                .HasForeignKey(pt => pt.TagValueId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Subcategory)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SubcategoryId);

            modelBuilder.Entity<Subcategory>()
                .HasMany(s => s.Products)
                .WithOne(p => p.Subcategory)
                .HasForeignKey(p => p.SubcategoryId);

            modelBuilder.Entity<Tag>()
                .HasOne(t => t.Subcategory)
                .WithMany(s => s.Tags)
                .HasForeignKey(t => t.SubcategoryId);

            modelBuilder.Entity<TagValue>()
                .HasOne(tv => tv.Tag)
                .WithMany(t => t.TagValues)
                .HasForeignKey(tv => tv.TagId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId);

            // Extension method to seed the database from DBSeeder class
            modelBuilder.SeedDatabase();
        }
    }
}