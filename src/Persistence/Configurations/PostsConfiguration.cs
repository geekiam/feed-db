using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Threenine;
using Threenine.Configurations.PostgreSql;
using Threenine.Database.Configuration.PostgreSql;

namespace Geekiam.Persistence.Configurations;

public class PostsConfiguration : BaseEntityTypeConfiguration<Posts>
{
    public override void Configure(EntityTypeBuilder<Posts> builder)
    {
        
        builder.Property(x => x.Title)
            .HasColumnName(nameof(Posts.Title).ToLower())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();
      
        builder.Property(x => x.Description)
            .HasColumnName(nameof(Posts.Description).ToLower())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(300)
            .IsRequired();
      
        builder.Property(x => x.Permalink)
            .HasColumnName(nameof(Posts.Permalink).ToLower())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();
        
        
        builder.Property(x => x.Summary)
            .HasColumnName(nameof(Posts.Summary).ToLower())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(150);

        builder.HasIndex(x => new { x.Permalink, x.SourceId }).IsUnique();
      
        builder.Property(x => x.Published)
            .HasColumnName(nameof(Posts.Published).ToLower())
            .HasColumnType(ColumnTypes.Timestamp)
            .IsRequired();

        builder.Property(x => x.SourceId)
            .HasColumnName(nameof(Posts.SourceId).ToSnakeCase())
            .HasColumnType(ColumnTypes.UniqueIdentifier);
    
        builder.HasOne(x => x.Source)
            .WithMany(x => x.Posts)
            .HasForeignKey(x => x.SourceId);
      
        base.Configure(builder);
    }
}