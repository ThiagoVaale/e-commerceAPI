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
    public class UserConfiguation : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Password)
                .IsRequired();

            builder.HasOne(r => r.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(r => r.RoleId);

            builder.HasOne(c => c.Client)
                .WithOne(u => u.User)
                .HasForeignKey<Client>(uId => uId.UserID);

            builder.HasOne(c => c.Employee)
                .WithOne(u => u.User)
                .HasForeignKey<Employee>(eId => eId.UserID);

            builder.HasMany(c => c.Carts)
                .WithOne(u => u.User)
                .HasForeignKey(c => c.UserId);
        }
    }
}
