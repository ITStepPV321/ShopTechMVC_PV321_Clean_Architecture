using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopTechMVC_PV321.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Екран 15.6\" IPS (1920x1080) Full HD 144 Гц, матовый / AMD Ryzen 7 5700U (1.8 - 4.3 ГГц) / RAM 16 ГБ / SSD 512 ГБ / nVidia GeForce RTX 3050, 4 ГБ / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / без ОС / 2.15 кг / черний", 20354m, "Ноутбук Acer Aspire 7 A715-42G-R7BK (NH.QE5EU.00L) Charcoal Black" },
                    { 2, "Екран 15.6\" IPS (1920x1080) FullHD / Intel Jasper Lake N5100 (2.8 ГГц) / RAM 8 ГБ / SSD 2560020ГБ / Intel UHD Graphics / Wi-Fi 6 / Bluetooth 5 / веб-камера / Windows 11 Home (64bit) / 1.6 кг / Титан.", 30454m, "Ноутбук CHUWI GemiBook X (8/256) (CW-102596)" },
                    { 3, "Екран 14” IPS (2160x1440) Full HD, глянцевий з покриттям проти відблиску/Intel Celeron N5100 (1.1 — 2.8 ГГц)/RAM 8 ГБ/SSD 256 ГБ/Intel UHD Graphics/без ОД/Wi-Fi/Bluetooth/вебкамера/Windows 10 Home/1.5 кг/темно-сірий", 28454m, "Ноутбук Chuwi GemiBook PRO 2K-IPS Jasper Lake (CW-102545/GBP8256) Space Gray" }
                });
        }

        /// <inheritdoc />
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
        }
    }
}
