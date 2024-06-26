using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Threenine.Configurations.PostgreSql;
using Threenine.Database.Configuration.PostgreSql;
using Threenine.Database.Extensions;

namespace Geekiam.Persistence.Configurations;

internal class SourcesConfiguration : BaseEntityTypeConfiguration<Sources>
{
    public override void Configure(EntityTypeBuilder<Sources> builder)
    {
        builder.HasIndex(x => x.Identifier).IsUnique();

        builder.HasIndex(x => new { x.Domain })
            .IsUnique();

        builder.Property(x => x.Identifier)
            .HasColumnName(nameof(Sources.Identifier).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(75)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName(nameof(Sources.Description).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(300);

        builder.Property(x => x.Name)
            .HasColumnName(nameof(Sources.Name).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Domain)
            .HasColumnName(nameof(Sources.Domain).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();


        builder.Property(x => x.Protocol)
            .HasColumnName(nameof(Sources.Protocol).ToLower())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(7)
            .IsRequired();


        builder.Property(x => x.StatusId)
            .HasColumnName(nameof(Sources.StatusId).ToSnakeCase())
            .HasColumnType(ColumnTypes.Integer)
            .HasDefaultValue(1);


        builder.HasOne(x => x.Status)
            .WithMany(x => x.Sources)
            .HasForeignKey(x => x.StatusId)
            .IsRequired();


        base.Configure(builder);
    }
}