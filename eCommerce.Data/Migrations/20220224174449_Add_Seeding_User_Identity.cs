using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.Data.Migrations
{
    public partial class Add_Seeding_User_Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 25, 0, 44, 47, 881, DateTimeKind.Local).AddTicks(1395),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 25, 0, 27, 17, 263, DateTimeKind.Local).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2022, 2, 25, 0, 44, 47, 910, DateTimeKind.Local).AddTicks(2357));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreate",
                value: new DateTime(2022, 2, 25, 0, 44, 47, 910, DateTimeKind.Local).AddTicks(8016));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "4930c2a6-3906-4560-b589-03b6641c81b3", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "1cf6448e-5ad1-4345-9c94-684996e52bb1", "hloc878@gmail.com", true, "Nguyen", "Loc", false, null, "hloc878@gmail.com", "admin", "AQAAAAEAACcQAAAAEBAuzHzRwKiwj9P3XCWjBFSX3GK/qoDzFWfNiZPa3POoDsy6iS83kElPmfKu69QUoA==", null, false, "", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 25, 0, 27, 17, 263, DateTimeKind.Local).AddTicks(9372),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 25, 0, 44, 47, 881, DateTimeKind.Local).AddTicks(1395));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2022, 2, 25, 0, 27, 17, 286, DateTimeKind.Local).AddTicks(5283));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreate",
                value: new DateTime(2022, 2, 25, 0, 27, 17, 287, DateTimeKind.Local).AddTicks(586));
        }
    }
}
