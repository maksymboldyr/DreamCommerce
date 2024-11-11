using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixedAddressModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Addresses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87698f6a-e278-4442-a8fd-a351e02f2060", "AQAAAAIAAYagAAAAECwft2rKUvo7+7acKUmH9KgTrcWxmrlgR6ysbimulymeLiSg5s6CLppqXQEVZw3vMw==", "89cd84a8-81a2-412a-a268-3299a24ca7b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a56dca13-ed19-4673-91a3-b4c18e1bd8c3", "AQAAAAIAAYagAAAAEGP5CNrdKNyw/PF0Q8TFsFDyaRHc16cLr0RVwinhYeqx7kJidbVaRpP0IyQD2T0ORw==", "cf3a0a43-a43f-4f0a-9b54-84937a9091d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea4bf3a9-e7fb-4ecd-9cfe-2df13283e9d1", "AQAAAAIAAYagAAAAELivCrUZ5lS1Os82rC0+FKeA7D4lwS5vMnbik/GKPjnPBfjLix90o49kcRB9+W4PvA==", "d6c74335-613f-489e-a4ea-8070f345bba6" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3674));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1e",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3681));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1f",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3682));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1g",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1h",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3683));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1i",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3684));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1j",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3685));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1k",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3685));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e10",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3746));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1l",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3734));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1m",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3736));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1n",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3736));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1o",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3737));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1p",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3738));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1q",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3739));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1r",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3739));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1s",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1t",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3741));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1u",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3742));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1v",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3742));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1w",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1x",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3744));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1y",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3745));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1z",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 17, 13, 50, 385, DateTimeKind.Utc).AddTicks(3745));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Addresses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7328041c-9141-4a38-bc46-e6a672490680", "AQAAAAIAAYagAAAAEJt9TtF12APH3mxYy0wPUFRu2iaKD8L2YVUNVo4XAW/OXzG7o+in28FHRC3Y0B5WCA==", "2d540a34-816c-4fbc-a24b-71b0f9dfc225" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e327cdf-89ca-478f-91af-b86f456f0610", "AQAAAAIAAYagAAAAEIiPqJnuu/vRznnGocX0GdyuzqQ7YskJisATVlSOzVrKPjUzjBE6z69RndcxxGwH+w==", "192ce041-cd4e-4f8d-90c9-dd2f2feb5c60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bea5258-c2b8-4378-be35-f5ecb13b2de8", "AQAAAAIAAYagAAAAEHF+sMO5Bfwa6GCtEudnP7+d9wqr10avd+LbVf2yy+DZxITFuzcBCDDbxEh7kq1JXg==", "ca784f32-510d-4845-8e69-2920ddfc1aaf" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(2968));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1e",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(2973));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1f",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1g",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3030));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1h",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1i",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1j",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1k",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3033));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e10",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1l",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1m",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3081));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1n",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3083));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1o",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3083));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1p",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1q",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3085));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1r",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3086));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1s",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3087));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1t",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3088));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1u",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3089));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1v",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3089));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1w",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3090));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1x",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3091));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1y",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3092));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1z",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 8, 16, 49, 40, 792, DateTimeKind.Utc).AddTicks(3093));
        }
    }
}
