using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixedProductTagRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsTags_Products_ProductId1",
                table: "ProductsTags");

            migrationBuilder.DropIndex(
                name: "IX_ProductsTags_ProductId1",
                table: "ProductsTags");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductsTags");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44f14dd2-167f-4ac2-8215-36d659e20316", "AQAAAAIAAYagAAAAELopeGsayqvpaRP9MCvkFmUhzi4olvpMWzHhdR3tq3V8307d6zA+6b8b7cIyu+cLzA==", "5ef3ac37-c65f-4319-b859-86281787b904" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5726645-fdb9-4a5e-ae34-da2ca95c178a", "AQAAAAIAAYagAAAAEFPuHbIlR3k5FAS31EdCoyrXGXJS5Y/FEzfL1DmauegBhSok536CVq45lKypBka4Lg==", "6a343bc0-7d4b-4ec1-bef4-d84e7c1e783a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55278a8f-07e5-4ccc-9ad1-baca91bba382", "AQAAAAIAAYagAAAAEMmCNw09nj2E4jmXpZKtzRstxDHz8WT3JUP2VmggMGo5A4Q4WV1SQZRG47FgRv5+uQ==", "b1688127-e345-4ba8-ab3b-a6e74691349a" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1e",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1f",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1g",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2276));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1h",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1i",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1j",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1k",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e10",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2341));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1l",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1m",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1n",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1o",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1p",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2329));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1q",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2330));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1r",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2331));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1s",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1t",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2332));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1u",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2333));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1v",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1w",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1x",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2337));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1y",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2338));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1z",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 2, 16, 1, 31, 230, DateTimeKind.Utc).AddTicks(2339));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductId1",
                table: "ProductsTags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3508e7bb-0934-411c-928a-689262b0b7e2", "AQAAAAIAAYagAAAAECHiHhfbBpN8gLbEne12r96YNxxPKzJ6HYE4S1IQ8t++mHRvEC1psPV2WJZ4JjWl7w==", "53f77762-8656-4fcb-a752-f3de758294c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4facfc26-c11d-4083-bc36-f74d29b7ac7e", "AQAAAAIAAYagAAAAEK0sb50CLgZRiUJGFYT3XldaZK03fSnA4ZyduArQU3SctwdHAVk0BwP9aN5VGpA4gQ==", "4c9c6438-0212-4745-a087-1650ad893d02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "842685a2-f072-44fa-bf3d-f8a0c4b0aedc", "AQAAAAIAAYagAAAAEPTfzyWoPMc8XCeOBXjvy6/kqSpHCFj3c0e2MW4F9jN5/3U6HD2JjNFxUENG1JZd1A==", "532dd77c-dc4f-480e-b189-e7f48e8ea3fe" });

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
                name: "IX_ProductsTags_ProductId1",
                table: "ProductsTags",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsTags_Products_ProductId1",
                table: "ProductsTags",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
