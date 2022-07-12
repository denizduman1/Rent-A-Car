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
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.ID);
            builder.Property(b => b.ID).ValueGeneratedOnAdd();
            builder.Property(b=>b.Name).HasMaxLength(100).IsRequired();

            //ortak alan
            builder.Property(o => o.CreatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.ModifiedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();

            //tablo
            builder.ToTable("Brands");

            //data
            builder.HasData(new Brand
            {
                ID = 1,
                Name = "Hyundai",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            },
            new Brand
            {
                ID = 2,
                Name = "Bmw",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            },
            new Brand
            {
                ID = 3,
                Name = "Volvo",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            },
            new Brand
            {
                ID = 4,
                Name = "Renault",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            },
            new Brand
            {
                ID = 5,
                Name = "Opel",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            },
            new Brand
            {
                ID = 6,
                Name = "Fiat",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            }
            );

        }
    }
}
