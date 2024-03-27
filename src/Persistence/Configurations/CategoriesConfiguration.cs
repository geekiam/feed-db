using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Threenine.Configurations.PostgreSql;
using Threenine.Database.Configuration.PostgreSql;
using Threenine.Database.Extensions;

namespace Geekiam.Persistence.Configurations;

internal class CategoriesConfiguration : BaseEntityTypeConfiguration<Categories>
{
    public override void Configure(EntityTypeBuilder<Categories> builder)
    {
        builder.Property(x => x.Name)
            .HasColumnName(nameof(Categories.Name).ToSnakeCase())
            .IsRequired()
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(65);


        base.Configure(builder);
    }
}