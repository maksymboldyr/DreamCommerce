using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ShopId",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    AddressId = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shop_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shop_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
                columns: new[] { "AddressId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "3508e7bb-0934-411c-928a-689262b0b7e2", "AQAAAAIAAYagAAAAECHiHhfbBpN8gLbEne12r96YNxxPKzJ6HYE4S1IQ8t++mHRvEC1psPV2WJZ4JjWl7w==", "53f77762-8656-4fcb-a752-f3de758294c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                columns: new[] { "AddressId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "4facfc26-c11d-4083-bc36-f74d29b7ac7e", "AQAAAAIAAYagAAAAEK0sb50CLgZRiUJGFYT3XldaZK03fSnA4ZyduArQU3SctwdHAVk0BwP9aN5VGpA4gQ==", "4c9c6438-0212-4745-a087-1650ad893d02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                columns: new[] { "AddressId", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "842685a2-f072-44fa-bf3d-f8a0c4b0aedc", "AQAAAAIAAYagAAAAEPTfzyWoPMc8XCeOBXjvy6/kqSpHCFj3c0e2MW4F9jN5/3U6HD2JjNFxUENG1JZd1A==", "532dd77c-dc4f-480e-b189-e7f48e8ea3fe" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1e",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3894));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1f",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3894));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1g",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3895));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1h",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3896));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1i",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1j",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1k",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3898));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e10",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3955));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1l",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3942));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1m",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3943));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1n",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1o",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3945));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1p",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3946));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1q",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3946));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1r",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3947));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1s",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3948));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1t",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3949));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1u",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3949));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1v",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3950));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1w",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3951));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1x",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3951));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1y",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3952));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1z",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 57, 35, 659, DateTimeKind.Utc).AddTicks(3953));

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShopId",
                table: "Products",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_AddressId",
                table: "Shop",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_UserId",
                table: "Shop",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Shop_ShopId",
                table: "Products",
                column: "ShopId",
                principalTable: "Shop",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresses_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Shop_ShopId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShopId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
                columns: new[] { "Address", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "d079cbe2-77f9-449a-a67a-0fed4c4d5344", "AQAAAAIAAYagAAAAEO+jxsg1o0qz4j/l0VHxAgW4iW+EPNUYpoBx4fQyrhal/w7pUinc62f+NpjvkUAhow==", "493eb19d-df02-43a0-ba08-62cc21d3e859" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                columns: new[] { "Address", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "81ce2e9b-ca90-4b10-972c-14e92e0e8b7c", "AQAAAAIAAYagAAAAEGyENz4IWHwrMkIdHLqXUYr4wyNgsezi52SA+Vk8v2VxLEtLW0iZizJJ5WrkswzeyQ==", "8c2b9711-67e8-4f45-a8c6-c1d1d3141843" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                columns: new[] { "Address", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "c2a85be5-235d-4909-a2d8-8873c3527dcf", "AQAAAAIAAYagAAAAEFIry1BWsuP12855Q36240uWNcc6mVUoMz1w0DONt8xwjULeb4kJapa6Hr6bbDV0Wg==", "c60f4305-001d-4ac0-b20c-1e90c03531c8" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1e",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1548));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1f",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1549));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1g",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1h",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1551));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1i",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1552));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1j",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1k",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1553));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e10",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1l",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1635));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1m",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1636));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1n",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1o",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1638));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1p",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1639));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1q",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1r",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1s",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1642));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1t",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1643));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1u",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1v",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1w",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1645));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1x",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1y",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1z",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 15, 43, 26, 752, DateTimeKind.Utc).AddTicks(1648));
        }
    }
}
