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
            builder.Property(x => x.CreatedBy).IsRequired().IsUnicode().HasMaxLength(150).HasDefaultValue("admin");
            builder.Property(x => x.UpdatedBy).IsUnicode().HasMaxLength(150);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.UpdateAt).HasDefaultValue(null);
            // forgien Key
            builder.HasOne(x => x.Verse).WithMany(x => x.AudioVerses).HasForeignKey(x => x.VerseId);

        }
    }
}
