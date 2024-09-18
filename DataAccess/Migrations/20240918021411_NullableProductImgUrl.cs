using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NullableProductImgUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e89cb386-9bf0-4259-831e-76591f2c0fc3", "AQAAAAIAAYagAAAAEG2YzTifsc+dQUBZKOQ17MGUSUKgbKaGXqrLwvSFWUI0wpRyLaBmIh00k8byfTe5wA==", "443b1306-6b42-48b1-a097-fcc82ded6fe8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d738fe05-a240-4fbe-9674-09f2d6dd585e", "AQAAAAIAAYagAAAAECRxJ4QD2qAxu8N31mejRteF0JJ3Mp20LdmKwUCP00Yee0ECjzCaCaKPAMIqz15/pg==", "7d60e933-0df8-4598-9dd1-ec195ae37a4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1b0b3f4-3b1b-4b7e-8f1d-3e0b6e1d6e1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49a935d1-7fc5-4632-8052-8e45cb7e1649", "AQAAAAIAAYagAAAAELb5KiK1CyJ/dPNzVaLIS+cU6wjIQWgHIw/EC67s2/BzaNZTL+JSTvi8ZyOLm7fxhA==", "22f1948e-f0bc-4288-a72b-5709956aa376" });
        }
    }
}
