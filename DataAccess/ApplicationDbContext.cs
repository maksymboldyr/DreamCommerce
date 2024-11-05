using DataAccess.Entities;
using DataAccess.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    /// <summary>
    /// Class that represents the database context. Inherits from <see cref="IdentityDbContext"/> to use the Identity framework.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<User, Role, string>
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ApplicationDbContext"></see> class.
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #region DbSet properties
        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of <see cref="User"/> entities.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of <see cref="Role"/> entities.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of <see cref="Category"/> entities.
        /// </summary>
        public DbSet<Subcategory> Subcategories { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of <see cref="Tag"/> entities.
        /// </summary>
        public DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of <see cref="TagValue"/> entities.
        /// </summary>
        public DbSet<TagValue> TagValues { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of <see cref="ProductTag"/> entities.
        /// </summary>
        public DbSet<ProductTag> ProductsTags { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of <see cref="Order"/> entities.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of <see cref="OrderDetail"/> entities.
        /// </summary>
        public DbSet<OrderDetail> OrderDetails { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of <see cref="Shop"/> entities.
        /// </summary>
        public DbSet<Shop> Shop { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of <see cref="Address"/> entities.
        /// </summary>
        public DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of <see cref="Cart"/> entities.
        /// </summary>
        public DbSet<Cart> Carts { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> of <see cref="CartItem"/> entities.
        /// </summary>
        public DbSet<CartItem> CartItems { get; set; }
        #endregion

        /// <summary>
        /// Method that is called when the model for a derived context has been initialized, 
        /// but before the model has been locked down and used to initialize the context.
        /// Sets the relationships between the entities and uses the <see cref="DBSeeder.SeedDatabase(ModelBuilder)"/> extension method to seed the database.
        /// </summary>
        /// <seealso cref="DBSeeder"/>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region relationships configuration
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

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Address)
                .WithMany()
                .HasForeignKey(o => o.AddressId);

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

            modelBuilder.Entity<Cart>()
                .Navigation(c => c.CartItems)
                .AutoInclude();

            modelBuilder.Entity<CartItem>()
                .Navigation(ci => ci.Product)
                .AutoInclude();
            #endregion

            modelBuilder.SeedDatabase();
        }
    }
}
