using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
                columns: new[] { "Address", "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "4944151a-f411-47ee-a9e6-ef60379dc860", null, null, "AQAAAAIAAYagAAAAEAWZUFV53O2goFutstAf1ZLVWXHAv4H6Sf7qMo394xM1l+FudWgfzgGNKWeILmCnwg==", "9ca3d337-033f-4fb2-b1f9-c9320f6b2d83" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                columns: new[] { "Address", "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "362295c4-8739-401f-922e-e0a862ad385f", null, null, "AQAAAAIAAYagAAAAEKTly583ivg44AAzpFlzLrGK6odzTS+LEh04BW+f8Du1PaEl2wgJIfuK8Dn+SoqEsA==", "16126a9a-6734-40d0-963c-18b08f53d09a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                columns: new[] { "Address", "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "aff05769-8996-4396-ad69-3582d68eda1e", null, null, "AQAAAAIAAYagAAAAEPUDIlqIlgW8PQdlp49YCde9EXiGbVJyT5miQBcs53/2UPUyb4Ii5kW+iq+BkcEm3g==", "87cc1dd8-ad34-4e4c-8b8c-6dfe5865475c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9958fd7-8eb3-45c8-bb4f-d451c9684632", "AQAAAAIAAYagAAAAEPIHMKbsgDR0k6YneuiUgnNlOvsPxmFtdEFjSqD2NaCzEPhdJ6qhezncarntxreyZQ==", "f9415532-6109-458c-966d-ac8f425976ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a282e4ef-6d73-4174-91bd-c1d6e4ce43e2", "AQAAAAIAAYagAAAAEIL1EAwRlpNRkRVMMtLvcxYHaQFE/buZmfBCSpfcBhFHklMAHuk7QVbs+7iQ00vXAg==", "04fc6987-0b69-4bc7-96dc-85d3d302d471" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe951288-696f-467a-b141-db37b52aa486", "AQAAAAIAAYagAAAAELRz9ZjyN4Jjhzg7Gjtq2a+AjAhwa4zi0MMbBSIULAOvEPjVj0o7z2iqB1vRDAtNzg==", "ba456f35-e061-4d04-95c5-2bab6140b934" });
        }
    }
}
