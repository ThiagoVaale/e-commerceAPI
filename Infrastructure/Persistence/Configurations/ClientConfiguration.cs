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
                .WithMany()
                .HasForeignKey(c => c.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<RetailClient>()
                .WithOne(r => r.Client)
                .HasForeignKey<RetailClient>(r => r.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<WholesaleClient>()
                .WithOne(w => w.Client)
                .HasForeignKey<WholesaleClient>(w => w.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
