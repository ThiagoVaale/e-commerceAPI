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
                .HasConversion<string>();

            builder.Property(m => m.DiscountRate)
               .IsRequired()
               .HasPrecision(5, 2);

            builder.Property(m => m.ValidFrom)
               .IsRequired();

            builder.Property(m => m.ValidTo)
               .IsRequired();

            builder.HasOne(m => m.Client)
                .WithOne(c => c.Membership)
                .HasForeignKey<Membership>(c => c.ClientId)
                .IsRequired();
        }
    }
}
