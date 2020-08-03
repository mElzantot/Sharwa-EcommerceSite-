using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceSite.Migrations
{
    public partial class seedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Discount", "FK_CategoryId", "FK_SellerId", "LongDisc", "Name", "Price", "ShortDisc", "Stock", "Thumb" },
                values: new object[,]
                {
                    { 1, 12f, 4, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The camera, reimagined. Galaxy S9 and S9+ introduced the revolutionary Dual Aperture phone camera that adapts to light like the human eye.", "GalaxsyS9", 15000f, "Samsung FlagShip", 12, null },
                    { 17, 0f, 1, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The iPhone X was Apple's flagship 10th anniversary iPhone featuring a 5.8-inch OLED display, facial recognition and 3D camera functionality, a glass body, and an A11 Bionic processor. Launched November 3, 2017, discontinued with the launch of the iPhone XR, XS, and XS Max.", "IPhone X", 20000f, "Iphone FlagShip", 20, null },
                    { 16, 0f, 1, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The iPhone X was Apple's flagship 10th anniversary iPhone featuring a 5.8-inch OLED display, facial recognition and 3D camera functionality, a glass body, and an A11 Bionic processor. Launched November 3, 2017, discontinued with the launch of the iPhone XR, XS, and XS Max.", "IPhone X", 20000f, "Iphone FlagShip", 20, null },
                    { 15, 0f, 1, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The iPhone X was Apple's flagship 10th anniversary iPhone featuring a 5.8-inch OLED display, facial recognition and 3D camera functionality, a glass body, and an A11 Bionic processor. Launched November 3, 2017, discontinued with the launch of the iPhone XR, XS, and XS Max.", "IPhone X", 20000f, "Iphone FlagShip", 20, null },
                    { 14, 0f, 1, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The iPhone X was Apple's flagship 10th anniversary iPhone featuring a 5.8-inch OLED display, facial recognition and 3D camera functionality, a glass body, and an A11 Bionic processor. Launched November 3, 2017, discontinued with the launch of the iPhone XR, XS, and XS Max.", "IPhone X", 20000f, "Iphone FlagShip", 20, null },
                    { 13, 0f, 1, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The iPhone X was Apple's flagship 10th anniversary iPhone featuring a 5.8-inch OLED display, facial recognition and 3D camera functionality, a glass body, and an A11 Bionic processor. Launched November 3, 2017, discontinued with the launch of the iPhone XR, XS, and XS Max.", "IPhone X", 20000f, "Iphone FlagShip", 20, null },
                    { 12, 0f, 1, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The iPhone X was Apple's flagship 10th anniversary iPhone featuring a 5.8-inch OLED display, facial recognition and 3D camera functionality, a glass body, and an A11 Bionic processor. Launched November 3, 2017, discontinued with the launch of the iPhone XR, XS, and XS Max.", "IPhone X", 20000f, "Iphone FlagShip", 20, null },
                    { 11, 0f, 1, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The iPhone X was Apple's flagship 10th anniversary iPhone featuring a 5.8-inch OLED display, facial recognition and 3D camera functionality, a glass body, and an A11 Bionic processor. Launched November 3, 2017, discontinued with the launch of the iPhone XR, XS, and XS Max.", "IPhone X", 20000f, "Iphone FlagShip", 20, null },
                    { 18, 0f, 1, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The iPhone X was Apple's flagship 10th anniversary iPhone featuring a 5.8-inch OLED display, facial recognition and 3D camera functionality, a glass body, and an A11 Bionic processor. Launched November 3, 2017, discontinued with the launch of the iPhone XR, XS, and XS Max.", "IPhone X", 20000f, "Iphone FlagShip", 20, null },
                    { 10, 0f, 1, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The iPhone X was Apple's flagship 10th anniversary iPhone featuring a 5.8-inch OLED display, facial recognition and 3D camera functionality, a glass body, and an A11 Bionic processor. Launched November 3, 2017, discontinued with the launch of the iPhone XR, XS, and XS Max.", "IPhone X", 20000f, "Iphone FlagShip", 20, null },
                    { 8, 12f, 4, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The camera, reimagined. Galaxy S9 and S9+ introduced the revolutionary Dual Aperture phone camera that adapts to light like the human eye.", "GalaxsyS9", 15000f, "Samsung FlagShip", 12, null },
                    { 7, 12f, 4, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The camera, reimagined. Galaxy S9 and S9+ introduced the revolutionary Dual Aperture phone camera that adapts to light like the human eye.", "GalaxsyS9", 15000f, "Samsung FlagShip", 12, null },
                    { 6, 12f, 4, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The camera, reimagined. Galaxy S9 and S9+ introduced the revolutionary Dual Aperture phone camera that adapts to light like the human eye.", "GalaxsyS9", 15000f, "Samsung FlagShip", 12, null },
                    { 5, 12f, 4, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The camera, reimagined. Galaxy S9 and S9+ introduced the revolutionary Dual Aperture phone camera that adapts to light like the human eye.", "GalaxsyS9", 15000f, "Samsung FlagShip", 12, null },
                    { 4, 12f, 4, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The camera, reimagined. Galaxy S9 and S9+ introduced the revolutionary Dual Aperture phone camera that adapts to light like the human eye.", "GalaxsyS9", 15000f, "Samsung FlagShip", 12, null },
                    { 3, 12f, 4, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The camera, reimagined. Galaxy S9 and S9+ introduced the revolutionary Dual Aperture phone camera that adapts to light like the human eye.", "GalaxsyS9", 15000f, "Samsung FlagShip", 12, null },
                    { 2, 12f, 4, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The camera, reimagined. Galaxy S9 and S9+ introduced the revolutionary Dual Aperture phone camera that adapts to light like the human eye.", "GalaxsyS9", 15000f, "Samsung FlagShip", 12, null },
                    { 9, 12f, 4, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The camera, reimagined. Galaxy S9 and S9+ introduced the revolutionary Dual Aperture phone camera that adapts to light like the human eye.", "GalaxsyS9", 15000f, "Samsung FlagShip", 12, null },
                    { 19, 0f, 1, "b8e2598f-fb76-4658-88aa-a9fa0be23189", "The iPhone X was Apple's flagship 10th anniversary iPhone featuring a 5.8-inch OLED display, facial recognition and 3D camera functionality, a glass body, and an A11 Bionic processor. Launched November 3, 2017, discontinued with the launch of the iPhone XR, XS, and XS Max.", "IPhone X", 20000f, "Iphone FlagShip", 20, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);
        }
    }
}
