using Bible.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bible.Database.Configurations
{
    public class VerseConfiguration : IEntityTypeConfiguration<Verse>
    {
        public void Configure(EntityTypeBuilder<Verse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Content).IsRequired().IsUnicode();
            // Forgein key
            builder.HasOne(x => x.Chapter).WithMany(x => x.Verses).HasForeignKey(x => x.ChapterId);
            builder.HasMany(x => x.AudioVerses).WithOne(x => x.Verse).HasForeignKey(x => x.VerseId);
        }
    }
}
