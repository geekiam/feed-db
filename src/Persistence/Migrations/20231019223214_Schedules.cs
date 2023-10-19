using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Geekiam.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Schedules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "schedule_types",
                schema: "Feeds",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 75, nullable: false),
                    description = table.Column<string>(type: "varchar", maxLength: 150, nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedule_types", x => x.id);
                });
            
            migrationBuilder.InsertData(  
                table: "schedule_types",  
                columns: new[] { "name", "description", "active" },  
                values: new object[,]  
                {  
                    { "Hourly", "Process Feeds Every Hour", true },  
                    { "Daily", "Process Feeds Every day", true },  
                    { "Weekly", "Process Feeds Every week", true },  
                    { "Monthly", "Process feeds every month", true }  
                }  
            );

            migrationBuilder.CreateTable(
                name: "schedules",
                schema: "Feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    source_id = table.Column<Guid>(type: "uuid", nullable: false),
                    schedule_type_id = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_schedules_schedule_types_schedule_type_id",
                        column: x => x.schedule_type_id,
                        principalSchema: "Feeds",
                        principalTable: "schedule_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_schedules_sources_source_id",
                        column: x => x.source_id,
                        principalSchema: "Feeds",
                        principalTable: "sources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_schedule_types_name",
                schema: "Feeds",
                table: "schedule_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_schedules_schedule_type_id_source_id",
                schema: "Feeds",
                table: "schedules",
                columns: new[] { "schedule_type_id", "source_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_schedules_source_id",
                schema: "Feeds",
                table: "schedules",
                column: "source_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "schedules",
                schema: "Feeds");

            migrationBuilder.DropTable(
                name: "schedule_types",
                schema: "Feeds");
        }
    }
}
