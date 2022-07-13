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
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.ID);
            builder.Property(s => s.ID).ValueGeneratedOnAdd();
            builder.Property(s => s.ReservationDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(s => s.EODDate).IsRequired();
            builder.Property(s => s.IsCancelled).IsRequired();

            //ortak alan
            builder.Property(o => o.CreatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.ModifiedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();

            //ilişki
            builder.HasOne<Car>(s => s.Car).WithMany(c => c.Sales).HasForeignKey(s => s.CarId);
            builder.HasOne<User>(s => s.User).WithMany(u => u.Sales).HasForeignKey(s => s.UserId);

            //tablo
            builder.ToTable("Sales");
        }
    }
}
