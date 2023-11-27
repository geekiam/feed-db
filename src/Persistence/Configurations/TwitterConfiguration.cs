using Geekiam.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Threenine;
using Threenine.Configurations.PostgreSql;
using Threenine.Database.Configuration.PostgreSql;

namespace Geekiam.Persistence.Configurations;

public class TwitterConfiguration : BaseEntityTypeConfiguration<Twitter>
{
    public override void Configure(EntityTypeBuilder<Twitter> builder)
    {
        builder.Property(x => x.PostId)
            .HasColumnName(nameof(Twitter.PostId).ToSnakeCase())
            .HasColumnType(ColumnTypes.UniqueIdentifier)
            .IsRequired();
        
        builder.Property(x => x.Description)
            .HasColumnName(nameof(Twitter.Description).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(200);
        
        builder.Property(x => x.Title)
            .HasColumnName(nameof(Twitter.Title).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(70);
        
        builder.Property(x => x.Creator)
            .HasColumnName(nameof(Twitter.Creator).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(75);
        
        builder.Property(x => x.Site)
            .HasColumnName(nameof(Twitter.Site).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(200);
        
        base.Configure(builder);
    }
}