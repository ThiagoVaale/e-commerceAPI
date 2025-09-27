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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(a => a.Address)
                .HasMaxLength(200);

            builder.HasOne(c => c.User)
                .WithOne(u => u.Client)
                .HasForeignKey<Client>(c => c.UserID);

            builder.HasOne(c => c.Membership)
                .WithOne(m => m.Client)
                .HasForeignKey<Client>(c => c.MembershipId);

            builder.HasOne(c => c.RetailClient)
                .WithOne(r => r.Client)
                .HasForeignKey<RetailClient>(r => r.ClientId);

            builder.HasOne(c => c.WholesaleClient)
                .WithOne(w => w.Client)
                .HasForeignKey<WholesaleClient>(w => w.ClientId);

            builder.HasMany(c => c.Orders)
                .WithOne(o => o.Client)
                .HasForeignKey(o => o.ClientId)
                .IsRequired();
        }
    }
}
