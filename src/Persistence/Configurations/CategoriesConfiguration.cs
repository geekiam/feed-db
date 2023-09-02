using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Threenine.Configurations.PostgreSql;
using Threenine.Database.Configuration.PostgreSql;

namespace Geekiam.Configurations;

public class CategoriesConfiguration : BaseEntityTypeConfiguration<Categories>
{
    public override void Configure(EntityTypeBuilder<Categories> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(65);

        builder.Property(x => x.Permalink)
            .IsRequired()
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255);
        
        base.Configure(builder);
    }
}