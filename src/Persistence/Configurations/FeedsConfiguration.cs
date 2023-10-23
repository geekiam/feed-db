using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Threenine;
using Threenine.Configurations.PostgreSql;
using Threenine.Database.Configuration.PostgreSql;

namespace Geekiam.Persistence.Configurations;

public class FeedsConfiguration  : BaseEntityTypeConfiguration<Feeds>
{
    public override void Configure(EntityTypeBuilder<Feeds> builder)
    {
        builder.Property(x => x.SourcesId)
            .HasColumnName(nameof(Feeds.SourcesId).ToSnakeCase())
            .HasColumnType(ColumnTypes.UniqueIdentifier)
            .IsRequired();
        
        builder.Property(x => x.Path)
            .HasColumnName(nameof(Feeds.Path).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();
        
        builder.Property(x => x.StatusId)
            .HasColumnName(nameof(Feeds.StatusId).ToSnakeCase())
            .HasColumnType(ColumnTypes.Integer);
        
        builder.Property(x => x.MediaTypeId)
            .HasColumnName(nameof(Feeds.MediaTypeId).ToSnakeCase())
            .HasColumnType(ColumnTypes.Integer);

       

        builder.HasOne(x => x.MediaType)
            .WithMany(x => x.Feeds)
            .HasForeignKey(x => x.MediaTypeId);
        
        builder.HasOne(x => x.Status)
            .WithMany(x => x.Feeds)
            .HasForeignKey(x => x.StatusId)
            .IsRequired();

   
        
        base.Configure(builder);
    }
}