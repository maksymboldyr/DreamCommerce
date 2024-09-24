using DataAccess.Entities;
using DataAccess.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ApplicationContext : IdentityDbContext<User, Role, string>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }

    DbSet<Category> Categories { get; set; }
    DbSet<Subcategory> Subcategories { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var adminRoleId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b";
        var shopRoleId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c";

        builder.Entity<Role>().HasData(
            new Role { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
            new Role { Id = shopRoleId, Name = "Shop", NormalizedName = "SHOP" }
        );

        var adminUser = new User
        {
            Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@mail.com",
            NormalizedEmail = "ADMIN@MAIL.COM",
            EmailConfirmed = true
        };

        adminUser.PasswordHash = new PasswordHasher<User>().HashPassword(adminUser, "admin");

        var shopUser = new User
        {
            Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
            UserName = "shop",
            NormalizedUserName = "SHOP",
            Email = "shop@mail.com",
            NormalizedEmail = "SHOP@MAIL.COM",
            EmailConfirmed = true
        };

        shopUser.PasswordHash = new PasswordHasher<User>().HashPassword(shopUser, "shop");

        var userUser = new User
        {
            Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
            UserName = "user",
            NormalizedUserName = "USER",
            Email = "user@mail.com",
            NormalizedEmail = "USER@MAIL.COM",
            EmailConfirmed = true
        };

        userUser.PasswordHash = new PasswordHasher<User>().HashPassword(userUser, "user");

        builder.Entity<User>().HasData(
            adminUser,
            shopUser,
            userUser
        );

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { RoleId = adminRoleId, UserId = adminUser.Id },
            new IdentityUserRole<string> { RoleId = shopRoleId, UserId = shopUser.Id }
        );


        base.OnModelCreating(builder);
    }
}
