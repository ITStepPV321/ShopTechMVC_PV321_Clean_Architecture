using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using DataAccess.EntitiesConfiguration;

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

            #region Fluent API => Configurations
            ////Set Primary Key
            //modelBuilder.Entity<Product>().HasKey(x => x.Id);

            ////Set Property configurations
            //modelBuilder.Entity<Product>()
            //            .Property(x=>x.Title)
            //            .HasMaxLength(125)
            //            .IsRequired();


            ////Set Relationship configurations: HasOne/HasMany/WithOne/WithMany
            //modelBuilder.Entity<Product>()
            //            .HasOne(x=>x.Category)
            //            .WithMany(x=>x.Products)
            //            .HasForeignKey(x=>x.CategoryId);

            ////Set Check Constraint for table
            //modelBuilder.Entity<Product>()
            //       .ToTable(t => t.HasCheckConstraint("RangePrice", "Price > 0"));

            #endregion
            //Apply Configurations for Entites 
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopTechMVCDbContext).Assembly);
            //or
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
