using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aper.Api.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScrapedSince",
                table: "Channel");

            migrationBuilder.DropColumn(
                name: "ScrapedUntil",
                table: "Channel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ScrapedSince",
                table: "Channel",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScrapedUntil",
                table: "Channel",
                type: "TEXT",
                nullable: true);
        }
    }
}
