using Bible.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bible.Database.Configurations
{
    public class BibleConfiguration : IEntityTypeConfiguration<Bibles>
    {
        public void Configure(EntityTypeBuilder<Bibles> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(250);
            builder.Property(x => x.Code).IsRequired().IsUnicode().HasMaxLength(50);
            // foreign key
            builder.HasOne(x => x.Language).WithMany(x => x.Bibles).HasForeignKey(x => x.LanguageId);
        }
    }
}
