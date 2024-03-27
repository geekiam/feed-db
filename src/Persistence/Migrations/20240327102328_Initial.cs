using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Geekiam.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "feeds");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "varchar", maxLength: 65, nullable: false),
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
                schema: "feeds",
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
                name: "schedule_types",
                schema: "feeds",
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

            migrationBuilder.CreateTable(
                name: "status",
                schema: "feeds",
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
                schema: "feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    identifier = table.Column<string>(type: "varchar", maxLength: 75, nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "varchar", maxLength: 300, nullable: false),
                    domain = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    protocol = table.Column<string>(type: "varchar", maxLength: 7, nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sources", x => x.id);
                    table.ForeignKey(
                        name: "FK_sources_status_status_id",
                        column: x => x.status_id,
                        principalSchema: "feeds",
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "feeds",
                schema: "feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    sources_id = table.Column<Guid>(type: "uuid", nullable: false),
                    media_type_id = table.Column<int>(type: "integer", nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    path = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feeds", x => x.id);
                    table.ForeignKey(
                        name: "FK_feeds_media_types_media_type_id",
                        column: x => x.media_type_id,
                        principalSchema: "feeds",
                        principalTable: "media_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feeds_sources_sources_id",
                        column: x => x.sources_id,
                        principalSchema: "feeds",
                        principalTable: "sources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feeds_status_status_id",
                        column: x => x.status_id,
                        principalSchema: "feeds",
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "source_category",
                schema: "feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    source_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_source_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_source_category_categories_category_id",
                        column: x => x.category_id,
                        principalSchema: "feeds",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_source_category_sources_source_id",
                        column: x => x.source_id,
                        principalSchema: "feeds",
                        principalTable: "sources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                schema: "feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    title = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    summary = table.Column<string>(type: "varchar", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "varchar", maxLength: 300, nullable: false),
                    permalink = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    published = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    feed_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_posts_feeds_feed_id",
                        column: x => x.feed_id,
                        principalSchema: "feeds",
                        principalTable: "feeds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                schema: "feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    feed_id = table.Column<Guid>(type: "uuid", nullable: false),
                    schedule_type_id = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_schedules_feeds_feed_id",
                        column: x => x.feed_id,
                        principalSchema: "feeds",
                        principalTable: "feeds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_schedules_schedule_types_schedule_type_id",
                        column: x => x.schedule_type_id,
                        principalSchema: "feeds",
                        principalTable: "schedule_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "open_graph",
                schema: "feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    post_id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "varchar", maxLength: 75, nullable: false),
                    title = table.Column<string>(type: "varchar", maxLength: 70, nullable: false),
                    description = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    url = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    site_name = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_open_graph", x => x.id);
                    table.ForeignKey(
                        name: "FK_open_graph_posts_post_id",
                        column: x => x.post_id,
                        principalSchema: "feeds",
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "twitter",
                schema: "feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    post_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "varchar", maxLength: 70, nullable: false),
                    description = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    site = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    creator = table.Column<string>(type: "varchar", maxLength: 75, nullable: false),
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_twitter", x => x.id);
                    table.ForeignKey(
                        name: "FK_twitter_posts_post_id",
                        column: x => x.post_id,
                        principalSchema: "feeds",
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_feeds_media_type_id",
                schema: "feeds",
                table: "feeds",
                column: "media_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_feeds_sources_id",
                schema: "feeds",
                table: "feeds",
                column: "sources_id");

            migrationBuilder.CreateIndex(
                name: "IX_feeds_status_id",
                schema: "feeds",
                table: "feeds",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_media_types_name",
                schema: "feeds",
                table: "media_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_open_graph_post_id",
                schema: "feeds",
                table: "open_graph",
                column: "post_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_posts_feed_id",
                schema: "feeds",
                table: "posts",
                column: "feed_id");

            migrationBuilder.CreateIndex(
                name: "IX_posts_permalink",
                schema: "feeds",
                table: "posts",
                column: "permalink",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_schedule_types_name",
                schema: "feeds",
                table: "schedule_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_schedules_feed_id",
                schema: "feeds",
                table: "schedules",
                column: "feed_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedules_schedule_type_id_feed_id",
                schema: "feeds",
                table: "schedules",
                columns: new[] { "schedule_type_id", "feed_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_source_category_category_id_source_id",
                schema: "feeds",
                table: "source_category",
                columns: new[] { "category_id", "source_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_source_category_source_id",
                schema: "feeds",
                table: "source_category",
                column: "source_id");

            migrationBuilder.CreateIndex(
                name: "IX_sources_domain",
                schema: "feeds",
                table: "sources",
                column: "domain",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sources_identifier",
                schema: "feeds",
                table: "sources",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sources_status_id",
                schema: "feeds",
                table: "sources",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_status_name",
                schema: "feeds",
                table: "status",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_twitter_post_id",
                schema: "feeds",
                table: "twitter",
                column: "post_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "open_graph",
                schema: "feeds");

            migrationBuilder.DropTable(
                name: "schedules",
                schema: "feeds");

            migrationBuilder.DropTable(
                name: "source_category",
                schema: "feeds");

            migrationBuilder.DropTable(
                name: "twitter",
                schema: "feeds");

            migrationBuilder.DropTable(
                name: "schedule_types",
                schema: "feeds");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "feeds");

            migrationBuilder.DropTable(
                name: "posts",
                schema: "feeds");

            migrationBuilder.DropTable(
                name: "feeds",
                schema: "feeds");

            migrationBuilder.DropTable(
                name: "media_types",
                schema: "feeds");

            migrationBuilder.DropTable(
                name: "sources",
                schema: "feeds");

            migrationBuilder.DropTable(
                name: "status",
                schema: "feeds");
        }
    }
}
