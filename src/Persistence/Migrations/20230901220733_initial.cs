﻿using System;
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
                name: "MediaTypes",
                schema: "Feeds",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "varchar", maxLength: 150, nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTypes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "Feeds",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "varchar", maxLength: 150, nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.id);
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
                    created = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    modified = table.Column<DateTime>(type: "TimestampTz", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sources", x => x.id);
                    table.ForeignKey(
                        name: "FK_sources_Status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Feeds",
                        principalTable: "Status",
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

            migrationBuilder.CreateIndex(
                name: "IX_MediaTypes_name",
                schema: "Feeds",
                table: "MediaTypes",
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
                name: "IX_sources_StatusId",
                schema: "Feeds",
                table: "sources",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_name",
                schema: "Feeds",
                table: "Status",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaTypes",
                schema: "Feeds");

            migrationBuilder.DropTable(
                name: "posts",
                schema: "Feeds");

            migrationBuilder.DropTable(
                name: "sources",
                schema: "Feeds");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "Feeds");
        }
    }
}
