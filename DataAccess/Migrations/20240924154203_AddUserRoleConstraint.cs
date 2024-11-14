using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRoleConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AspNetRoles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RoleId", "SecurityStamp" },
                values: new object[] { "a08b82b9-dcb4-4abb-9ec1-74fcb0974eb2", "AQAAAAIAAYagAAAAEFoCXPywNl7B0zRidkvNi6DzdBm9T0zTIItIYHd2AzMXYrzj+g5vucg0T4C/LfrR7w==", null, "e615d05e-e79a-40bb-a838-4e5967681d0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RoleId", "SecurityStamp" },
                values: new object[] { "a118f855-bde0-44b0-9998-a20cbc1c8838", "AQAAAAIAAYagAAAAENF+wWYVkh5DitpfXc4Likt/ndZrtBDrzfVVxeQUEwCOiy7JAhy8S2xwAKDxN4EpiQ==", null, "8530bea7-a704-4f2f-b0b2-52d0379aa7d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RoleId", "SecurityStamp" },
                values: new object[] { "b6e1bf6b-3e2d-47c9-a3fe-84d2bad21ce3", "AQAAAAIAAYagAAAAEH+0Wh0DG0aOoDot2r48GMIecm9o/5lwaY1JOY09v6pevPWppl2vsX8+EANk7UZJoQ==", null, "5946ce33-a449-4a34-ba91-f698f4eeb29a" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_UserId",
                table: "AspNetRoles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UserId",
                table: "AspNetRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_AspNetUsers_UserId",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_UserId",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetRoles");

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
    }
}
