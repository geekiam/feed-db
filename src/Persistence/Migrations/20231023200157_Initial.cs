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
                name: "geekiam_feeds");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "geekiam_feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Name = table.Column<string>(type: "varchar", maxLength: 65, nullable: false),
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
                schema: "geekiam_feeds",
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
            
            migrationBuilder.InsertData(  
                table: "media_types",  
                columns: new []{ "name", "description", "active" },  
                values:  new object[,]  
                {  
                    {"application/rss+xml", "RSS XML Feed", true},  
                    {"application/atom+xml", "atom+xml", true },  
                    {"application/feed+json", "feed+json" , true }
                }  
            );

            migrationBuilder.CreateTable(
                name: "schedule_types",
                schema: "geekiam_feeds",
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
                schema: "geekiam_feeds",
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
            
            migrationBuilder.InsertData(  
                table: "status",  
                columns: new []{ "name", "description", "active" },  
                values: new object[,]  
                {  
                    {"Moderate", "Default status for new feeds", true},  
                    {"Under Review", "Administrators are reviewing this feed", true},  
                    {"Banned", "This feed has been banned", true},  
                    {"Approved", "This feed has been approved", true}  
                }  
            );

            migrationBuilder.CreateTable(
                name: "sources",
                schema: "geekiam_feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    identifier = table.Column<string>(type: "varchar", maxLength: 75, nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "varchar", maxLength: 300, nullable: false),
                    domain = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    protocol = table.Column<string>(type: "varchar", maxLength: 7, nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false),
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
                        principalSchema: "geekiam_feeds",
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "sources",
                columns: new[]
                    { "identifier", "name", "description", "domain", "protocol", "status_id", "created", "modified" },
                values: new object[,]
                {
                    {"g_garywoodfine_0001", "Gary Woodfine", "Opinionated Software Developer", "garywoodfine.com", "https", 4 , DateTime.UtcNow, DateTime.UtcNow } ,
                    {"g_cryptonews_0001" , "Crypto News",   "Latest Cryptocurrency News, Bitcoin News, Ethereum News and Price Data",  "cryptonews.com", "https", 4, DateTime.UtcNow, DateTime.UtcNow },
                    {"g_bitcoinmagazine_0001",  "Bitcoin Magazine",  "Bitcoin News, Articles and Expert Insights", "bitcoinmagazine.com", "https",  4, DateTime.UtcNow, DateTime.UtcNow },
                    {"g_cointelegraph_0001", "Coin Telegraph", "Bitcoin, Ethereum, Crypto News & Price Indexes", "cointelegraph.com", "https",  4, DateTime.UtcNow, DateTime.UtcNow   },
                    {"g_bitcoinist_0001",  "Bitcoinist", "Bitcoin news portal providing breaking news, guides, price and analysis about decentralized digital money and blockchain technology.", "bitcoinist.com",  "https", 4 , DateTime.UtcNow, DateTime.UtcNow }
                }
            );

            migrationBuilder.CreateTable(
                name: "feeds",
                schema: "geekiam_feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    sources_id = table.Column<Guid>(type: "uuid", nullable: false),
                    media_type_id = table.Column<int>(type: "integer", nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false),
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
                        principalSchema: "geekiam_feeds",
                        principalTable: "media_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feeds_sources_sources_id",
                        column: x => x.sources_id,
                        principalSchema: "geekiam_feeds",
                        principalTable: "sources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feeds_status_status_id",
                        column: x => x.status_id,
                        principalSchema: "geekiam_feeds",
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "source_category",
                schema: "geekiam_feeds",
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
                        principalSchema: "geekiam_feeds",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_source_category_sources_source_id",
                        column: x => x.source_id,
                        principalSchema: "geekiam_feeds",
                        principalTable: "sources",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                schema: "geekiam_feeds",
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
                        principalSchema: "geekiam_feeds",
                        principalTable: "feeds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                schema: "geekiam_feeds",
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
                        principalSchema: "geekiam_feeds",
                        principalTable: "feeds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_schedules_schedule_types_schedule_type_id",
                        column: x => x.schedule_type_id,
                        principalSchema: "geekiam_feeds",
                        principalTable: "schedule_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_feeds_media_type_id",
                schema: "geekiam_feeds",
                table: "feeds",
                column: "media_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_feeds_sources_id",
                schema: "geekiam_feeds",
                table: "feeds",
                column: "sources_id");

            migrationBuilder.CreateIndex(
                name: "IX_feeds_status_id",
                schema: "geekiam_feeds",
                table: "feeds",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_media_types_name",
                schema: "geekiam_feeds",
                table: "media_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_posts_feed_id",
                schema: "geekiam_feeds",
                table: "posts",
                column: "feed_id");

            migrationBuilder.CreateIndex(
                name: "IX_posts_permalink",
                schema: "geekiam_feeds",
                table: "posts",
                column: "permalink",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_schedule_types_name",
                schema: "geekiam_feeds",
                table: "schedule_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_schedules_feed_id",
                schema: "geekiam_feeds",
                table: "schedules",
                column: "feed_id");

            migrationBuilder.CreateIndex(
                name: "IX_schedules_schedule_type_id_feed_id",
                schema: "geekiam_feeds",
                table: "schedules",
                columns: new[] { "schedule_type_id", "feed_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_source_category_category_id_source_id",
                schema: "geekiam_feeds",
                table: "source_category",
                columns: new[] { "category_id", "source_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_source_category_source_id",
                schema: "geekiam_feeds",
                table: "source_category",
                column: "source_id");

            migrationBuilder.CreateIndex(
                name: "IX_sources_domain",
                schema: "geekiam_feeds",
                table: "sources",
                column: "domain",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sources_identifier",
                schema: "geekiam_feeds",
                table: "sources",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sources_status_id",
                schema: "geekiam_feeds",
                table: "sources",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_status_name",
                schema: "geekiam_feeds",
                table: "status",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts",
                schema: "geekiam_feeds");

            migrationBuilder.DropTable(
                name: "schedules",
                schema: "geekiam_feeds");

            migrationBuilder.DropTable(
                name: "source_category",
                schema: "geekiam_feeds");

            migrationBuilder.DropTable(
                name: "feeds",
                schema: "geekiam_feeds");

            migrationBuilder.DropTable(
                name: "schedule_types",
                schema: "geekiam_feeds");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "geekiam_feeds");

            migrationBuilder.DropTable(
                name: "media_types",
                schema: "geekiam_feeds");

            migrationBuilder.DropTable(
                name: "sources",
                schema: "geekiam_feeds");

            migrationBuilder.DropTable(
                name: "status",
                schema: "geekiam_feeds");
        }
    }
}
