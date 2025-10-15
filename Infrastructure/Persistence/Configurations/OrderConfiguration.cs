using Domine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.ShippingAddress)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(o => o.TotalAmount)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(so => so.StatusOrder)
                .HasConversion<string>();

            builder.Property(pm => pm.PaymentMethod)
                .HasConversion<string>();

            builder.HasOne(o => o.Client)
                .WithMany()
                .HasForeignKey(o => o.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Employee)
                 .WithMany()
                 .HasForeignKey(o => o.EmployeeId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
