using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;
using Threenine;
using Threenine.Configurations.PostgreSql;


namespace Geekiam.Persistence.Configurations;

public class SchedulesConfiguration : Threenine.Database.Configuration.PostgreSql.BaseEntityTypeConfiguration<Schedules>
{
    public override void Configure(EntityTypeBuilder<Schedules> builder)
    {
        builder.HasIndex(x => new { x.ScheduleTypeId, x.FeedId }).IsUnique();
       
        builder.Property(x => x.FeedId)
            .HasColumnName(nameof(Schedules.FeedId).ToSnakeCase())
            .HasColumnType(ColumnTypes.UniqueIdentifier)
            .IsRequired();
        
        builder.Property(x => x.ScheduleTypeId)
            .HasColumnName(nameof(Schedules.ScheduleTypeId).ToSnakeCase())
            .HasColumnType(ColumnTypes.Integer)
            .IsRequired();
        
        builder.HasOne(x => x.ScheduleType)
            .WithMany(x => x.Schedules)
            .HasForeignKey(x => x.ScheduleTypeId);

        builder.HasOne(x => x.Feed)
            .WithMany(x => x.Schedules)
            .HasForeignKey(x => x.FeedId);
    
        
        base.Configure(builder);
    }
}