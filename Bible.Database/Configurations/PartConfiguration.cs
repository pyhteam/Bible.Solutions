using Bible.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Bible.Database.Configurations
{
    public class PartConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(250);
            // foreign key
            builder.HasOne(x => x.PartParent).WithMany(x => x.ChildParts).HasForeignKey(x => x.PartParentId);
            builder.HasOne(x => x.Bibles).WithMany(x => x.Parts).HasForeignKey(x => x.BiblesId);
        }
    }
}
