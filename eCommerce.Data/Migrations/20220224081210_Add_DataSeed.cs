using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.Data.Migrations
{
    public partial class Add_DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 24, 15, 12, 10, 74, DateTimeKind.Local).AddTicks(8754),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 24, 14, 39, 54, 220, DateTimeKind.Local).AddTicks(394));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsShowOnHome", "Name", "ParentId", "SeoAlias", "SeoDescription", "SeoTitle", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, true, "Áo Thun Nam", null, "ao-thun-nam", "Áo Thun Thời Trang Dành Cho Nam", "Áo Thun Nam", 1, 1 },
                    { 2, true, "Áo Nữ", null, "ao-nu", "Áo Thời Trang Dành Cho Nữ", "Áo Nữ", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreate", "DateUpdate", "Description", "Details", "Name", "OriginalPrice", "Price", "SeoAlias", "SeoDescription", "SeoTitle" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 24, 15, 12, 10, 91, DateTimeKind.Local).AddTicks(4673), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Áo thun nam cá sấu", "Áo thun nam cá sấu", "Áo Thun Nam Cá Sấu", 100000m, 200000m, "ao-thun-nam", "Áo Thun Thời Trang Dành Cho Nam", "Áo Thun Nam" },
                    { 2, new DateTime(2022, 2, 24, 15, 12, 10, 91, DateTimeKind.Local).AddTicks(9828), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Áo nữ", "Áo nữ", "Áo Nữ", 50000m, 150000m, "ao-nu", "Áo Thời Trang Dành Cho Nữ", "Áo Nữ" }
                });

            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[] { 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 2, 24, 14, 39, 54, 220, DateTimeKind.Local).AddTicks(394),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 2, 24, 15, 12, 10, 74, DateTimeKind.Local).AddTicks(8754));
        }
    }
}
