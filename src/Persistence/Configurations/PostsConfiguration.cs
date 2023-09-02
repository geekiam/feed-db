using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Threenine.Configurations.PostgreSql;
using Threenine.Database.Configuration.PostgreSql;

namespace Geekiam.Persistence.Configurations;

public class PostsConfiguration : BaseEntityTypeConfiguration<Posts>
{
    public override void Configure(EntityTypeBuilder<Posts> builder)
    {
        
        builder.Property(x => x.Title)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();
      
        builder.Property(x => x.Description)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(300)
            .IsRequired();
      
        builder.Property(x => x.Permalink)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();
        
        
        builder.Property(x => x.Summary)
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(150);

        builder.HasIndex(x => new { x.Permalink, x.SourceId }).IsUnique();
      
        builder.Property(x => x.Published)
            .HasColumnType(ColumnTypes.Timestamp)
            .IsRequired();
    
        builder.HasOne(x => x.Source)
            .WithMany(x => x.Posts)
            .HasForeignKey(x => x.SourceId);
      
        base.Configure(builder);
    }
}