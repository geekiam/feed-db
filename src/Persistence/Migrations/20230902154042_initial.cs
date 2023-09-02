using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Geekiam.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Feeds");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "Feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "varchar", maxLength: 65, nullable: false),
                    Permalink = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "media_types",
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
                    table.PrimaryKey("PK_media_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status",
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
                    table.PrimaryKey("PK_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sources",
                schema: "Feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Identifier = table.Column<string>(type: "varchar", maxLength: 75, nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "varchar", maxLength: 300, nullable: false),
                    Domain = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    FeedUrl = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    Protocol = table.Column<string>(type: "varchar", maxLength: 7, nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false),
                    MediaTypeId = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sources", x => x.id);
                    table.ForeignKey(
                        name: "FK_sources_media_types_MediaTypeId",
                        column: x => x.MediaTypeId,
                        principalSchema: "Feeds",
                        principalTable: "media_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sources_status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Feeds",
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                schema: "Feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Title = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    Summary = table.Column<string>(type: "varchar", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "varchar", maxLength: 300, nullable: false),
                    Permalink = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    Published = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_posts_sources_SourceId",
                        column: x => x.SourceId,
                        principalSchema: "Feeds",
                        principalTable: "sources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "source_category",
                schema: "Feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_source_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_source_category_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Feeds",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_source_category_sources_SourceId",
                        column: x => x.SourceId,
                        principalSchema: "Feeds",
                        principalTable: "sources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_media_types_name",
                schema: "Feeds",
                table: "media_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_posts_Permalink_SourceId",
                schema: "Feeds",
                table: "posts",
                columns: new[] { "Permalink", "SourceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_posts_SourceId",
                schema: "Feeds",
                table: "posts",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_source_category_CategoryId_SourceId",
                schema: "Feeds",
                table: "source_category",
                columns: new[] { "CategoryId", "SourceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_source_category_SourceId",
                schema: "Feeds",
                table: "source_category",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_sources_FeedUrl_Domain",
                schema: "Feeds",
                table: "sources",
                columns: new[] { "FeedUrl", "Domain" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sources_Identifier",
                schema: "Feeds",
                table: "sources",
                column: "Identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sources_MediaTypeId",
                schema: "Feeds",
                table: "sources",
                column: "MediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_sources_StatusId",
                schema: "Feeds",
                table: "sources",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_status_name",
                schema: "Feeds",
                table: "status",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts",
                schema: "Feeds");

            migrationBuilder.DropTable(
                name: "source_category",
                schema: "Feeds");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "Feeds");

            migrationBuilder.DropTable(
                name: "sources",
                schema: "Feeds");

            migrationBuilder.DropTable(
                name: "media_types",
                schema: "Feeds");

            migrationBuilder.DropTable(
                name: "status",
                schema: "Feeds");
        }
    }
}
