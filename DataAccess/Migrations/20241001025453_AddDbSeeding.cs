using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e790b5ec-33f1-4577-a749-dee4bbfc6ad6", "AQAAAAIAAYagAAAAEAVUjtRAi74ijyIwjlcEGUSi5W7gBEcSdxYfuc13m+AxRHggcl1dcECQsyjGPgo/hg==", "9d6d1de9-481a-4063-99f2-5a0541c50bd3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acab0947-6d71-4d39-aa62-9d22a9addc6e", "AQAAAAIAAYagAAAAELe/K/tkf3WXY+UnQDx66ExLAAmgfuO6eGE6exbgax7oRWQ6UJw/R0ZrlmAiiybS9Q==", "0fdceace-1997-43a2-9876-679e9143f789" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da760f73-3cdd-4d53-96c0-bfeedaa60fc5", "AQAAAAIAAYagAAAAEFAYkqypxmduCnqb6+QjnPGFp6O8rd7nERIgCY8OFWOSWKxrOIKrh7jjXEn1L/vMhQ==", "ac25d2ab-4bae-40dc-b21a-f2cb6febad92" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d", "Electronics" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1e", "Clothing" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1f", "Books" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1g", "Furniture" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1h", "Toys" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1i", "Tools" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1j", "Sports" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1k", "Music" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e10", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1k", "Drums" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1l", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d", "Smartphones" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1m", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d", "Laptops" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1n", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1e", "T-Shirts" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1o", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1e", "Jeans" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1p", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1f", "Fantasy" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1q", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1f", "Science Fiction" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1r", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1g", "Sofas" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1s", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1g", "Beds" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1t", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1h", "Cars" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1u", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1h", "Dinosaurs" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1v", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1i", "Drills" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1w", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1i", "Screwdrivers" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1x", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1j", "Football" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1y", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1j", "Basketball" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1z", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1k", "Guitars" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e10");

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1l");

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1m");

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1n");

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1o");

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1p");

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1q");

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1r");

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1s");

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1t");

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1u");

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1v");

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1w");

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1x");

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1y");

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1z");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1e");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1f");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1g");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1h");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1i");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1j");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1k");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d1eb66e-cbd3-422f-846f-291e13734cdf", "AQAAAAIAAYagAAAAECHrW0Ttxhajdo24fWAounmPamiHR68R3pJiSf2olu1TGpH8mo7O8EKJrY1+q90qmA==", "db93fde0-d11d-4266-9d3c-5f65efb7e7e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "328a8aea-9b1e-4ab5-9640-80fc271d5be5", "AQAAAAIAAYagAAAAEC1qozluv3TyfjvD/2G6RaCzy0MqU6WZ3RZuFuzkP94OF25MEGUpppBg72x2rCqhqw==", "07c66b7f-1990-4c4b-abae-293fe03553b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3006f225-b6c5-4d43-af65-adceab1ea7d6", "AQAAAAIAAYagAAAAEAicGEmQVy5UiGna2QIxlR1A06TgVYX005b+GPBiKU3CsM/9+W1XTNi2kks2SlkE2Q==", "ccd4b725-4652-40d1-8470-deec6f043ea7" });
        }
    }
}
