using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceSite.Migrations
{
    public partial class addImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FK_ProductId", "ImgPath" },
                values: new object[,]
                {
                    { 1, 1, "Galaxy2.jpg" },
                    { 35, 17, "iphonex.jpg" },
                    { 34, 16, "iphonex.jpg" },
                    { 33, 15, "iphonex.jpg" },
                    { 32, 14, "iphonex.jpg" },
                    { 31, 13, "iphonex.jpg" },
                    { 30, 12, "iphonex.jpg" },
                    { 29, 11, "iphonex.jpg" },
                    { 28, 10, "iphonex.jpg" },
                    { 18, 9, "Galaxy S9.jpg" },
                    { 9, 9, "Galaxy2.jpg" },
                    { 17, 8, "Galaxy S9.jpg" },
                    { 8, 8, "Galaxy2.jpg" },
                    { 16, 7, "Galaxy S9.jpg" },
                    { 7, 7, "Galaxy2.jpg" },
                    { 15, 6, "Galaxy S9.jpg" },
                    { 6, 6, "Galaxy2.jpg" },
                    { 14, 5, "Galaxy S9.jpg" },
                    { 5, 5, "Galaxy2.jpg" },
                    { 13, 4, "Galaxy S9.jpg" },
                    { 4, 4, "Galaxy2.jpg" },
                    { 12, 3, "Galaxy S9.jpg" },
                    { 3, 3, "Galaxy2.jpg" },
                    { 11, 2, "Galaxy S9.jpg" },
                    { 2, 2, "Galaxy2.jpg" },
                    { 10, 1, "Galaxy S9.jpg" },
                    { 36, 18, "iphonex.jpg" },
                    { 37, 19, "iphonex.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 37);
        }
    }
}
