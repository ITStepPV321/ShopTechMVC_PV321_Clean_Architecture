using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;

namespace DataAccess.Data
{
    public class ShopTechMVCDbContext:DbContext
    {
        //public ShopTechMVCDbContext()
        //{
        //    //Database.EnsureCreated();
        //}
        public ShopTechMVCDbContext(DbContextOptions<ShopTechMVCDbContext> options):base(options)
        {
            //Database.EnsureCreated();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ShopTechMVC;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(SeedData.GetCategory());
            modelBuilder.Entity<Product>().HasData(SeedData.GetProduct());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
