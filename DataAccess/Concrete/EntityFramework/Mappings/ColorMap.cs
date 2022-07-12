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
    public class ColorMap : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();

            //ortak alan
            builder.Property(o => o.CreatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.ModifiedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();

            //tablo
            builder.ToTable("Colors");

            //data
            builder.HasData(new Color
            {
               ID = 1,
               Name = "Beyaz",
               CreatedDate = DateTime.Now,
               ModifiedDate = DateTime.Now,
               IsDeleted = false
            }, new Color
            {
                ID = 2,
                Name = "Gri",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            }, new Color
            {
                ID = 3,
                Name = "Siyah",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            }, new Color
            {
                ID = 4,
                Name = "Kırmızı",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            }, new Color
            {
                ID = 5,
                Name = "Mavi",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            });

        }
    }
}
