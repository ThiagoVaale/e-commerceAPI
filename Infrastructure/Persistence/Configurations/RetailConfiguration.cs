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
    public class RetailConfiguration : IEntityTypeConfiguration<RetailClient>
    {
        public void Configure(EntityTypeBuilder<RetailClient> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(d => d.Dni)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasOne(r => r.Client)
               .WithOne(c => c.RetailClient) 
               .HasForeignKey<RetailClient>(r => r.ClientId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Membership)
                .WithOne(m => m.RetailClient)
                .HasForeignKey<Membership>(m => m.RetailClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
