using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using System.Reflection.Emit;

namespace DataAccess.EntitiesConfiguration
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder) {
            //Set Primary Key
            builder.HasKey(x => x.Id);

            //Set Property configurations
            builder.Property(x => x.Title)
                        .HasMaxLength(125)
                        .IsRequired();


            //Set Relationship configurations: HasOne/HasMany/WithOne/WithMany
            builder.HasOne(x => x.Category)
                        .WithMany(x => x.Products)
                        .HasForeignKey(x => x.CategoryId);

            //Set Check Constraint for table
            builder.ToTable(t => t.HasCheckConstraint("RangePrice", "Price > 0"));

        }
    }
}
