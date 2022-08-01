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
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.ID);
            builder.Property(p => p.ID).ValueGeneratedOnAdd();
            builder.Property(p => p.DayCount).HasColumnType("smallint").IsRequired();
            builder.Property(p => p.TotalPrice).IsRequired();
            builder.Property(p => p.IsPaid).IsRequired();
            builder.Property(p => p.IsCancelled).IsRequired();
            builder.Property(p => p.ReservationDate).IsRequired();
            builder.Property(p => p.EODDate).IsRequired();

            //ortak alan
            builder.Property(o => o.CreatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.ModifiedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();

            //ilişki
            builder.HasOne<Car>(p => p.Car).WithMany(c => c.Payments).HasForeignKey(p => p.CarId);
            builder.HasOne<User>(p => p.User).WithMany(u => u.Payments).HasForeignKey(p => p.UserId);

            //tablo
            builder.ToTable("Payments");
        }
    }
}
