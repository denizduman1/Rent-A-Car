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
    public class CarModelMap : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();

            //ortak alan
            builder.Property(o => o.CreatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.ModifiedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();

            //ilişki
            builder.HasOne<Brand>(c => c.Brand).WithMany(b => b.CarModels).HasForeignKey(c => c.BrandId);
            
            //tablo
            builder.ToTable("CarModels");

            //data
            builder.HasData(new CarModel
            {
                ID = 1,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                BrandId = 1,
                Name = "i20"
            },
            new CarModel
            {
                ID = 2,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                BrandId = 4,
                Name = "Clio"
            },
            new CarModel
            {
                ID = 3,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false,
                BrandId = 4,
                Name = "Megane"
            },
            new CarModel
            {
                 ID = 4,
                 CreatedDate = DateTime.Now,
                 ModifiedDate = DateTime.Now,
                 IsDeleted = false,
                 BrandId = 6,
                 Name = "Egea"
            },
            new CarModel
            {
                 ID = 5,
                 CreatedDate = DateTime.Now,
                 ModifiedDate = DateTime.Now,
                 IsDeleted = false,
                 BrandId = 5,
                 Name = "Astra"
            }
            );

        }
    }
}
