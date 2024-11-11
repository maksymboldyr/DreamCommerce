using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOrderRedundantDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff74374b-afdd-4387-8615-764ed647cba7", "AQAAAAIAAYagAAAAEBdrhkKipBljtk4EMsv2vpSzEyTDoP0i8uohpVqxcuXOxaztNl3aJggzCpQEUvVyWQ==", "eea31642-a1d4-41f6-8f49-1d30fe0bde96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "744ca275-cdf0-48d0-a957-7464ec734b76", "AQAAAAIAAYagAAAAEPfKhjI/U6zapjVJrcty/8JTsyeuA3vg14YTfnhuSwlCE1RYKQRcbo6b+KUzgYd4RQ==", "d8c2e113-763e-4878-a3c4-eec53fd94b7d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de95e3f3-c34b-4df3-8869-b4940a35ede9", "AQAAAAIAAYagAAAAEBkuY2y57Ww3aFukqx0kgKTSQKEYiptQrZZfvr/x49TQgnIeX1UxV8REEn1yDgrWTg==", "580f4baf-7145-4b98-94d0-ec781352297a" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(4800));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1e",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1f",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1g",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(4806));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1h",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(4807));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1i",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(4808));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1j",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(4809));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1k",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(4810));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e10",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1l",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(5084));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1m",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(5086));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1n",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1o",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(5088));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1p",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(5089));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1q",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1r",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(5091));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1s",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(5093));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1t",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1u",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(5095));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1v",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1w",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(5097));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1x",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(5098));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1y",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1z",
                column: "CreatedAt",
                value: new DateTime(2024, 10, 29, 15, 19, 8, 468, DateTimeKind.Utc).AddTicks(5101));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
