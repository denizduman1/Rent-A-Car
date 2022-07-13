using Entity.ComplexTypes;
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

            //data 
            builder.HasData(new Car
            {
                ID = 1,
                CarModelId = 1,
                ColorId = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CurrentCount = 3,
                TotalCount = 3,
                Description = "Temiz aile arabası",
                DailyPrice = 800,
                FuelType = (int)FuelType.Benzin,
                Image = "https://s.yauto.cz/m/obrazky/hih/0019/hyundai-i20-306110-M-789242797-1.jpg",
                ModelYear = new DateTime(2015,01,01),
                IsDeleted = false,
                TransmissionType = (int)TransmissionType.Otomatik,
                VehicleType = (int)VehicleType.HatchBack,
            },
            new Car
            {
                ID = 2,
                CarModelId = 1,
                ColorId = 3,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CurrentCount = 1,
                TotalCount = 1,
                Description = "Temiz aile arabası",
                DailyPrice = 800,
                FuelType = (int)FuelType.Benzin,
                Image = "https://i0.shbdn.com/photos/73/43/28/x5_103173432829h.jpg",
                ModelYear = new DateTime(2014, 01, 01),
                IsDeleted = false,
                TransmissionType = (int)TransmissionType.Otomatik,
                VehicleType = (int)VehicleType.HatchBack,
            },
            new Car
            {
                ID = 3,
                CarModelId = 2,
                ColorId = 2,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CurrentCount = 6,
                TotalCount = 6,
                Description = "Yeni aile arabası",
                DailyPrice = 950,
                FuelType = (int)FuelType.Benzin,
                Image = "https://file.ikinciyeni.com/carphotos/34re2824/DetailImage/ikinci-el-satilik-renault-clio-48-045dfa.jpg?v1",
                ModelYear = new DateTime(2018, 01, 01),
                IsDeleted = false,
                TransmissionType = (int)TransmissionType.Otomatik,
                VehicleType = (int)VehicleType.HatchBack,
            },
            new Car
            {
                ID = 4,
                CarModelId = 2,
                ColorId = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CurrentCount = 6,
                TotalCount = 6,
                Description = "Yeni beyaz clio",
                DailyPrice = 980,
                FuelType = (int)FuelType.Benzin,
                Image = "https://www.yildirayrentacar.com/dosya/2080/sinif/13-56-17-renault-clio-benzin.jpg",
                ModelYear = new DateTime(2020, 01, 01),
                IsDeleted = false,
                TransmissionType = (int)TransmissionType.Otomatik,
                VehicleType = (int)VehicleType.HatchBack,
            },
            new Car
            {
                ID = 5,
                CarModelId = 3,
                ColorId = 3,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CurrentCount = 2,
                TotalCount = 2,
                Description = "Yeni siyah megane",
                DailyPrice = 1050,
                FuelType = (int)FuelType.Benzin,
                Image = "https://bufilo.com/storage/aylik-kiralik-megane-renault-bufilo-arac-kiralama-istanbul-600-250.png",
                ModelYear = new DateTime(2021, 01, 01),
                IsDeleted = false,
                TransmissionType = (int)TransmissionType.Otomatik,
                VehicleType = (int)VehicleType.Sedan,
            },
            new Car
            {
                ID = 6,
                CarModelId = 3,
                ColorId = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CurrentCount = 2,
                TotalCount = 2,
                Description = "Yeni beyaz megane",
                DailyPrice = 1050,
                FuelType = (int)FuelType.Benzin,
                Image = "https://zugo2.mncdn.com/mnresize/800/-/Images/Arac/b/410/283507/2175813.jpg",
                ModelYear = new DateTime(2021, 01, 01),
                IsDeleted = false,
                TransmissionType = (int)TransmissionType.Otomatik,
                VehicleType = (int)VehicleType.Sedan,
            },
            new Car
            {
                ID = 7,
                CarModelId = 4,
                ColorId = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CurrentCount = 4,
                TotalCount = 4,
                Description = "Ucuz yakıt egea",
                DailyPrice = 1100,
                FuelType = (int)FuelType.Dizel,
                Image = "https://ersanrentacar.com/yuklemeler/2015/10/fiat-egea-bulut-beyazi-2.jpg",
                ModelYear = new DateTime(2020, 01, 01),
                IsDeleted = false,
                TransmissionType = (int)TransmissionType.Manual,
                VehicleType = (int)VehicleType.Sedan,
            },
            new Car
            {
                ID = 8,
                CarModelId = 4,
                ColorId = 2,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CurrentCount = 3,
                TotalCount = 3,
                Description = "Ucuz yakıt egea",
                DailyPrice = 1100,
                FuelType = (int)FuelType.Dizel,
                Image = "https://zugo2.mncdn.com/mnresize/800/-/Images/Arac/b/410/251987/1913579.jpg",
                ModelYear = new DateTime(2020, 01, 01),
                IsDeleted = false,
                TransmissionType = (int)TransmissionType.Manual,
                VehicleType = (int)VehicleType.Sedan,
            },
            new Car
            {
                ID = 9,
                CarModelId = 5,
                ColorId = 4,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CurrentCount = 1,
                TotalCount = 1,
                Description = "hızlı opel astra",
                DailyPrice = 1090,
                FuelType = (int)FuelType.Benzin,
                Image = "https://i0.shbdn.com/photos/20/05/44/1032200544t8b.jpg",
                ModelYear = new DateTime(2020, 01, 01),
                IsDeleted = false,
                TransmissionType = (int)TransmissionType.Otomatik,
                VehicleType = (int)VehicleType.Sedan,
            },
            new Car
            {
                ID = 10,
                CarModelId = 5,
                ColorId = 5,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CurrentCount = 1,
                TotalCount = 1,
                Description = "opel özel renk mavi",
                DailyPrice = 1150,
                FuelType = (int)FuelType.Benzin,
                Image = "https://www.arackaplama.com/wp-content/uploads/2017/12/IMAG2542.jpg",
                ModelYear = new DateTime(2017, 01, 01),
                IsDeleted = false,
                TransmissionType = (int)TransmissionType.Manual,
                VehicleType = (int)VehicleType.Sedan,
            },
            new Car
            {
                ID = 11,
                CarModelId = 6,
                ColorId = 2,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CurrentCount = 4,
                TotalCount = 4,
                Description = "spor yarış arabası",
                DailyPrice = 1500,
                FuelType = (int)FuelType.Benzin,
                Image = "https://upload.wikimedia.org/wikipedia/commons/e/e9/2016_BMW_i8.jpg",
                ModelYear = new DateTime(2022, 01, 01),
                IsDeleted = false,
                TransmissionType = (int)TransmissionType.Otomatik,
                VehicleType = (int)VehicleType.SPOR,
            },
            new Car
            {
                ID = 12,
                CarModelId = 6,
                ColorId = 5,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CurrentCount = 7,
                TotalCount = 7,
                Description = "spor yarış arabası",
                DailyPrice = 1250,
                FuelType = (int)FuelType.Dizel,
                Image = "https://upload.wikimedia.org/wikipedia/commons/9/93/2015_BMW_i8_%2820039281571%29_%282%29.jpg",
                ModelYear = new DateTime(2015, 01, 01),
                IsDeleted = false,
                TransmissionType = (int)TransmissionType.Otomatik,
                VehicleType = (int)VehicleType.SPOR,
            }
            );
        }
    }
}
