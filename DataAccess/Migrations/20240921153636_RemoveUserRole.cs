using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cb18f2a-ca77-4234-a2bc-88229cb2a236", "AQAAAAIAAYagAAAAEI62KVjh3THJjNsf+DqS4y65ZZ4m4+yD1W3DvBMHnSV0GcOUq416l/t9AOHjLpeKfQ==", "909d3017-0a52-438f-b8ba-9744ab982ba7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f04c50a-b598-4754-b5c3-db25905e0ad3", "AQAAAAIAAYagAAAAEPsqLBCeFya+GzJuhtoYE/YSreDVva3yo45NSHCOO9DTwNvDoZmuW4OuUeqWBqN3xQ==", "1f49b839-5623-4760-8a6c-4bb72223908b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5357fe43-ebce-4323-855c-88e98f3a8f88", "AQAAAAIAAYagAAAAEN1Ni8DTwgDwk57V+sG38hJlrZ3aZC/6gOSHru4K3j8zzFnEmv6Bso7IfALCVqfBng==", "9ead66c5-778b-4e16-8138-e9916c070e97" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d", null, null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4944151a-f411-47ee-a9e6-ef60379dc860", "AQAAAAIAAYagAAAAEAWZUFV53O2goFutstAf1ZLVWXHAv4H6Sf7qMo394xM1l+FudWgfzgGNKWeILmCnwg==", "9ca3d337-033f-4fb2-b1f9-c9320f6b2d83" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "362295c4-8739-401f-922e-e0a862ad385f", "AQAAAAIAAYagAAAAEKTly583ivg44AAzpFlzLrGK6odzTS+LEh04BW+f8Du1PaEl2wgJIfuK8Dn+SoqEsA==", "16126a9a-6734-40d0-963c-18b08f53d09a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aff05769-8996-4396-ad69-3582d68eda1e", "AQAAAAIAAYagAAAAEPUDIlqIlgW8PQdlp49YCde9EXiGbVJyT5miQBcs53/2UPUyb4Ii5kW+iq+BkcEm3g==", "87cc1dd8-ad34-4e4c-8b8c-6dfe5865475c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c" });
        }
    }
}
