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
    public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(mt => mt.MembershipType)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(m => m.DiscountRate)
               .HasPrecision(5, 2);

            builder.HasOne(m => m.Client)
                .WithOne(c => c.Membership)
                .HasForeignKey<Membership>(m => m.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
