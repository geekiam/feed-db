using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Threenine.Configurations.PostgreSql;

namespace Persistence.Configurations;

public class SourcesConfiguration : BaseEntityTypeConfiguration<Sources>
{
    public override void Configure(EntityTypeBuilder<Sources> builder)
    {
     
        
        builder.HasIndex(x => x.Identifier).IsUnique();
        
        builder.HasIndex(x => new { x.FeedUrl, x.Domain})
            .IsUnique();
        
        builder.Property(x => x.Identifier)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(75)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(300);

        builder.Property(x => x.Name)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(x => x.Domain)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(x => x.FeedUrl)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(x => x.Protocol)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(7)
            .IsRequired();

    

        builder.Property(x => x.StatusId)
            .HasColumnType(ColumnTypes.Integer)
            .IsRequired();

       builder.HasOne(x => x.Status)
            .WithMany(x => x.Sources)
            .HasForeignKey(x => x.StatusId)
            .IsRequired();

      

    
        
        base.Configure(builder);
    }
}