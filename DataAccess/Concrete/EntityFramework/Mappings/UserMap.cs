using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> b)
        {
            b.Property(u => u.Image).IsRequired().HasMaxLength(250);
            // Primary key
            b.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            b.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
            b.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex");

            // Maps to the AspNetUsers table
            b.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            b.Property(u => u.UserName).HasMaxLength(50);
            b.Property(u => u.NormalizedUserName).HasMaxLength(50);
            b.Property(u => u.Email).HasMaxLength(150);
            b.Property(u => u.NormalizedEmail).HasMaxLength(150);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            b.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            b.HasMany<UserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            b.HasMany<UserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            b.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
        }
    }
}
