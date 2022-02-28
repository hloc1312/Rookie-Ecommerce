using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.Data.Migrations
{
    public partial class Change_Property_Size_ProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Size",
                table: "ProductImages",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2022, 2, 28, 23, 27, 7, 952, DateTimeKind.Local).AddTicks(6199));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreate",
                value: new DateTime(2022, 2, 28, 23, 27, 7, 955, DateTimeKind.Local).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "a75ee85c-9f0e-4e29-b047-13f5c167bf39");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a5f27f2b-6b67-49b9-80d0-b8f8e1131a50", "AQAAAAEAACcQAAAAEAyKizdIniughkpH3Ty5inNvMpQ9ez0lAMDk+je/dlYJdG2MSSOpRx68IFFvPK1X7A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Size",
                table: "ProductImages",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2022, 2, 28, 15, 45, 44, 648, DateTimeKind.Local).AddTicks(6468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreate",
                value: new DateTime(2022, 2, 28, 15, 45, 44, 650, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "ee0bda68-a88c-476b-a980-df27199053e0");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c926a2c9-92b3-44cd-8c00-6f45a422973b", "AQAAAAEAACcQAAAAEGXrEDaPk7bjo7F6Yh5dDLT+gYIvtC0heEUUQcs9Jx0huJfghY8GXwFo3wlItREaFw==" });
        }
    }
}
