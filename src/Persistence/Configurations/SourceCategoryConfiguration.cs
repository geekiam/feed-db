using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Threenine.Configurations.PostgreSql;

namespace Persistence.Configurations;

public class SourceCategoryConfiguration : BaseEntityTypeConfiguration<SourceCategory>
{
    public override void Configure(EntityTypeBuilder<SourceCategory> builder)
    {
      

        builder.HasOne(x => x.Category)
            .WithMany(p => p.Sources)
            .HasForeignKey(k => k.CategoryId);
        
        builder.HasOne(x => x.Source)
            .WithMany(p => p.Categories)
            .HasForeignKey(k => k.SourceId);
        
        base.Configure(builder);
    }
}