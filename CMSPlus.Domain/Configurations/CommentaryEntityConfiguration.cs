using CMSPlus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMSPlus.Domain.Configurations;

public class CommentaryEntityConfiguration : IEntityTypeConfiguration<CommentaryEntity>
{
    public void Configure(EntityTypeBuilder<CommentaryEntity> builder)
    {
        builder.ToTable("Commentaries");
        builder.Property(x => x.Body).IsRequired();
        builder.Property(x => x.Name).IsRequired();
        builder.Property(x => x.LastName).IsRequired();
    }
}