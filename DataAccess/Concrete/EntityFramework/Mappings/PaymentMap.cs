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

            //ortak alan
            builder.Property(o => o.CreatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.ModifiedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();

            //tablo
            builder.ToTable("Payments");
        }
    }
}
