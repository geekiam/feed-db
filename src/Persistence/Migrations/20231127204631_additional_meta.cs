using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geekiam.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class additional_meta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "geekiam_feeds",
                table: "categories",
                newName: "name");

            migrationBuilder.AlterColumn<int>(
                name: "status_id",
                schema: "geekiam_feeds",
                table: "sources",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "status_id",
                schema: "geekiam_feeds",
                table: "feeds",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "open_graph",
                schema: "geekiam_feeds",
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
                        principalSchema: "geekiam_feeds",
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "twitter",
                schema: "geekiam_feeds",
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
                        principalSchema: "geekiam_feeds",
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_open_graph_post_id",
                schema: "geekiam_feeds",
                table: "open_graph",
                column: "post_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_twitter_post_id",
                schema: "geekiam_feeds",
                table: "twitter",
                column: "post_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "open_graph",
                schema: "geekiam_feeds");

            migrationBuilder.DropTable(
                name: "twitter",
                schema: "geekiam_feeds");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "geekiam_feeds",
                table: "categories",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "status_id",
                schema: "geekiam_feeds",
                table: "sources",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "status_id",
                schema: "geekiam_feeds",
                table: "feeds",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);
        }
    }
}
