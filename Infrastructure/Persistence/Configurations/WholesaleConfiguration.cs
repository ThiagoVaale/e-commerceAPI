using Domine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class WholesaleConfiguration : IEntityTypeConfiguration<WholesaleClient>
    {
        public void Configure(EntityTypeBuilder<WholesaleClient> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(tw => tw.TierWholesale)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(c => c.CompanyName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Cuit)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.BillingAddress)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.CreditLimit)
                .IsRequired()
                .HasPrecision(18,2);

            builder.HasOne(tw => tw.Client)
                .WithOne(c => c.WholesaleClient)
                .HasForeignKey<WholesaleClient>(tw => tw.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
