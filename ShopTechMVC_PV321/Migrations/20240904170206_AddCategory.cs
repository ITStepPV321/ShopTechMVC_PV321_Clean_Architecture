using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopTechMVC_PV321.Migrations
{
    /// <inheritdoc />
    public partial class AddCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CategotyId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "None", "Laptop" },
                    { 2, "None", "Smartphone" },
                    { 3, "None", "Electronic" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategotyId", "ImagePath" },
                values: new object[] { 1, "https://content.rozetka.com.ua/goods/images/big_tile/451110968.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategotyId", "ImagePath" },
                values: new object[] { 1, "https://content.rozetka.com.ua/goods/images/big_tile/451110968.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategotyId", "ImagePath" },
                values: new object[] { 1, "https://content.rozetka.com.ua/goods/images/big_tile/451110968.jpg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategotyId", "Description", "ImagePath", "Price", "Title" },
                values: new object[] { 4, 2, "Екран (6.7\", OLED (Super Retina XDR), 2796x1290) / Apple A17 Pro / основна потрійна камера: 48 Мп + 12 Мп + 12 Мп, фронтальна камера: 12 Мп / 256 ГБ вбудованої пам'яті / 3G / LTE / 5G / GPS / Nano-SIM / iOS 17", "https://content1.rozetka.com.ua/goods/images/big_tile/364834187.jpg", 28454m, "Мобільний телефон Apple iPhone 15 Pro Max 256GB Black" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "CategotyId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
