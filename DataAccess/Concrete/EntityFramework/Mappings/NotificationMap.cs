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
    public class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.ID);
            builder.Property(n => n.ID).ValueGeneratedOnAdd();
            builder.Property(n => n.Message).HasColumnType("varchar").HasMaxLength(250).IsRequired();
            builder.Property(n => n.IsRead).IsRequired();

            //ortak alan
            builder.Property(o => o.CreatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.ModifiedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();

            builder.ToTable("Notifications");

            builder.HasData(new Notification
            {
                ID = 1,
                IsRead = false,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                Message = "ilk bilidirim mesajı :)",
                IsDeleted = false
            });
        }
    }
}
