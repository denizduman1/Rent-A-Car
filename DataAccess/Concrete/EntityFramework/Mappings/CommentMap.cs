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
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID).ValueGeneratedOnAdd();
            builder.Property(c => c.Description).HasMaxLength(250).IsRequired();
            builder.Property(c => c.Star).HasColumnType("smallint").IsRequired();
            builder.Property(c => c.LikeCount).IsRequired();

            //ortak alan
            builder.Property(o => o.CreatedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.ModifiedDate).HasColumnType("smalldatetime").IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();

            //ilişki
            builder.HasOne<User>(c => c.User).WithMany(u => u.Comments).HasForeignKey(c => c.UserId);

            //tablo
            builder.ToTable("Comments");

            ////data
            //builder.HasData(new Comment
            //{
            //    ID = 1,
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now,
            //    IsDeleted = false,
            //    LikeCount = 0,
            //    UserId = 1,
            //    Star = 5,
            //    Description = "Güler yüz müşteri memnuniyetine özen gösteren bir kurum."                
            //},
            //new Comment
            //{
            //    ID = 2,
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now,
            //    IsDeleted = false,
            //    LikeCount = 0,
            //    UserId = 2,
            //    Star = 4,
            //    Description = "Hızlı pratik ve online olmasıyla daha da efektik hale gelmiş."
            //});
        }
    }
}
