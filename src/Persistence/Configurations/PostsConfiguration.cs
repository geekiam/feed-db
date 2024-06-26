using Geekiam.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Threenine.Configurations.PostgreSql;
using Threenine.Database.Configuration.PostgreSql;
using Threenine.Database.Extensions;

namespace Geekiam.Persistence.Configurations;

internal class PostsConfiguration : BaseEntityTypeConfiguration<Posts>
{
    public override void Configure(EntityTypeBuilder<Posts> builder)
    {
        builder.Property(x => x.Title)
            .HasColumnName(nameof(Posts.Title).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasColumnName(nameof(Posts.Description).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(x => x.Permalink)
            .HasColumnName(nameof(Posts.Permalink).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(255)
            .IsRequired();


        builder.Property(x => x.Summary)
            .HasColumnName(nameof(Posts.Summary).ToSnakeCase())
            .HasColumnType(ColumnTypes.Varchar)
            .HasMaxLength(150);

        builder.HasIndex(x => new { x.Permalink }).IsUnique();

        builder.Property(x => x.Published)
            .HasColumnName(nameof(Posts.Published).ToSnakeCase())
            .HasColumnType(ColumnTypes.Timestamp)
            .IsRequired();

        builder.Property(x => x.FeedId)
            .HasColumnName(nameof(Posts.FeedId).ToSnakeCase())
            .HasColumnType(ColumnTypes.UniqueIdentifier)
            .IsRequired();

        builder.HasOne(x => x.Feed)
            .WithMany(x => x.Posts)
            .HasForeignKey(x => x.FeedId);

        builder.HasOne(x => x.Twitter)
            .WithOne(x => x.Post)
            .HasForeignKey<Twitter>(k => k.PostId);

        builder.HasOne(x => x.OpenGraph)
            .WithOne(x => x.Post)
            .HasForeignKey<OpenGraph>(k => k.PostId);

        base.Configure(builder);
    }
}