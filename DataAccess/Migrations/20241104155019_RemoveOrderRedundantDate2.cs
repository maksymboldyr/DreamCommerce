using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOrderRedundantDate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7ee8cc9-db8a-4f6d-9269-f8afa593511e", "AQAAAAIAAYagAAAAEFKrtJfNM0B1t5gdoK3qLIZl6n+mH8zZN5txEhlxZJW6X3O723IZPY4tgXTPOtcn8w==", "202f8669-0a6c-480c-8337-841372097dd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a78e399-f2f1-4ebb-98af-b3128185f68c", "AQAAAAIAAYagAAAAECKNMwMm2GX22Zzi04s4C7hXnScG87qUO8u6ec5G3hYTZNilFchTVvSQSBChdB99fw==", "42dfcda7-1dc7-4dca-8cb5-01a1b429bede" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "459dd0cd-9970-45a7-9c52-24ffb60e3743", "AQAAAAIAAYagAAAAEDNokO3LLY31Crg3IRilTEafZqOX2KQtHZ0yq5MAbObZJKbG50BIthoSdQOqHRrleQ==", "8503224b-aa97-4476-a180-a9976d50ba70" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3908));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1e",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3914));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1f",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3915));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1g",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1h",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3916));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1i",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3917));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1j",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1k",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3919));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e10",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3975));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1l",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3963));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1m",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3964));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1n",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3965));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1o",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3966));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1p",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3967));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1q",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3968));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1r",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1s",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1t",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3970));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1u",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3971));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1v",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1w",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1x",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3973));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1y",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3974));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1z",
                column: "CreatedAt",
                value: new DateTime(2024, 11, 4, 15, 50, 19, 297, DateTimeKind.Utc).AddTicks(3975));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
    }
}
