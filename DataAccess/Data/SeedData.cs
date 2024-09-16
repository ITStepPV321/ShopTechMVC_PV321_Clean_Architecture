using DataAccess.Entities;

namespace DataAccess.Data
{
    public static class SeedData
    {
        public static List<Product> GetProduct()
        {
            return new List<Product>()
            {
                new Product(){
                Id=1,
                Title="Ноутбук Acer Aspire 7 A715-42G-R7BK (NH.QE5EU.00L) Charcoal Black",
                Description="Екран 15.6\" IPS (1920x1080) Full HD 144 Гц, матовый / AMD Ryzen 7 5700U (1.8 - 4.3 ГГц) / RAM 16 ГБ / SSD 512 ГБ / nVidia GeForce RTX 3050, 4 ГБ / без ОД / LAN / Wi-Fi / Bluetooth / веб-камера / без ОС / 2.15 кг / черний",
                Price=20354,
                ImagePath="https://content.rozetka.com.ua/goods/images/big_tile/451110968.jpg",
                CategoryId=1
                },
                new Product(){
                Id=2,
                Title="Ноутбук CHUWI GemiBook X (8/256) (CW-102596)",
                Description="Екран 15.6\" IPS (1920x1080) FullHD / Intel Jasper Lake N5100 (2.8 ГГц) / RAM 8 ГБ / SSD 2560020ГБ / Intel UHD Graphics / Wi-Fi 6 / Bluetooth 5 / веб-камера / Windows 11 Home (64bit) / 1.6 кг / Титан.",
                Price=30454,
                ImagePath="https://content.rozetka.com.ua/goods/images/big_tile/451110968.jpg",
                CategoryId=1
                },
                new Product(){
                Id=3,
                Title="Ноутбук Chuwi GemiBook PRO 2K-IPS Jasper Lake (CW-102545/GBP8256) Space Gray",
                Description="Екран 14” IPS (2160x1440) Full HD, глянцевий з покриттям проти відблиску/Intel Celeron N5100 (1.1 — 2.8 ГГц)/RAM 8 ГБ/SSD 256 ГБ/Intel UHD Graphics/без ОД/Wi-Fi/Bluetooth/вебкамера/Windows 10 Home/1.5 кг/темно-сірий",
                Price=28454,
                ImagePath="https://content.rozetka.com.ua/goods/images/big_tile/451110968.jpg",
                CategoryId=1
                },
                new Product(){
                Id=4,
                Title="Мобільний телефон Apple iPhone 15 Pro Max 256GB Black", 
                Description="Екран (6.7\", OLED (Super Retina XDR), 2796x1290) / Apple A17 Pro / основна потрійна камера: 48 Мп + 12 Мп + 12 Мп, фронтальна камера: 12 Мп / 256 ГБ вбудованої пам'яті / 3G / LTE / 5G / GPS / Nano-SIM / iOS 17",
                Price=28454,
                ImagePath="https://content1.rozetka.com.ua/goods/images/big_tile/364834187.jpg",
                CategoryId=2
                }
            };
        }

        public static List<Category> GetCategory()
        {
            return new List<Category>()
            {
                new(){ Id=1, Name="Laptop", Description="None"},
                new(){ Id=2, Name="Smartphone", Description="None"},
                new(){ Id=3, Name="Electronic", Description="None"}

            };
        }

    }
}
