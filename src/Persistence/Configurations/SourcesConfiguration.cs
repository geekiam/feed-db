using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Threenine;
using Threenine.Configurations.PostgreSql;
using Threenine.Database.Configuration.PostgreSql;

namespace Geekiam.Persistence.Configurations;

public class SourcesConfiguration : BaseEntityTypeConfiguration<Sources>
{
    public override void Configure(EntityTypeBuilder<Sources> builder)
    {
     
        
        builder.HasIndex(x => x.Identifier).IsUnique();
        
        builder.HasIndex(x => new { x.FeedUrl, x.Domain})
            .IsUnique();
        
        builder.Property(x => x.Identifier)
            .HasColumnName(nameof(Sources.Identifier).ToLower())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(75)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName(nameof(Sources.Description).ToLower())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(300);

        builder.Property(x => x.Name)
            .HasColumnName(nameof(Sources.Name).ToLower())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(x => x.Domain)
            .HasColumnName(nameof(Sources.Domain).ToLower())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(x => x.FeedUrl)
            .HasColumnName(nameof(Sources.FeedUrl).ToSnakeCase())
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
            .HasColumnType(ColumnTypes.Integer);
        
        builder.Property(x => x.MediaTypeId)
            .HasColumnName(nameof(Sources.MediaTypeId).ToSnakeCase())
            .HasColumnType(ColumnTypes.Integer);

       

       builder.HasOne(x => x.Status)
            .WithMany(x => x.Sources)
            .HasForeignKey(x => x.StatusId)
            .IsRequired();
       
       builder.HasOne(x => x.MediaType)
           .WithMany(x => x.Sources)
           .HasForeignKey(x => x.MediaTypeId)
           .IsRequired();
       

      

    
        
        base.Configure(builder);
    }
}