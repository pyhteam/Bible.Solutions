using Bible.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bible.Database.Configurations
{
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ChapterNumber).IsRequired();
            builder.Property(c => c.Name).IsRequired().IsUnicode().HasMaxLength(250);
            builder.Property(c => c.Summary).IsRequired().IsUnicode().HasMaxLength(1000);

            // forgein key
            builder.HasOne(c => c.Book).WithMany(b => b.Chapters).HasForeignKey(c => c.BookId);
        }
    }
}
