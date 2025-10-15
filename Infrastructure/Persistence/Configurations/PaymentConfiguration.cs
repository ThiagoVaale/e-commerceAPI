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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Amount)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.Property(p => p.TransactionId)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(p => p.TransactionId)
               .IsUnique();

            builder.HasOne(p => p.Order)
                .WithMany()
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(ps => ps.PaymentStatus)
                   .HasConversion<string>();

            builder.Property(pm => pm.PaymentMethod)
                   .HasConversion<string>();
        }
    }
}
