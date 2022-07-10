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
    public class CarMap : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).ValueGeneratedOnAdd();
            builder.Property(c => c.TransmissionType).IsRequired();
            builder.Property(c => c.FuelType).IsRequired();
            builder.Property(c => c.VehicleType).IsRequired();
            builder.Property(c => c.DailyPrice).IsRequired();
            builder.Property(c => c.ModelYear).HasColumnType("smalldatetime").IsRequired();
            builder.Property(c => c.Image).HasMaxLength(250).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(250).IsRequired();
            builder.Property(c => c.CurrentCount).IsRequired();
            builder.Property(c => c.TotalCount).IsRequired();

            //ortak alan
            builder.Property(o => o.CreatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.ModifiedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();

            //ilişki
            builder.HasOne<CarModel>(c => c.CarModel).WithMany(cm => cm.Cars).HasForeignKey(c=>c.CarModelId);
            builder.HasOne<Color>(c => c.Color).WithMany(co => co.Cars).HasForeignKey(c => c.ColorId);

            //tablo
            builder.ToTable("Cars");
        }
    }
}
