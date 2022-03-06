using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.Data.Migrations
{
    public partial class Slider_Home_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreate",
                value: new DateTime(2022, 3, 6, 23, 38, 44, 798, DateTimeKind.Local).AddTicks(8905));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreate",
                value: new DateTime(2022, 3, 6, 23, 38, 44, 800, DateTimeKind.Local).AddTicks(5305));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "8f22ab0a-f041-4d36-84a3-15d613543cb6");

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "Id", "Description", "Image", "Name", "SortOrder", "Status", "Title", "Url" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Minus, illum.", "~/lib/bootstrap/img/slider/1.jpg", "Men Collection", 1, 1, "Save Up to 75% Off", "#" },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Minus, illum.", "~/lib/bootstrap/img/slider/2.jpg", "Wristwatch Collection", 2, 1, "Save Up to 40% Off", "#" },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Minus, illum.", "~/lib/bootstrap/img/slider/3.jpg", "Jeans Collection", 3, 1, "Save Up to 75% Off", "#" },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Minus, illum.", "~/lib/bootstrap/img/slider/4.jpg", "Exclusive Shoes", 4, 1, "Save Up to 75% Off", "#" },
                    { 5, "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Minus, illum.", "~/lib/bootstrap/img/slider/5.jpg", "Best Collection", 5, 1, "Save Up to 50% Off", "#" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5eda3f75-0ccb-41c7-930c-2368a75e3b82", "AQAAAAEAACcQAAAAEGTtY5tywltDNwALnCR9GkgAvz54DOQi7tejrYHOECaLtG0jUv1MhrV48iEuhdrJsQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Products");

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
    }
}
