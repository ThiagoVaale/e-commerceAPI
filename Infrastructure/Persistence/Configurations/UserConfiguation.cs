using Domine.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class UserConfiguation : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasIndex(e => e.Email)
                .IsUnique();

            builder.HasIndex(e => e.Username)
                .IsUnique();
                
            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Password)
                .IsRequired();

            builder.HasOne(u => u.Role)
              .WithMany(r => r.Users)
              .HasForeignKey(u => u.RoleId)
              .IsRequired();

            builder.HasOne(u => u.Client)
               .WithOne(c => c.User)
               .HasForeignKey<Client>(c => c.UserID)
               .IsRequired();

            builder.HasOne(u => u.Employee)
               .WithOne(e => e.User)
               .HasForeignKey<Employee>(e => e.UserID);

            builder.HasMany(u => u.Carts)
             .WithOne(c => c.User)
             .HasForeignKey(c => c.UserId)
             .IsRequired();
        }
    }
}
