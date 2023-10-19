using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Geekiam.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Iniital : Migration
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
            
            migrationBuilder.InsertData(  
                table: "media_types",  
                columns: new []{ "name", "description", "active" },  
                values:  new object[,]  
                {  
                    {"Image", "Primary image feed", true},  
                    {"Video", "Video based feed", true },  
                    {"Audio", "Audio based feed" , true },   
                    {"Blog", "Blog based feed", true},  
                    {"Article", "Article based feed", true},  
                    {"News", "News based feed", true },  
                    {"Podcast", "Podcast based feed", true},  
                    {"Text", "Text based feed", true}  
                }  
            );
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
                schema: "Feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    identifier = table.Column<string>(type: "varchar", maxLength: 75, nullable: false),
                    name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "varchar", maxLength: 300, nullable: false),
                    domain = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    feed_url = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    protocol = table.Column<string>(type: "varchar", maxLength: 7, nullable: false),
                    status_id = table.Column<int>(type: "integer", nullable: false),
                    media_type_id = table.Column<int>(type: "integer", nullable: false),
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sources", x => x.id);
                    table.ForeignKey(
                        name: "FK_sources_media_types_media_type_id",
                        column: x => x.media_type_id,
                        principalSchema: "Feeds",
                        principalTable: "media_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sources_status_status_id",
                        column: x => x.status_id,
                        principalSchema: "Feeds",
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
            
            migrationBuilder.InsertData(  
                table: "sources",  
                columns:  new []{ "identifier", "name", "description", "domain", "feed_url", "protocol", "status_id", "media_type_id", "created", "modified"  },  
                values:new object[,]  
                {  
                    {"g_garywoodfine_0001", "Gary Woodfine", "Opinionated Software Developer", "garywoodfine.com",  "/feed", "https", 1, 4 , DateTime.UtcNow, DateTime.UtcNow } ,
                    {"g_cryptonews_0001" , "Crypto News",   "Latest Cryptocurrency News, Bitcoin News, Ethereum News and Price Data",  "cryptonews.com", "news/feed",  "https", 1, 6, DateTime.UtcNow, DateTime.UtcNow },
                    {"g_bitcoinmagazine_0001",  "Bitcoin Magazine",  "Bitcoin News, Articles and Expert Insights", "bitcoinmagazine.com", "/.rss/full/", "https", 1, 5, DateTime.UtcNow, DateTime.UtcNow },
                    {"g_cointelegraph_0001", "Coin Telegraph", "Bitcoin, Ethereum, Crypto News & Price Indexes", "cointelegraph.com", "/rss", "https", 1, 6, DateTime.UtcNow, DateTime.UtcNow   },
                    {"g_bitcoinist_0001",  "Bitcoinist", "Bitcoin news portal providing breaking news, guides, price and analysis about decentralized digital money and blockchain technology.", "bitcoinist.com", "/feed",  "https", 1,6 , DateTime.UtcNow, DateTime.UtcNow }
                }  
            );


            migrationBuilder.CreateTable(
                name: "posts",
                schema: "Feeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    title = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    summary = table.Column<string>(type: "varchar", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "varchar", maxLength: 300, nullable: false),
                    permalink = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    published = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    source_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_posts_sources_source_id",
                        column: x => x.source_id,
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
                        principalSchema: "Feeds",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_source_category_sources_source_id",
                        column: x => x.source_id,
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
                name: "IX_posts_permalink_source_id",
                schema: "Feeds",
                table: "posts",
                columns: new[] { "permalink", "source_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_posts_source_id",
                schema: "Feeds",
                table: "posts",
                column: "source_id");

            migrationBuilder.CreateIndex(
                name: "IX_source_category_category_id_source_id",
                schema: "Feeds",
                table: "source_category",
                columns: new[] { "category_id", "source_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_source_category_source_id",
                schema: "Feeds",
                table: "source_category",
                column: "source_id");

            migrationBuilder.CreateIndex(
                name: "IX_sources_feed_url_domain",
                schema: "Feeds",
                table: "sources",
                columns: new[] { "feed_url", "domain" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sources_identifier",
                schema: "Feeds",
                table: "sources",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sources_media_type_id",
                schema: "Feeds",
                table: "sources",
                column: "media_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_sources_status_id",
                schema: "Feeds",
                table: "sources",
                column: "status_id");

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
