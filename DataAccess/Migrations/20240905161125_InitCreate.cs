using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b", null, null, "Admin", "ADMIN" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c", null, null, "Shop", "SHOP" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d", null, null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a", 0, "7e4b44eb-097d-451f-bc7f-0b9b867aeb2c", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEMXMvXOMEOPWjhDvASqpsYjxW6WFtMTorY1dz1cKX3FImAssfp0My1oU/XY1Uy7g1g==", null, false, "00981300-f8b3-4d01-bb05-c8b2b4e6cf97", false, "admin" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b", 0, "e459beea-1fe0-42d0-9937-652c7a418011", "shop@mail.com", true, false, null, "SHOP@MAIL.COM", "SHOP", "AQAAAAIAAYagAAAAEA+7rv7sb/O2oVqGrda36rmhLeXyIXfDgj3SnwF783i12I85xcieYzGKSub99AY50w==", null, false, "8f521c4e-4977-4490-838c-9f4a7f622c3f", false, "shop" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c", 0, "b54d31e2-1dfe-4874-850c-6812890c28fe", "user@mail.com", true, false, null, "USER@MAIL.COM", "USER", "AQAAAAIAAYagAAAAEKxiycF5I72V2+LSyMpihnB4f460YNESbreh4ucImmH6rd9kiXcC5CxSUlimnwsWrQ==", null, false, "ec48be93-bea6-457d-8ccc-04cc526b7996", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b" },
                    { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d", "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");
        }
    }
}
