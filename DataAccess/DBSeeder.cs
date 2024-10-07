using DataAccess.Entities;
using DataAccess.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public static class DBSeeder
    {
        public static void SeedDatabase(this ModelBuilder builder)
        {
            SeedUsersWithRoles(builder);
            SeedCategories(builder);
            SeedSubcategories(builder);
        }

        private static void SeedUsersWithRoles(ModelBuilder builder)
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
        }
        
        private static void SeedCategories(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d", Name = "Electronics" },
                new Category { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1e", Name = "Clothing" },
                new Category { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1f", Name = "Books" },
                new Category { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1g", Name = "Furniture" },
                new Category { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1h", Name = "Toys" },
                new Category { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1i", Name = "Tools" },
                new Category { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1j", Name = "Sports" },
                new Category { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1k", Name = "Music" }
            );
        }

        private static void SeedSubcategories(ModelBuilder builder)
        {
            builder.Entity<Subcategory>().HasData(
                new Subcategory { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1l", Name = "Smartphones", CategoryId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d" },
                new Subcategory { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1m", Name = "Laptops", CategoryId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d" },
                new Subcategory { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1n", Name = "T-Shirts", CategoryId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1e" },
                new Subcategory { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1o", Name = "Jeans", CategoryId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1e" },
                new Subcategory { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1p", Name = "Fantasy", CategoryId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1f" },
                new Subcategory { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1q", Name = "Science Fiction", CategoryId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1f" },
                new Subcategory { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1r", Name = "Sofas", CategoryId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1g" },
                new Subcategory { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1s", Name = "Beds", CategoryId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1g" },
                new Subcategory { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1t", Name = "Cars", CategoryId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1h" },
                new Subcategory { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1u", Name = "Dinosaurs", CategoryId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1h" },
                new Subcategory { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1v", Name = "Drills", CategoryId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1i" },
                new Subcategory { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1w", Name = "Screwdrivers", CategoryId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1i" },
                new Subcategory { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1x", Name = "Football", CategoryId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1j" },
                new Subcategory { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1y", Name = "Basketball", CategoryId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1j" },
                new Subcategory { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1z", Name = "Guitars", CategoryId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1k" },
                new Subcategory { Id = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e10", Name = "Drums", CategoryId = "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1k" }
                );
        }
    }
}
