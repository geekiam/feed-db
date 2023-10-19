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
        builder.HasIndex(x => new { x.ScheduleTypeId, x.SourceId }).IsUnique();
        builder.Property(x => x.SourceId)
            .HasColumnName(nameof(Schedules.SourceId).ToSnakeCase())
            .HasColumnType(ColumnTypes.UniqueIdentifier)
            .IsRequired();
        
        builder.Property(x => x.ScheduleTypeId)
            .HasColumnName(nameof(Schedules.ScheduleTypeId).ToSnakeCase())
            .HasColumnType(ColumnTypes.Integer)
            .IsRequired();
        
        builder.HasOne(x => x.ScheduleTypes)
            .WithMany(x => x.Schedules)
            .HasForeignKey(x => x.ScheduleTypeId);
        
        builder.HasOne(x => x.Source)
            .WithMany(x => x.Schedules)
            .HasForeignKey(x => x.SourceId);
        
        base.Configure(builder);
    }
}