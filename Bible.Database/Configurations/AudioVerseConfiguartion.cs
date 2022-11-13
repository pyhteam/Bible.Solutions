using Bible.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bible.Database.Configurations
{
    public class AudioVerseConfiguartion : IEntityTypeConfiguration<AudioVerse>
    {
        public void Configure(EntityTypeBuilder<AudioVerse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(250);
            builder.Property(x => x.LinkAudio).IsRequired().IsUnicode().HasMaxLength(250);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);

            // forgein key
            builder.HasOne(x => x.Language).WithMany(x => x.AudioVerses).HasForeignKey(x => x.LanguageId);
        }
    }
}
