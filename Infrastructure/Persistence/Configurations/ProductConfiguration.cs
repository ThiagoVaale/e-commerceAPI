using Domine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Stock)
                .IsRequired();

            builder.Property(i => i.Description)
                .HasMaxLength(500);

            builder.Property(i => i.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(500);

            builder.Property(p => p.IsActive)
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
