using Bible.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bible.Database.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(100);
            builder.Property(x => x.Introduce).IsUnicode().HasMaxLength(500);
            builder.Property(x => x.CodeBook).IsUnicode().IsRequired().HasMaxLength(150);
            // Forgein key
            builder.HasOne(x => x.Part).WithMany(x => x.Books).HasForeignKey(x => x.PartId);
        }
    }
}
