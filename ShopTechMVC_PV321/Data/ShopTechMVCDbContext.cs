using Microsoft.EntityFrameworkCore;
using ShopTechMVC_PV321.Helpers;
using ShopTechMVC_PV321.Models;
namespace ShopTechMVC_PV321.Data
{
    public class ShopTechMVCDbContext:DbContext
    {
        public ShopTechMVCDbContext()
        {
            //Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ShopTechMVC;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(SeedData.GetProduct());
        }
        public DbSet<Product> Products { get; set; }
    }
}
