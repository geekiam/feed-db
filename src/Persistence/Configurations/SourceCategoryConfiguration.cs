using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Threenine.Configurations.PostgreSql;
using Threenine.Database.Configuration.PostgreSql;

namespace Geekiam.Persistence.Configurations;

public class SourceCategoryConfiguration : BaseEntityTypeConfiguration<SourceCategory>
{
    public override void Configure(EntityTypeBuilder<SourceCategory> builder)
    {
        builder.HasKey(x => new { x.CategoryId, x.SourceId });

        builder.HasIndex(x => new {x.CategoryId, x.SourceId}).IsUnique();
        
        builder.Property(x => x.CategoryId)
            .HasColumnType(ColumnTypes.UniqueIdentifier)
            .IsRequired();

        builder.Property(x => x.SourceId)
            .HasColumnType(ColumnTypes.UniqueIdentifier)
            .IsRequired();

        builder.HasOne(x => x.Category)
            .WithMany(p => p.Sources)
            .HasForeignKey(k => k.CategoryId);

        builder.HasOne(x => x.Source)
            .WithMany(p => p.Categories)
            .HasForeignKey(k => k.SourceId);

        base.Configure(builder);
    }
}