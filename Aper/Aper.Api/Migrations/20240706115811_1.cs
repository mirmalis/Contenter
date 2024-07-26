using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aper.Api.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Channel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ScrapedUntil = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ScrapedSince = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DateTime('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorId = table.Column<string>(type: "TEXT", nullable: true),
                    PublishedAtRaw = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastFieldChangedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastChange_Stats = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ViewCount = table.Column<ulong>(type: "INTEGER", nullable: true),
                    LikeCount = table.Column<ulong>(type: "INTEGER", nullable: true),
                    CommentCount = table.Column<ulong>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DateTime('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_Channel_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Channel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Video_Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VideoId = table.Column<string>(type: "TEXT", nullable: false),
                    ViewCount = table.Column<ulong>(type: "INTEGER", nullable: true),
                    LikeCount = table.Column<ulong>(type: "INTEGER", nullable: true),
                    CommentCount = table.Column<ulong>(type: "INTEGER", nullable: true),
                    DislikeCount = table.Column<ulong>(type: "INTEGER", nullable: true),
                    FavoriteCount = table.Column<ulong>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video_Status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_Status_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoField",
                columns: table => new
                {
                    VideoId = table.Column<string>(type: "TEXT", nullable: false),
                    Field = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "DateTime('now')"),
                    LatestCheck = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LatestChange = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoField", x => new { x.VideoId, x.Field });
                    table.ForeignKey(
                        name: "FK_VideoField_Video_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Video",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoFieldChange",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    VideoFieldVideoId = table.Column<string>(type: "TEXT", nullable: false),
                    VideoField = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoFieldChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoFieldChange_VideoField_VideoFieldVideoId_VideoField",
                        columns: x => new { x.VideoFieldVideoId, x.VideoField },
                        principalTable: "VideoField",
                        principalColumns: new[] { "VideoId", "Field" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Video_AuthorId",
                table: "Video",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_Status_VideoId",
                table: "Video_Status",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoFieldChange_VideoFieldVideoId_VideoField",
                table: "VideoFieldChange",
                columns: new[] { "VideoFieldVideoId", "VideoField" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Video_Status");

            migrationBuilder.DropTable(
                name: "VideoFieldChange");

            migrationBuilder.DropTable(
                name: "VideoField");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "Channel");
        }
    }
}
