using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "None", "Laptop" },
                    { 2, "None", "Smartphone" },
                    { 3, "None", "Electronic" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImagePath", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Екран 15.6\" IPS (1920x1080) Full HD 144 Гц, матовый / AMD Ryzen 7 5700U (1.8 - 4.3 ГГц) / RAM 16 ГБ / SSD 512 ГБ / nVidia GeForce RTX 3050, 4 ГБ / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / без ОС / 2.15 кг / черний", "https://content.rozetka.com.ua/goods/images/big_tile/451110968.jpg", 20354m, "Ноутбук Acer Aspire 7 A715-42G-R7BK (NH.QE5EU.00L) Charcoal Black" },
                    { 2, 1, "Екран 15.6\" IPS (1920x1080) FullHD / Intel Jasper Lake N5100 (2.8 ГГц) / RAM 8 ГБ / SSD 2560020ГБ / Intel UHD Graphics / Wi-Fi 6 / Bluetooth 5 / веб-камера / Windows 11 Home (64bit) / 1.6 кг / Титан.", "https://content.rozetka.com.ua/goods/images/big_tile/451110968.jpg", 30454m, "Ноутбук CHUWI GemiBook X (8/256) (CW-102596)" },
                    { 3, 1, "Екран 14” IPS (2160x1440) Full HD, глянцевий з покриттям проти відблиску/Intel Celeron N5100 (1.1 — 2.8 ГГц)/RAM 8 ГБ/SSD 256 ГБ/Intel UHD Graphics/без ОД/Wi-Fi/Bluetooth/вебкамера/Windows 10 Home/1.5 кг/темно-сірий", "https://content.rozetka.com.ua/goods/images/big_tile/451110968.jpg", 28454m, "Ноутбук Chuwi GemiBook PRO 2K-IPS Jasper Lake (CW-102545/GBP8256) Space Gray" },
                    { 4, 2, "Екран (6.7\", OLED (Super Retina XDR), 2796x1290) / Apple A17 Pro / основна потрійна камера: 48 Мп + 12 Мп + 12 Мп, фронтальна камера: 12 Мп / 256 ГБ вбудованої пам'яті / 3G / LTE / 5G / GPS / Nano-SIM / iOS 17", "https://content1.rozetka.com.ua/goods/images/big_tile/364834187.jpg", 28454m, "Мобільний телефон Apple iPhone 15 Pro Max 256GB Black" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
