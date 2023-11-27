using Geekiam.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Threenine;
using Threenine.Configurations.PostgreSql;
using Threenine.Database.Configuration.PostgreSql;

namespace Geekiam.Persistence.Configurations;

public class OpenGraphConfiguration : BaseEntityTypeConfiguration<OpenGraph>
{
    public override void Configure(EntityTypeBuilder<OpenGraph> builder)
    {
        builder.Property(x => x.PostId)
            .HasColumnName(nameof(OpenGraph.PostId).ToSnakeCase())
            .HasColumnType(ColumnTypes.UniqueIdentifier)
            .IsRequired();
        
        builder.Property(x => x.Description)
            .HasColumnName(nameof(OpenGraph.Description).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(200);
        
        builder.Property(x => x.Title)
            .HasColumnName(nameof(OpenGraph.Title).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(70);
        
        builder.Property(x => x.Type)
            .HasColumnName(nameof(OpenGraph.Type).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(75);
        
        builder.Property(x => x.Url)
            .HasColumnName(nameof(OpenGraph.Url).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(200);
        
        builder.Property(x => x.SiteName)
            .HasColumnName(nameof(OpenGraph.SiteName).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(200);
        
        base.Configure(builder);
        
       
    }
}